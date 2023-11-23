using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
    internal class Bushes : Object
    {
        public Bushes(Vector2 pos) : base(pos)
        {

        }

        public override void Awake()
        {
            //Put any components you want to attach here

            base.Awake();
        }

        public override void Load()
        {
            name = "BUSHES";

            //Image size of ground
            startSize.X = 525;
            startSize.Y = 103;

            //Load texture for spriteComponent
            spriteComponent.LoadSpriteTexture(S_TextureHandler.GetImage("background"));

            //Set source rectange if there is no animation component attached.
            sourceRec = new Rectangle(28, 46, (int)startSize.X, (int)startSize.Y);

            //Set default values that may be important. Scale object here instead of changing size
            scale = new Vector2(2.7f, 2.7f);
            rotation = 0;


            base.Load();
        }
    }
}

