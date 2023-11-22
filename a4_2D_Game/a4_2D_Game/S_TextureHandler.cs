using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
	internal static class S_TextureHandler
	{

		static Dictionary<string, Image> nameKeyToPathValue = new Dictionary<string, Image>();
		
		public static void LoadImage(string nameOfImage, string texturePath)
		{
			if(nameKeyToPathValue.ContainsKey(nameOfImage))
			{
				Program.WriteError($"Texture {nameOfImage} has already been loaded.");
				return;
			}

			

			nameKeyToPathValue[nameOfImage] = Raylib.LoadImage(texturePath);
		}

		public static void UnloadImage(string nameOfImage)
		{
			if (nameKeyToPathValue.ContainsKey(nameOfImage))
			{
				Raylib.UnloadImage(nameKeyToPathValue[nameOfImage]);
			}
			else
			{
				Program.WriteError($"Texture {nameOfImage} is not loaded and cannot be unloaded.");
			}
		}

		public static Image GetImage(string nameOfImage)
		{

			if (!nameKeyToPathValue.ContainsKey(nameOfImage))
			{
				Program.WriteError($"Texture {nameOfImage} does not exist.");

				return new Image();
			}

			return nameKeyToPathValue[nameOfImage];
		}

		public static void UnloadAll()
		{
			foreach (Image i in nameKeyToPathValue.Values)
			{
				Raylib.UnloadImage(i);
			}

			nameKeyToPathValue.Clear();
		}

	}
}
