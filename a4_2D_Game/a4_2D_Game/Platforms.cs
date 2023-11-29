using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
    internal class Platforms : Object
    {
        public Platforms(Vector2 pos) : base(pos)
        {

        }

        public override void Awake()
        {
            //Put any components you want to attach here

            components.Add(new C_BoxCollision(this));

            base.Awake();
        }

        public override void Load()
        {
            name = "PLATFORMS";

            //Image size of ground
            startSize.X = 334;
            startSize.Y = 117;

            //Load texture for spriteComponent
            spriteComponent.LoadSpriteTexture(S_TextureHandler.GetImage("background"));

            //Set source rectange if there is no animation component attached.
            sourceRec = new Rectangle(91, 85, (int)startSize.X, (int)startSize.Y);

            //Set default values that may be important. Scale object here instead of changing size
            scale = new Vector2(2f, 2f);
            rotation = 0;

            if (GetComponent(E_ComponentID.C_BOXCOLLISION) is C_BoxCollision box)
            {
                box.AddOffset(new Vector2(0, 50));
                box.ChangeSize(new Vector2(0, -50));
            }

            base.Load();
        }
    }
}
