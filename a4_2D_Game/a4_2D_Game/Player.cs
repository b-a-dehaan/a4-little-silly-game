using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace a4_2D_Game
{
	internal class Player : Object
	{
		private Input playerInput;
		public Player(float posX, float posY, float sizeX, float sizeY, Input pInput) : base()
		{
			position.X = posX;
			position.Y = posY;
			size.X = sizeX;
			size.Y = sizeY;
			playerInput = pInput;
		}

		public override void Load()
		{
			canMove = true;
			base.Load();
		}

		public override void Update()
		{
			playerInput.Update();
			base.Update();
		}
		public override void Move()
		{
			if(playerInput.activeInputs[Input.E_Inputs.MOVELEFT])
			{
				curAcceleration.X = -ACCELERATION_RATE;
			}
			else if (playerInput.activeInputs[Input.E_Inputs.MOVERIGHT])
			{
				curAcceleration.X = ACCELERATION_RATE;
			}
			else if (velocity.X > 0.2f)
			{
				curAcceleration.X = FRICTION;
			}
			else if (velocity.X < -0.2f)
			{
				curAcceleration.X = -FRICTION;
			}
			else
			{
				curAcceleration.X = 0;
				velocity.X = 0f;
			}



			base.Move();
		}



		public override void Draw()
		{
			Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, Color.SKYBLUE);
			base.Draw();
		}

		

	}
}
