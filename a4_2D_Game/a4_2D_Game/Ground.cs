using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
	internal class Ground : Object
	{
		public Ground()
		{
			
		}
		public override void Load()
		{
			name = "GROUND";
			position = new Vector2(0, Raylib.GetScreenHeight() * 0.9f);
			size = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight() * 0.1f);

			components.Add(new C_BoxCollision(this));

			base.Load();
		}
		public override void Draw()
		{
			Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, Color.GREEN);

			base.Draw();
		}




	}
}
