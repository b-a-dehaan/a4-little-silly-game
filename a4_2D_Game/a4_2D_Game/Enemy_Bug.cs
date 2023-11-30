using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace a4_2D_Game
{
    internal class Enemy_Bug : Enemy
    {
        public Enemy_Bug(Vector2 pos) : base(pos)
        {
        }
        public override void LoadAnimations()
        {
            startSize.X = 1465;
            startSize.Y = 877;
            Animation idleAnim = new Animation(AnimationType.IDLE);
            idleAnim.AddTextureFrame(54, 13249, 1465, 877, 10);
            idleAnim.AddTextureFrame(1544,13232, 1474, 894, 10);
            idleAnim.AddTextureFrame(2982, 13250, 1561, 876, 10);
            idleAnim.AddTextureFrame(4481, 13303, 1533, 823, 10);
            animComponent?.AddAnimation(AnimationType.IDLE, idleAnim);

            base.LoadAnimations();
        }
    }
}