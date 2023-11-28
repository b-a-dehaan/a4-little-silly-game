using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
    internal class ColorBackground: Object
    {

        public bool flipped = false;

        public ColorBackground(Vector2 pos) : base(pos)
        {

        }

        public override void Awake()
        {
            //Put any components you want to attach here

            base.Awake();
        }

        public override void Load()
        {
            name = "COLORBACKGROUND";

            //Image size of ground
            startSize.X = 345;
            startSize.Y = 188;
            //Load texture for spriteComponent
            spriteComponent.LoadSpriteTexture(S_TextureHandler.GetImage("background"));

            //Set source rectange if there is no animation component attached.
            if (flipped)
            {
                sourceRec = new Rectangle(559, 514, -(int)startSize.X, (int)startSize.Y);
            }
            else
            {
                sourceRec = new Rectangle(559, 514, (int)startSize.X, (int)startSize.Y);
            }

            //Set default values that may be important. Scale object here instead of changing size
            scale = new Vector2(6f, 6f);
            rotation = 0;


            base.Load();
        }
    }
}

