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
            startSize.X = 1045;
            startSize.Y = 1941;

            Animation idleAnim = new Animation(AnimationType.IDLE);
            idleAnim.AddTextureFrame(0, 1768, 1045, 1941, 30);
            idleAnim.AddTextureFrame(1205, 1640, 1164, 1069, 30);
            idleAnim.AddTextureFrame(2529,1800,1026,909,30);
            idleAnim.AddTextureFrame(3715, 1652, 1152, 1057, 30);
            animComponent?.AddAnimation(AnimationType.IDLE, idleAnim);

            animComponent?.SwitchAnimation(AnimationType.IDLE);

            base.LoadAnimations();
        }



    }
}
