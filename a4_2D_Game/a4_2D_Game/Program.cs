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
			S_TextureHandler.LoadImage("platforms", "../../../resources/platforms.png");

		}

		//Loads all the objects in the game. Anything added here is "automatically" updated and drawn.
		static void LoadAllObjects()
		{
			//Add objects behind player here...

			int sizeX = 2070;
			int sizeX1 = 1613;
			int sizeX2 = 1484;
			int sizeX3 = 1588;
			int sizeX4 = 1482;
			int sizeX5 = 1417;

			for (int i = 0; i < 10; i++)
			{
                ColorBackground cb = new ColorBackground(new Vector2(sizeX * i - 290, -190));
                if (i % 2 == 1)
                {
                    cb.flipped = true;
                }
                else
                {
                    cb.flipped = false;
                }
                AddObject(cb, 1);

            }

            for (int i = 0; i < 10; i++)
			{
				Trees2 tr = new Trees2(new Vector2(sizeX1 * i - -113, 0));
                if (i % 2 == 1)
                {
                    tr.flipped = true;
                }
                else
                {
                    tr.flipped = false;
                }
                //AddObject(tr, 1);

            }

            for (int i = 0; i < 10; i++)
			{
				Trees te = new Trees(new Vector2(sizeX2 * i - 2, 5));
				if (i % 2 == 1)
				{
					te.flipped = true;
				}
				else
				{
					te.flipped = false;
				}
                AddObject(te, 1);

            }

            for (int i = 0; i < 10; i++)
			{
				Ground gr = new Ground(new Vector2(sizeX3 * i - 0, SCREEN_HEIGHT * 0.75f));
                if (i % 2 == 1)
				{
					gr.flipped = true;
				}
				else
				{
					gr.flipped = false;
				}
                AddObject(gr, 1);

            }

			//Add a player object on level 1. 500, 500 is the starting position.
			AddObject(new Player(new Vector2(500,500)), 1);

            for (int i = 0; i < 10; i++)
			{
				Lighting li = new Lighting(new Vector2(sizeX4 * i - 10, 0));
                if (i % 2 == 1)
				{
					li.flipped = true;
				}
				else
				{
					li.flipped = false;
				}
                AddObject(li, 1);

            }

            for (int i = 0; i < 10; i++)
			{
				Bushes bu = new Bushes(new Vector2(sizeX5 * i - 30, 615));
                if (i % 2 == 1)
				{
					bu.flipped = true;
				}
				else
				{
					bu.flipped = false;
				}
                AddObject(bu, 1);

            }

			AddObject(new Platforms(new Vector2(100, 500), 3),1);


			//Add other objects here...

			AddObject(new Enemy_Fly(new Vector2(600, 600)), 1);
			AddObject(new Enemy_Beetle(new Vector2(800, 600)), 1);
			AddObject(new Enemy_Slime(new Vector2(700, 650)), 1);
			AddObject(new Enemy_Bug(new Vector2(500, 650)), 1);

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
			Raylib.ClearBackground(Color.DARKGREEN);
			foreach (Object obj in currentObjects)
			{
				
				obj.Draw();

				if (obj.GetComponent(E_ComponentID.C_BOXCOLLISION) is C_BoxCollision box)
				{
					if (camera != null)
					{
						Raylib.DrawRectangleLines((int)box.position.X - (int)camera.GetPosition().X, (int)box.position.Y - (int)camera.GetPosition().Y, (int)box.size.X, (int)box.size.Y, Color.BLUE);
						Raylib.DrawCircle((int)obj.position.X - (int)camera.GetPosition().X, (int)obj.position.Y - (int)camera.GetPosition().Y, 10, Color.SKYBLUE);
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
			var ground = currentObjects.FindAll(p => p.name == "GROUND");

			foreach (var obj in ground)
			{
				if (player != null && obj != null && S_CollisionHandler.IsColliding(player, obj))
				{
					player.OnHit(obj);
					obj.OnHit(player);
				}
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