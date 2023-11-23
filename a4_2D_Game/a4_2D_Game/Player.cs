using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace a4_2D_Game
{
	internal class Player : Object
	{
		Input playerInput;

		public Player(Vector2 pos) : base(pos)
		{
			playerInput = new Input();
		}
		public override void Awake()
		{
			//Put any components you want to attach here
			components.Add(new C_BoxCollision(this));

			base.Awake();
		}
		public override void Load()
		{
			//Copy this for your own objects and change the values as needed.

			name = "PLAYER";
			canMove = true;

			//Image size of player
			startSize.X = 690;
			startSize.Y = 1374;
			
			//Load texture for spriteComponent
			spriteComponent.LoadSpriteTexture(S_TextureHandler.GetImage("player"));

			//Add texture frames for animation here. The x,y coord of image on source picture and its width, height.
			//Only include if you have a spriteComponent
			spriteComponent.AddTextureFrame(0, 200, (int)startSize.X, (int)startSize.Y, 10);
			spriteComponent.AddTextureFrame(700, 200, (int)startSize.X, (int)startSize.Y, 10);
			spriteComponent.AddTextureFrame(1400, 200, (int)startSize.X, (int)startSize.Y, 10);
			spriteComponent.AddTextureFrame(2100, 200, (int)startSize.X, (int)startSize.Y, 10);
			spriteComponent.AddTextureFrame(2800, 200, (int)startSize.X, (int)startSize.Y, 10);
			spriteComponent.AddTextureFrame(3500, 200, (int)startSize.X, (int)startSize.Y, 10);

			//Set default values that may be important. Scale object here instead of changing size
			scale = new Vector2(0.1f, 0.1f);
			rotation = 0;

			base.Load();
		}

		public override void Update()
		{
			playerInput.Update();
			spriteComponent.GoToNextFrame();
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
			base.Draw();
		}

		public override void OnHit(Object otherObj)
		{
			if(otherObj.name == "GROUND")
			{
				falling = false;
				onGround = true;
				if (otherObj.components.Find(c => c.GetId() == E_ComponentID.C_BOXCOLLISION) is C_BoxCollision box)
				{
					nextPosition.Y = box.position.Y - scaledSize.Y;
				}
					
			}


			base.OnHit(otherObj);
		}


	}
}
