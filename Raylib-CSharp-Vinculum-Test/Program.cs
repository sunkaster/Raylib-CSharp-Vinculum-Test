using System.Numerics;
using System.Reflection.Metadata;
using Raylib_CSharp_Vinculum_Test;
using ZeroElectric.Vinculum;

namespace VinculumExample;

public static class Program
{
	public enum GameScreen {LOGO = 0, TITLE, GAMEPLAY}

	public static void Main(string[] args)
	{
		// Initialize the window with the specified width, height, and title. Aswell as other initialization stuff
		Raylib.InitWindow(Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), "Hello World");
		Raylib.SetTargetFPS(60);
		int framesCounter = 0;
		GameScreen currentScreen = GameScreen.LOGO;
		Random random = new Random();

		// Player Initialization
        Rectangle player = new Rectangle(Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2, 50f, 50f);
		Vector2 playerOrigin = new Vector2(player.width/2, player.height/2);
		float playerRotation = 0f;

		// Enemie1 initialization
		Rectangle enemie1Rectangle = new Rectangle(400, 400, 100, 100);
		Vector2 enemie1SpawnParameterX = new Vector2(0, Raylib.GetScreenWidth());
		Vector2 enemie1SpawnParameterY = new Vector2(0, Raylib.GetScreenHeight());
		Vector2 enemie1SpawnPosition = new Vector2(random.Next((int)enemie1SpawnParameterX.X, (int)enemie1SpawnParameterX.Y), random.Next((int)enemie1SpawnParameterY.X, (int)enemie1SpawnParameterY.Y));
		Enemie enemie1 = new Enemie(enemie1Rectangle, 0f, enemie1SpawnPosition, enemie1SpawnParameterX, enemie1SpawnParameterY, 5, 0.5f);

		// Enemie2 initialization
		Rectangle enemie2Rectangle = new Rectangle(400, 400, 50, 50);
		Vector2 enemie2SpawnParameterX = new Vector2(0, Raylib.GetScreenWidth());
		Vector2 enemie2SpawnParameterY = new Vector2(0, Raylib.GetScreenHeight());
		Vector2 enemie2SpawnPosition = new Vector2(random.Next((int)enemie2SpawnParameterX.X, (int)enemie2SpawnParameterX.Y), random.Next((int)enemie2SpawnParameterY.X, (int)enemie2SpawnParameterY.Y));
		List<Enemie> enemie2List = new List<Enemie>();


		// Loop until the window is closed
		while (!Raylib.WindowShouldClose())
		{
			// Update
			//----------------------------------------------------------------------------------------------------------------
			switch (currentScreen)
			{
				case GameScreen.LOGO: 
				{
					// TODO: Update LOGO screen variables here!

					framesCounter++; // Count frames

					// Wait for 2 seconds (120 frames) before jumping to TITLE screen
					if (framesCounter > 300)
					{
						currentScreen = GameScreen.TITLE;
						framesCounter = 0;
					}
					if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)) {currentScreen = GameScreen.TITLE;}
					
					break;
				}
				case GameScreen.TITLE: 
				{
					// TODO: Update TITLE screen variables here!

					//Program Controlls
					if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)) {currentScreen = GameScreen.GAMEPLAY;}
					if (Raylib.IsKeyPressed(KeyboardKey.KEY_L)) {currentScreen = GameScreen.LOGO;}

					break;
				}
				case GameScreen.GAMEPLAY: 
				{
					// TODO: Update Gameplay screen variables here!

					//Program Controlls
					if (Raylib.IsKeyPressed(KeyboardKey.KEY_L)) 
					{
						currentScreen = GameScreen.TITLE; 
						enemie1.existance = false;
					}
					
					// Player Controlls
					if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) {player.Y-=3f;}
    	    	    if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) {player.Y+=3f;}
            		if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) {player.X+=3f;}
            		if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) {player.X-=3f;}
					if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {playerRotation++;}
					if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {playerRotation--;}

					// Enemie1 Spawner
					if (Raylib.IsKeyDown(KeyboardKey.KEY_ONE)) 
					{
						enemie1.existance = true;
					}

					// Enemie2 spawner
					if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO)) 
					{
						enemie2List.Add(new Enemie(enemie2Rectangle, 0f, new Vector2(random.Next((int)enemie2SpawnParameterX.X, (int)enemie2SpawnParameterX.Y), random.Next((int)enemie2SpawnParameterY.X, (int)enemie2SpawnParameterY.Y)), enemie2SpawnParameterX, enemie2SpawnParameterY, 3, 1f));
					}

					// Enemie2 Updater
					for (int i = enemie2List.Count -1; i > -1; i--) 
					{
						enemie2List[i].HealthUpdate2();
						if (enemie2List[i].existance == false) {Console.WriteLine(enemie2List.Remove(enemie2List[i]));}
					}

					// Enemie1 Updater
					enemie1.HealthUpdate();
					
					break;
				}
			}

			//Draw
			//-------------------------------------------------------------------------------------------------------------------

			// Begin drawing to the window
			Raylib.BeginDrawing();

			// Clear the background to white
			Raylib.ClearBackground(Raylib.RAYWHITE);

			switch (currentScreen)
			{
				case GameScreen.LOGO: 
				{
					// TODO: Draw LOGO screen here!
					Raylib.DrawText("This is the logo screen which displays on bootup", 10, 80, 70f, Raylib.BLACK);
					break;
				}
				case GameScreen.TITLE: 
				{
					// TODO: Draw TITLE screen here!
					Raylib.DrawText("TITLE SCREEN", 10, 10, 100f, Raylib.BLACK);
					Raylib.DrawText("Press Enter to Play", 10, 130, 40f, Raylib.MAROON);
					Raylib.DrawText("Press L to return to the LOGO screen", 10, 180, 40f, Raylib.RED);
					break;
				}
				case GameScreen.GAMEPLAY: 
				{
					// TODO: Draw GAMEPLAY screen here!

					Raylib.DrawText("Press L to return to the TITLE screen", 10, 50, 40f, Raylib.MAROON);

					// Drawing player
					Raylib.DrawRectanglePro(player, playerOrigin, playerRotation, Raylib.BLACK);

					// Drawing enemie1
					if (enemie1.existance == true) {Raylib.DrawRectangle((int)enemie1.enemiePosition.X, (int)enemie1.enemiePosition.Y, (int)enemie1.enemieRectangle.Width, (int)enemie1.enemieRectangle.height, Raylib.PURPLE); enemie1.enemieHasBeenReset = false;}
					else if (enemie1.enemieHasBeenReset == false) {enemie1.EnemieReset();}

					// Drawing enemie2
					for (int i = 0; i < enemie2List.Count; i++)
						{
							Raylib.DrawRectangle((int)enemie2List[i].enemiePosition.X, (int)enemie2List[i].enemiePosition.Y, (int)enemie2List[i].enemieRectangle.Width, (int)enemie2List[i].enemieRectangle.Height, Raylib.RED);
						}

					break;
				}
				default: break;
			}

			// End drawing to the window
			Raylib.EndDrawing();
		}
		// Close the window
		//---------------------------------------------------------------------------------------------------------------------------
		Raylib.CloseWindow();
	}
}