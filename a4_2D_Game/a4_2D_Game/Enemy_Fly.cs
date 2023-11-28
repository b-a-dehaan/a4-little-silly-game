using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
	internal class Enemy_Fly : Enemy
	{
		public Enemy_Fly(Vector2 pos) : base(pos)
		{

		}

		public override void LoadAnimations()
		{
			startSize.X = 1248;
			startSize.Y = 1283;

			Animation idleAnim = new Animation(AnimationType.IDLE);
			idleAnim.AddTextureFrame(19, 57, 1248, 1283, 30);
			idleAnim.AddTextureFrame(1244, 401, 1453, 955, 30);
			idleAnim.AddTextureFrame(2697, 551, 1372, 752, 30);
			animComponent?.AddAnimation(AnimationType.IDLE, idleAnim);

			Animation moveAnim = new Animation(AnimationType.MOVE);
			moveAnim.AddTextureFrame(19, 57, 1248, 1283, 10);
			moveAnim.AddTextureFrame(1244, 401, 1453, 955, 10);
			moveAnim.AddTextureFrame(2697, 551, 1372, 752, 10);
			animComponent?.AddAnimation(AnimationType.MOVE, moveAnim);

			animComponent?.SwitchAnimation(AnimationType.IDLE);

			base.LoadAnimations();
		}



	}
}
