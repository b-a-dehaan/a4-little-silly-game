﻿using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace a4_2D_Game
{
	internal class Player : Object
	{
		Input playerInput;
		C_Animation? animComponent;
		C_Camera? camera;
		bool movingLeft = false;

		

		public Player(Vector2 pos) : base(pos)
		{
			playerInput = new Input();
		}
		public override void Awake()
		{
			//Put any components you want to attach here
			components.Add(new C_BoxCollision(this));

			animComponent = new C_Animation(this);
			components.Add(animComponent);

			camera = new C_Camera(this);
			components.Add(camera);

			base.Awake();
		}
		public override void Load()
		{
			//Copy this for your own objects and change the values as needed.

			name = "PLAYER";
			canMove = true;

			//Load texture for spriteComponent
			spriteComponent?.LoadSpriteTexture(S_TextureHandler.GetImage("player"));

			LoadAnimations();
			

			//Set default values that may be important. Scale object here instead of changing size
			scale = new Vector2(0.1f, 0.1f);
			rotation = 0;
			movingLeft = false;
			onGround = false;
			falling = true;
			base.Load();
		}

		private void LoadAnimations()
		{
			//Add texture frames for animation here. The x,y coord of image on source picture and its width, height.
			//Only include if you have a animComponent

			//Image size of player
			startSize.X = 690;
			startSize.Y = 1373;
			//IDLE Animations
			Animation idleAnim = new Animation(AnimationType.IDLE);
			idleAnim.AddTextureFrame(0, 200, 690, 1373, 10);
			idleAnim.AddTextureFrame(695, 220, 690, 1353, 10);
			idleAnim.AddTextureFrame(1390, 259, 690, 1314, 10);
			idleAnim.AddTextureFrame(2085, 230, 690, 1343, 10);
			idleAnim.AddTextureFrame(2775, 220, 690, 1353, 10);
			idleAnim.AddTextureFrame(3470, 200, 690, 1373, 10);
			animComponent?.AddAnimation(AnimationType.IDLE, idleAnim);

			//MOVE Animations
			Animation moveAnim = new Animation(AnimationType.MOVE);
			moveAnim.AddTextureFrame(0, 3118, 749, 1287, 2);
			moveAnim.AddTextureFrame(812, 3155, 719, 1250, 2);
			moveAnim.AddTextureFrame(1551, 3154, 709, 1244, 2);
			moveAnim.AddTextureFrame(2319, 3120, 648, 1278, 2);
			moveAnim.AddTextureFrame(3026, 3057, 708, 1348, 2);
			moveAnim.AddTextureFrame(3792, 3056, 724, 1229, 2);
			moveAnim.AddTextureFrame(4574, 3118, 708, 1281, 2);
			moveAnim.AddTextureFrame(5342, 3135, 741, 1250, 2);
			moveAnim.AddTextureFrame(6143, 3141, 709, 1244, 2);
			moveAnim.AddTextureFrame(18, 4643, 648, 1278, 2);
			moveAnim.AddTextureFrame(667, 4572, 707, 1349, 2);
			moveAnim.AddTextureFrame(1448, 4572, 723, 1229, 2);
			animComponent?.AddAnimation(AnimationType.MOVE, moveAnim);

			//JUMP ANIMATION
			Animation jumpAnim = new Animation(AnimationType.JUMP);
			jumpAnim.AddTextureFrame(0, 1834, 561,1222, 10);
            jumpAnim.AddTextureFrame(695, 1667, 662, 1389, 10);
            jumpAnim.AddTextureFrame(1491, 1667, 631, 1135, 10);
			jumpAnim.loopAnim = false;
			animComponent?.AddAnimation(AnimationType.JUMP, jumpAnim);

			//FALL ANIMATION
			Animation fallAnim = new Animation(AnimationType.FALL);
			fallAnim.AddTextureFrame(1491, 1667, 631, 1135, 5);
			fallAnim.loopAnim= false;
			animComponent?.AddAnimation(AnimationType.FALL, fallAnim);

			//HURT ANIMATION
			Animation hurtAnim = new Animation(AnimationType.HURT);


            animComponent?.SwitchAnimation(AnimationType.IDLE);
			
		}

		public override void Update()
		{
			playerInput.Update();
			UpdateAnimation();

			if(camera != null)
			{
				camera.position = position;
			}
			

			base.Update();
		}
		public override void Move()
		{
			if (playerInput.activeInputs[Input.E_Inputs.MOVELEFT])
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

			if (playerInput.activeInputs[Input.E_Inputs.JUMP] && onGround && jumpTimer >=0 && timeSinceLastJump > JUMPDELAY)
			{
				onGround = false;
				falling = false;
				timeSinceLastJump = 0;
			}
			else if(!onGround && jumpTimer >= 20)
			{
				falling = true;
			}
			else if(onGround == true)
			{
				jumpTimer = 0;
				timeSinceLastJump += 1;
			}
			else
			{
				jumpTimer += 1;
			}

				base.Move();
		}

		public void UpdateAnimation()
		{

			if (curAcceleration.X > 20f)
			{
				movingLeft = false;
			}
			else if (curAcceleration.X < -20f)
			{
				movingLeft = true;
			}


			if (!onGround && !falling)
			{
				if (animComponent?.curAnimation.animType != AnimationType.JUMP)
				{
					animComponent?.SwitchAnimation(AnimationType.JUMP);
				}
			}
			else if(!onGround && falling)
			{
				if (animComponent?.curAnimation.animType != AnimationType.FALL)
				{
					animComponent?.SwitchAnimation(AnimationType.FALL);
				}
			}
			else if(Math.Abs(curAcceleration.X) > 20)
			{
				if (animComponent?.curAnimation.animType != AnimationType.MOVE)
				{
					animComponent?.SwitchAnimation(AnimationType.MOVE);
				}
			}
			else
			{
				if (animComponent?.curAnimation.animType != AnimationType.IDLE)
				{
					animComponent?.SwitchAnimation(AnimationType.IDLE);
				}
			}
			
			
			
			if(animComponent != null)
			{
				sourceRec = animComponent.GetFrameRectangle(movingLeft);
			}

			//startSize = new Vector2(Math.Abs(sourceRec.Width), sourceRec.Height);
			//scaledSize = startSize * scale;

		}

		public override void OnHit(Object otherObj)
		{
			if(otherObj.name == "GROUND")
			{
				falling = false;
				onGround = true;
				if (otherObj.GetComponent(E_ComponentID.C_BOXCOLLISION) is C_BoxCollision box)
				{
					nextPosition.Y = box.position.Y - scaledSize.Y;
				}
					
			}


			base.OnHit(otherObj);
		}


	}
}
