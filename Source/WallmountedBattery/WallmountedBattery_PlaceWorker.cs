using Verse;

public class WallmountedBattery_PlaceWorker : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)

    {
        var c = loc;

        var support = c.GetEdifice(map);
        if (support == null)
        {
            return "WMB.onsupport".Translate();
        }

        if (support.def?.graphicData == null)
        {
            return "WMB.onsupport".Translate();
        }

        if ((support.def.graphicData.linkFlags & (LinkFlags.Rock | LinkFlags.Wall)) == 0)
        {
            return "WMB.onsupport".Translate();
        }

        c = loc + rot.FacingCell;
        if (!c.Walkable(map))
        {
            return "WMB.walkable".Translate();
        }

        var currentBuildings = loc.GetThingList(map);
        foreach (var building in currentBuildings)
        {
            if (building?.def?.defName != "WallmountedBattery")
            {
                continue;
            }

            return "WMB.existing".Translate();
        }

        return AcceptanceReport.WasAccepted;
    }
}