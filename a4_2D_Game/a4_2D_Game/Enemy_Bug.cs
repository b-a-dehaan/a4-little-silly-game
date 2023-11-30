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
            startSize.X = 1248;
            startSize.Y = 1283;
            Animation idleAnim = new Animation(AnimationType.IDLE);
            idleAnim.AddTextureFrame(1, 14575, 1669, 962, 30);
            idleAnim.AddTextureFrame(1698, 14557, 1622, 982, 30);
            idleAnim.AddTextureFrame(3281, 14557, 1716, 982, 30);
            idleAnim.AddTextureFrame(4930, 14663, 1685, 906, 30);
            animComponent?.AddAnimation(AnimationType.IDLE, idleAnim);

            Animation moveAnim = new Animation(AnimationType.MOVE);
            moveAnim.AddTextureFrame(1, 14575, 1669, 962, 10);
            moveAnim.AddTextureFrame(1698, 14557, 1622, 982, 10);
            moveAnim.AddTextureFrame(3281, 14557, 1716, 982, 10);
            moveAnim.AddTextureFrame(4930, 14663, 1685, 906, 10);
            animComponent?.AddAnimation(AnimationType.MOVE, moveAnim);
            animComponent?.SwitchAnimation(AnimationType.IDLE);
            base.LoadAnimations();
        }
    }
}