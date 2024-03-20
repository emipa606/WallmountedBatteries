using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace WallmountedBattery;

[StaticConstructorOnStartup]
public class Building_WallmountedBattery : Building
{
    private const float MinEnergyToExplode = 250f;
    private const float EnergyToLoseWhenExplode = 200f;
    private const float ExplodeChancePerDamage = 0.05f;

    private static readonly Material BatteryBarFilledMat =
        SolidColorMaterials.SimpleSolidColorMaterial(new Color(0.9f, 0.85f, 0.2f));

    private static readonly Material BatteryBarUnfilledMat =
        SolidColorMaterials.SimpleSolidColorMaterial(new Color(0.3f, 0.3f, 0.3f));

    private int ticksToExplode;
    private Sustainer wickSustainer;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref ticksToExplode, "ticksToExplode");
    }

    public override void Tick()
    {
        base.Tick();
        if (ticksToExplode <= 0)
        {
            return;
        }

        if (wickSustainer == null)
        {
            StartWickSustainer();
        }
        else
        {
            wickSustainer.Maintain();
        }

        ticksToExplode--;
        if (ticksToExplode != 0)
        {
            return;
        }

        var radius = Rand.Range(0.5f, 1f) * 1.5f;
        GenExplosion.DoExplosion(Rotation.FacingCell, Map, radius, DamageDefOf.Flame, null);
        GetComp<CompPowerBattery>().DrawPower(EnergyToLoseWhenExplode);
    }

    public override void PostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
    {
        base.PostApplyDamage(dinfo, totalDamageDealt);
        if (Destroyed || ticksToExplode != 0 || dinfo.Def != DamageDefOf.Flame ||
            !(Rand.Value < ExplodeChancePerDamage) ||
            !(GetComp<CompPowerBattery>().StoredEnergy > MinEnergyToExplode))
        {
            return;
        }

        ticksToExplode = Rand.Range(70, 150);
        StartWickSustainer();
    }

    private void StartWickSustainer()
    {
        var info = SoundInfo.InMap(this, MaintenanceType.PerTick);
        wickSustainer = SoundDefOf.HissSmall.TrySpawnSustainer(info);
    }


    protected override void DrawAt(Vector3 drawLoc, bool flip = false)
    {
        base.DrawAt(drawLoc, flip);
        var currentRotation = Rotation.AsInt;
        var comp = GetComp<CompPowerBattery>();

        var r = default(GenDraw.FillableBarRequest);
        r.center = drawLoc;

        const float offsetFromCenter = 0.3f;
        const float northOffset = 0.16f;
        const float sideOffset = 0.19f;
        const float sideVertOffset = 0.077f;
        r.rotation = Rotation.Rotated(RotationDirection.Clockwise);
        switch (currentRotation)
        {
            // North
            case 0:
                r.center.z = r.center.z + offsetFromCenter + northOffset;
                r.rotation = Rotation;
                r.size = new Vector2(0.26f, 0.04f);
                break;
            // East
            case 1:
                r.center.x = r.center.x + offsetFromCenter + sideVertOffset;
                r.center.z += sideOffset;
                r.size = new Vector2(0.14f, 0.04f);
                break;
            // South
            case 2:
                r.center.z -= offsetFromCenter;
                r.size = new Vector2(0.28f, 0.05f);
                break;
            // West
            default:
                r.center.x = r.center.x - offsetFromCenter - sideVertOffset;
                r.center.z += sideOffset;
                r.size = new Vector2(0.14f, 0.04f);
                break;
        }

        r.margin = 0.02f;
        r.fillPercent = comp.StoredEnergy / comp.Props.storedEnergyMax;
        r.filledMat = BatteryBarFilledMat;
        r.unfilledMat = BatteryBarUnfilledMat;
        DrawFillableBarVerbatim(r);
    }

    private static void DrawFillableBarVerbatim(GenDraw.FillableBarRequest r)
    {
        var vector = r.preRotationOffset.RotatedBy(r.rotation.AsAngle);
        r.center += new Vector3(vector.x, 0f, vector.y);
        var s = new Vector3(r.size.x + r.margin, 1f, r.size.y + r.margin);
        var matrix = default(Matrix4x4);
        matrix.SetTRS(r.center, r.rotation.AsQuat, s);
        Graphics.DrawMesh(MeshPool.plane10, matrix, r.unfilledMat, 0);
        if (!(r.fillPercent > 0.001f))
        {
            return;
        }

        s = new Vector3(r.size.x * r.fillPercent, 1f, r.size.y);
        matrix = default;
        var pos = r.center + (Vector3.up * 0.01f);
        if (!r.rotation.IsHorizontal)
        {
            if (r.rotation == Rot4.North)
            {
                pos.x -= r.size.x * 0.5f;
                pos.x += 0.5f * r.size.x * r.fillPercent;
            }
            else
            {
                pos.x += r.size.x * 0.5f;
                pos.x -= 0.5f * r.size.x * r.fillPercent;
            }
        }
        else
        {
            pos.z -= r.size.x * 0.5f;
            pos.z += 0.5f * r.size.x * r.fillPercent;
        }

        matrix.SetTRS(pos, r.rotation.AsQuat, s);
        Graphics.DrawMesh(MeshPool.plane10, matrix, r.filledMat, 0);
    }
}