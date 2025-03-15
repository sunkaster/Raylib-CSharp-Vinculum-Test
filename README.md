# Raylib-CSharp-Vinculum-Test
A test project using a c# binding for the Raylib graphical library called CSharp-Vinculum.
- Uses Dotnet 9.0 which can be found here: https://dotnet.microsoft.com/en-us/download
- Link to Raylib: https://github.com/raysan5/raylib 
- Link to Raylib-CSharp-Vinculum: https://github.com/ZeroElectric/Raylib-CSharp-Vinculum

Features:
- Basic screen switching (Logo, main menu and gameplay)
- Player movement and rotation
- Spawnable "Enemies" which moves towards the player location and despawns after a certain time

Planned Features:
- Collision and damage calculations between enemies and player
- Endscreen upon life hitting 0
- enemie to enemie collision
- Ability to damage enemies instead of waiting for them to die of old age.

Run the following terminal command inside the project directory(Where the Program.cs file is):
```terminal
dotnet run Program.cs
```