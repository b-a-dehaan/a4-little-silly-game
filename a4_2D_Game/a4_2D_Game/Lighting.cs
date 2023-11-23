using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
    internal class Lighting : Object
    {
        public Lighting(Vector2 pos) : base(pos)
        {

        }

        public override void Awake()
        {
            //Put any components you want to attach here

            base.Awake();
        }

        public override void Load()
        {
            name = "LIGHTING";

            //Image size of ground
            startSize.X = 285;
            startSize.Y = 165;

            //Load texture for spriteComponent
            spriteComponent.LoadSpriteTexture(S_TextureHandler.GetImage("background"));

            //Set source rectange if there is no animation component attached.
            sourceRec = new Rectangle(604, 331, (int)startSize.X, (int)startSize.Y);

            //Set default values that may be important. Scale object here instead of changing size
            scale = new Vector2(5.2f, 5.2f);
            rotation = 0;


            base.Load();
        }
    }
}

