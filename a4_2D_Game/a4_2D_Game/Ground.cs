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

<<<<<<< Updated upstream
			components.Add(new C_BoxCollision(this));
=======
			//Set source rectange if there is no animation component attached.
			sourceRec = new Rectangle(20, 721, (int)startSize.X, (int)startSize.Y);

			//Set default values that may be important. Scale object here instead of changing size
			scale = new Vector2(2f, 2f);
			rotation = 0;

			if (GetComponent(E_ComponentID.C_BOXCOLLISION) is C_BoxCollision box)
			{
				box.AddOffset(new Vector2(0, 100));
				box.ChangeSize(new Vector2(0, -100));
			}
>>>>>>> Stashed changes

			base.Load();
		}
		public override void Draw()
		{
			Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, Color.GREEN);

			base.Draw();
		}




	}
}
