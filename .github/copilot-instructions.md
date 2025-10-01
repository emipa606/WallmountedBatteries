# Copilot Instructions for Wallmounted Battery Mod

## Mod Overview and Purpose
The **Wallmounted Battery** mod for RimWorld introduces a new compact energy storage option that can be installed on walls. This battery is designed to conserve space with half the size and capacity of a normal battery, making it ideal for cramped or minimalist bases. The battery is encased in a durable shell, providing resistance to environmental factors like rain, while maintaining a neutral aesthetic that fits into most base designs seamlessly.

## Key Features and Systems
- **Wall-Mountable Battery**: A unique battery that can be placed on walls, optimizing space usage.
- **Environment Resistance**: The outer casing protects the battery from rain, ensuring durability.
- **Compact Design**: Occupies half the space, with a proportionately reduced capacity compared to regular batteries, providing flexibility in design.

## Coding Patterns and Conventions
- **Class Definitions**: The project uses clearly defined public classes for each functional component.
- **Naming Conventions**: Follow C# naming conventions by using PascalCase for classes (`Building_WallmountedBattery`, `WallmountedBattery_PlaceWorker`) and camelCase for methods and local variables.
- **Method Structure**: Even though the example provided only lists one method (`StartWickSustainer`), ensure methods are concise and responsible for single, clear tasks.

## XML Integration
- **Defining the Battery**: Use XML to define the new battery building, specifying its key properties such as size, power capacity, and relevant textures or resources.
- **PlaceWorker**: XML entries should reference `WallmountedBattery_PlaceWorker` to ensure that placement rules (such as wall-only mounting) are enforced.

## Harmony Patching
- **Purpose**: Harmony patches can be used to modify the base game’s methods to support new functionalities needed by the mod, if required.
- **Application**: Ensure that the Harmony patches do not disrupt core game mechanics unless necessary. Patches should be targeted and reversible.

## Suggestions for Copilot
- **Method Auto-Complete**: Suggest completions for partially written methods and class instantiations, particularly focusing on energy management features.
- **Pattern Recognition**: Automatically detect and suggest common patterns in RimWorld mods, such as XML definition structures or standard method patterns in building functionality.
- **Error Detection**: Help identify potential errors related to wall placement logic or power storage mechanics through automated checks.
- **Optimization Hacks**: Suggest optimized patterns for handling asynchronous operations related to energy management and state changes during gameplay.
- **Code Comments**: Encourage developers to use comments to clarify complex logic or mod-specific behaviors, enhancing readability and maintainability.

Be sure to leverage Copilot’s capabilities to streamline code writing and to maintain a high level of code quality by adhering to these guidelines.


This document should guide developers using GitHub Copilot on how to effectively work on the Wallmounted Battery mod for RimWorld, ensuring their code is structured, integrated, and efficient.
