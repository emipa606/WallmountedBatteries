# GitHub Copilot Instructions for Wallmounted Battery Mod

## Mod Overview and Purpose

The **Wallmounted Battery** mod introduces a unique small battery that can be mounted on walls in RimWorld. This innovative design allows for efficient space management within player-built structures. The battery's casing is designed to be resistant to rain, offering durability in various environmental conditions. Its aesthetics are neutral, making it suitable for any decor theme. Though it features half the size and capacity of a standard battery, it provides flexibility and convenience, especially in compact areas. 

## Key Features and Systems

- **Wall-Mountable Design**: The battery can be integrated into walls, freeing up floor space for other constructions.
- **Weather Resistant**: Durable outer casing that withstands environmental elements like rain.
- **Aesthetic Neutrality**: Designed to blend seamlessly with most interior and exterior designs.
- **Efficient Resource Use**: Offers half the capacity of a regular battery but saves significant space.

## Coding Patterns and Conventions

### C#

- The source code is organized into specific classes:
  - `WallmountedBattery_PlaceWorker`: Responsible for placement logic, specifically controlled by the `AllowsPlacing` method.
  - `Building_WallmountedBattery`: Handles the operational logic such as `DrawAt`, `drawFillableBarVerbatim`, `ExposeData`, and lifecycle methods like `PostApplyDamage`, `StartWickSustainer`, and `Tick`.

- Naming conventions:
  - Use PascalCase for type and method names.
  - Use camelCase for local variables.
  - Prefix private fields with `_`.

### XML

- The XML configuration files define essential game elements:
  - `Buildings_Misc.xml` for thing definitions (`ThingDef`) related to the wall-mounted battery.
  - `Electrified_Patch.xml` contains patches expanding behavior, likely using Harmony for runtime modifications.
  - Maintain proper indentation and comments for clarity.

## XML Integration

- XML files serve as the backbone for defining game objects and behaviors:
  - **ThingDefs**: Include definitions for the minified battery and full-scale thing definition necessary for integration into the game.
  - Ensure XML nodes are hierarchically arranged for easy extension and modification.

## Harmony Patching

- The `Electrified_Patch.xml` might use Harmony patches to alter game behavior at runtime:
  - Use Harmony Postfix and Prefix method annotations to safely modify or extend game logic.
  - Fully qualify method targets to avoid ambiguity and ensure proper patch application.

## Suggestions for Copilot

- Use Copilot to generate additional unit tests for `WallmountedBattery_PlaceWorker` to ensure correct placement validation logic.
- Utilize Copilot's pattern recognition to suggest potential optimizations in frequently called methods like `Tick` and `DrawAt`.
- Leverage Copilot to propose XML schema updates aligning with new RimWorld updates or patches by detecting similar patterns in existing mod ecosystems.
- Consider using Copilot to automate repetitive XML node generation, especially for new ThingDefs or patch nodes.

By adhering to these guidelines, contributors and developers can maintain consistency and streamline the development process of the **Wallmounted Battery** mod. Leverage GitHub Copilot effectively to optimize code suggestions and improve mod quality.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

