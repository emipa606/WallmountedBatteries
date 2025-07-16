# .github/copilot-instructions.md

## RimWorld Modding Project: WallmountedBattery

### Mod Overview and Purpose

The WallmountedBattery mod adds a unique building to RimWorld: a battery that can be mounted on walls. This innovative design allows players to make efficient use of space, enhancing gameplay by providing greater flexibility in base design and energy management.

### Key Features and Systems

- **Wall-mounted Battery Building**: The central feature of this mod is the `Building_WallmountedBattery`, a special architecture piece that integrates with existing walls.
- **Space Efficiency**: Players can utilize wall space effectively, allowing for more compact and organized base layouts.
- **Custom PlaceWorker**: The `WallmountedBattery_PlaceWorker` class ensures that the battery can only be placed on walls, maintaining game balance and immersion.

### Coding Patterns and Conventions

- **Class Naming**: Classes are named using PascalCase, reflecting their functionality clearly (e.g., `Building_WallmountedBattery`, `WallmountedBattery_PlaceWorker`).
- **Method Naming**: Methods also use PascalCase and typically start with a verb to indicate action, such as `StartWickSustainer`.
- **Access Modifiers**: Leverage appropriate access levels (`public`, `private`) to encapsulate functionality and prevent unintended access.

### XML Integration

In RimWorld modding, XML files define much of the game's data, such as items, buildings, and recipes. Although the current summary doesn't specify XML files, typical XML integration points for a building mod would include:

- **Defs Folder**: XML files that define the `ThingDef` for `Building_WallmountedBattery`.
- **PlaceWorker Requirements**: XML configurations to ensure the battery adheres to placement rules (e.g., must be placed adjacent to a wall).

### Harmony Patching

- **Purpose**: Harmony is used to modify existing game behavior without altering original game files, ensuring compatibility across different mods.
- **Patch Example**: If there were game methods to override or enhance, Harmony patches would be applied to relevant methods to customize behavior, such as changing how power is drawn or stored by the battery.

### Suggestions for Copilot

To effectively use GitHub Copilot in this project:

- **Contextual Suggestions**: When writing new C# methods or handling XML configuration, invoke Copilot for suggestions by starting with descriptive comments or method signatures.
- **Code Completion**: Utilize Copilot for completing repetitive structures, such as property definitions or XML nodes.
- **Debugging Assistance**: Take advantage of Copilot's ability to suggest potential fixes or optimizations for existing code, particularly in complex systems like Harmony patches or PlaceWorker logic.

By following these guidelines and leveraging Copilot, developers can efficiently extend the functionality of the WallmountedBattery mod while maintaining high-quality code structure and enhancing player experience in RimWorld.
