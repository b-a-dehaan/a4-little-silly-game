using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace a4_2D_Game
{
    internal class Enemy_Slime : Enemy
    {
        public Enemy_Slime(Vector2 pos) : base(pos)
        {
        }
        public override void LoadAnimations()
        {
            startSize.X = 948;
            startSize.Y = 855;
            Animation idleAnim = new Animation(AnimationType.IDLE);
            idleAnim.AddTextureFrame(1, 1609, 948, 855, 30);
            idleAnim.AddTextureFrame(1095, 1491, 1059, 973, 30);
            idleAnim.AddTextureFrame(2298, 1636, 934, 828, 30);
            idleAnim.AddTextureFrame(3377, 1502, 1047, 962, 30);
            animComponent?.AddAnimation(AnimationType.IDLE, idleAnim);
            animComponent?.SwitchAnimation(AnimationType.IDLE);
            base.LoadAnimations();
        }
    }
}