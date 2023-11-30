using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
    internal class Enemy_Beetle : Enemy
    {
        public Enemy_Beetle(Vector2 pos) : base(pos)
        {

        }

        public override void LoadAnimations()
        {
            startSize.X = 960;
            startSize.Y = 1381;

            Animation idleAnim = new Animation(AnimationType.IDLE);
            idleAnim.AddTextureFrame(20,13056,960,1381,30);
            idleAnim.AddTextureFrame(1086, 13056, 960, 1381, 30);
            idleAnim.AddTextureFrame(2158, 13056, 960, 1381, 30);
            idleAnim.AddTextureFrame(3228, 13121, 959, 1316, 30);
            idleAnim.AddTextureFrame(4300, 13056, 960, 1381,30);
            idleAnim.AddTextureFrame(5372,13056,959,1381,30);
            animComponent?.AddAnimation(AnimationType.IDLE, idleAnim);

          

            animComponent?.SwitchAnimation(AnimationType.IDLE);

            base.LoadAnimations();
        }



    }
}
