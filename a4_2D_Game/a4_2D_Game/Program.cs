using Raylib_cs;

namespace a4_2D_Game
{
	internal class Program
	{
		static int curLevel = 1;

		static bool endGame = false;

		//Dictionary stores a list of objects for each level. You can use the level to get the objects
		//for that level using allObjects[level]. 
		static Dictionary<int, List<Object>> allObjects = new Dictionary<int, List<Object>>();
		static List<Object> currentObjects = new List<Object>();


		static void Main(string[] args)
		{
			LoadWindow();
			LoadAllObjects();
			LoadLevel(1);

			while (!Raylib.WindowShouldClose() && !endGame)
			{
				Update();
				Raylib.BeginDrawing();
				Draw();
				Raylib.EndDrawing();
			}
			Raylib.CloseWindow();
		}

		//Load any initial values for the window and game. Don't load objects here!
		static void LoadWindow()
		{
			Raylib.InitWindow(Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), "Silly Little Game");
			Raylib.SetTargetFPS(60);
		}

		//Loads all the objects in the game. Anything added here is "automatically" updated and drawn.
		static void LoadAllObjects()
		{
			//Add a player object on level 1. Other objects wont need input stuff.
			AddObject(new Player(500, 500, 100, 100, new Input()), 1); //Player has position.X, position.Y, size.X, size.Y, and Input class as parameters
				
			//Add other objects here...





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
				obj.Load();
			}
			
			curLevel = level;
		}

		//Update all objects in the current level.
		static void Update()
		{
			foreach (Object obj in currentObjects)
			{
				obj.Update();
			}
		}

		//Draw all objects in the current level.
		static void Draw()
		{
			Raylib.ClearBackground(Color.WHITE);
			foreach (Object obj in currentObjects)
			{
				obj.Draw();
			}
		}

		//Write an error messsage to the console window as needed.
		static void WriteError(string msg)
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

	}
}