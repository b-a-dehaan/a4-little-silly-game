using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
	internal class Enemy : Object
	{

		public C_Animation? animComponent;
		bool movingLeft = false;
		public Enemy(Vector2 pos) : base(pos)
		{

		}
		public override void Awake()
		{
			//Put any components you want to attach here
			components.Add(new C_BoxCollision(this));

			animComponent = new C_Animation(this);
			components.Add(animComponent);

			base.Awake();
		}
		public override void Load()
		{
			//Copy this for your own objects and change the values as needed.

			name = "ENEMY";
			canMove = true;
			onGround = true;

			//Load texture for spriteComponent
			spriteComponent?.LoadSpriteTexture(S_TextureHandler.GetImage("enemy"));

			LoadAnimations();


			//Set default values that may be important. Scale object here instead of changing size
			scale = new Vector2(0.1f, 0.1f);
			rotation = 0;

			base.Load();
		}

		public virtual void LoadAnimations()
		{
			//Add texture frames for animation here. The x,y coord of image on source picture and its width, height.
			//Only include if you have a animComponent

			
		}
		public override void Update()
		{
			UpdateAnimation();

			base.Update();
		}

		public virtual void UpdateAnimation()
		{
			movingLeft = false;
			if (curAcceleration.X > 20f)
			{
				movingLeft = false;
				if (animComponent?.curAnimation.animType != AnimationType.MOVE)
				{
					animComponent?.SwitchAnimation(AnimationType.MOVE);
				}
			}
			else if (curAcceleration.X < -20f)
			{
				movingLeft = true;
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

			if (animComponent != null)
			{
				sourceRec = animComponent.GetFrameRectangle(movingLeft);
			}

			startSize = new Vector2(Math.Abs(sourceRec.Width), sourceRec.Height);
			scaledSize = startSize * scale;
		}

		public override void OnHit(Object otherObj)
		{
			if (otherObj.name == "GROUND")
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
