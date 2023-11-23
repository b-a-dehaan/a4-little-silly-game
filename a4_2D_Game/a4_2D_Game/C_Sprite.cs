using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace a4_2D_Game
{
	internal class C_Sprite : Component
	{
		static E_ComponentID ID = E_ComponentID.C_SPRITE;
		public Texture2D texture;
		
		public C_Sprite(Object parentObj) :base (ID,parentObj)
		{
			
		}

		public void LoadSpriteTexture(Image sourceImage)
		{
			texture = Raylib.LoadTextureFromImage(sourceImage);
		}
	}
}
