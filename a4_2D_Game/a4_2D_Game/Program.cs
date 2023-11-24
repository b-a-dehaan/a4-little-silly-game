using Raylib_cs;
using System.Numerics;

namespace a4_2D_Game
{

	//Use this to give a component an ID. Add more here...
	public enum E_ComponentID
	{
		C_DEFAULT = 0,
		C_BOXCOLLISION = 1,
		C_SPHERECOLLISION = 2,
		C_SPRITE = 3,
		C_ANIMATION = 4,
		C_CAMERA = 5
	}

	internal class Program
	{
		static int curLevel = 1;

		static bool endGame = false;

		//Dictionary stores a list of objects for each level. You can use the level to get the objects
		//for that level using allObjects[level]. 
		static Dictionary<int, List<Object>> allObjects = new Dictionary<int, List<Object>>();
		static List<Object> currentObjects = new List<Object>();

		public const int SCREEN_WIDTH = 1600;
		public const int SCREEN_HEIGHT = 900;

		static public C_Camera? camera;

		static void Main(string[] args)
		{
			LoadWindow();
			LoadImages();
			LoadAllObjects();
			LoadLevel(1);

			while (!Raylib.WindowShouldClose() && !endGame)
			{
				Update();
				Raylib.BeginDrawing();
				Draw();
				Raylib.EndDrawing();
				LateUpdate();
			}

			CleanUp();

			Raylib.CloseWindow();
		}

		


		//Load any initial values for the window and game. Don't load objects here!
		static void LoadWindow()
		{
			Raylib.InitWindow(SCREEN_WIDTH,SCREEN_HEIGHT, "Silly Little Game");
			Raylib.SetTargetFPS(60);
		}
		
		//Loads the images used in the game.
		private static void LoadImages()
		{
			//All the images go here. They need a name and the filepath.
			//Put .png files in the resources folder and use 3 ../ 's when writing filepath.
			S_TextureHandler.LoadImage("player", "../../../resources/playersprites.png");
			S_TextureHandler.LoadImage("enemy", "../../../resources/enemysprites.png");

			S_TextureHandler.LoadImage("background", "../../../resources/silly-sprite-good-copy.png");

		}

		//Loads all the objects in the game. Anything added here is "automatically" updated and drawn.
		static void LoadAllObjects()
		{
            //Add objects behind player here...
            AddObject(new ColorBackground(new Vector2(-290, -190)), 1);

            AddObject(new Trees2(new Vector2(-113, 0)), 1);

            AddObject(new Trees(new Vector2(2, 5)), 1);

            AddObject(new Ground(new Vector2(0, SCREEN_HEIGHT * 0.8f)), 1);

			//Add a player object on level 1. 500, 500 is the starting position.
			AddObject(new Player(new Vector2(500,500)), 1);

            AddObject(new Lighting(new Vector2(10, 0)), 1);

            AddObject(new Bushes(new Vector2(30, 615)), 1);
			//Add other objects here...




			AddObject(new Enemy_Fly(new Vector2(600, 600)), 1);
        }


		//Load a specific level and all the objects associated with it.
		static void LoadLevel(int level)
		{
			if(!allObjects.ContainsKey(level))
			{
				WriteError($"Failed to find level {level}");
			}
			currentObjects = allObjects[level];

			foreach (Object obj in currentObjects)
			{
				obj.Awake();
				obj.Load();

				if(obj.GetComponent(E_ComponentID.C_CAMERA) is C_Camera c)
				{
					camera = c;
				}
			}
			
			
			curLevel = level;
		}

		//Update all objects in the current level.
		static void Update()
		{
			foreach (Object obj in currentObjects)
			{
				
				obj.Update();
				
				if (camera != null)
				{
					obj.SetTargetRect(obj.position - camera.position, obj.scaledSize);
				}
				
			}
			HandleCollision();
		}

		//Updates each object after drawing is done.
		static void LateUpdate()
		{
			foreach (Object obj in currentObjects)
			{
				obj.LateUpdate();
			}
		}

		//Draw all objects in the current level.
		static void Draw()
		{
			Raylib.ClearBackground(Color.WHITE);
			foreach (Object obj in currentObjects)
			{
				
				obj.Draw();

				if (obj.GetComponent(E_ComponentID.C_BOXCOLLISION) is C_BoxCollision box)
				{
					if (camera != null)
					{
						Raylib.DrawRectangleLines((int)box.position.X - (int)camera.GetPosition().X, (int)box.position.Y - (int)camera.GetPosition().Y, (int)box.size.X, (int)box.size.Y, Color.BLUE);
					}
				}

			}
		}

		//Write an error messsage to the console window as needed.
		public static void WriteError(string msg)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(msg);
			Console.ForegroundColor = ConsoleColor.White;
		}

		//Add an object to a specific level that will always be loaded in that level.
		static void AddObject(Object obj, int level)
		{
			if(!allObjects.ContainsKey(level))
			{
				allObjects.Add(level, new List<Object>());
			}
			allObjects[level].Add(obj);
		}
		//Adds a temporary object to the screen that disappears if the level is reloaded.
		static void AddObject(Object obj)
		{
			currentObjects.Add(obj);
		}

		//Removes an object from the current level. If the level is reloaded, the object will come back.
		static void RemoveObject(Object obj)
		{
			currentObjects.Remove(obj);
		}

		//Handles specific collision between objects 
		static void HandleCollision()
		{
			Object? player = currentObjects.Find(p => p.name == "PLAYER");
			Object? ground = currentObjects.Find(p => p.name == "GROUND");

			if (player != null && ground != null && S_CollisionHandler.IsColliding(player, ground))
			{
				player.OnHit(ground);
				ground.OnHit(player);
			}
			
			//Loop all platforms the player can collide with here and change position based on next position


		}

		//Cleans up before exiting
		private static void CleanUp()
		{
			currentObjects.Clear();
			allObjects.Clear();
			S_TextureHandler.UnloadAll();
		}


	}

}