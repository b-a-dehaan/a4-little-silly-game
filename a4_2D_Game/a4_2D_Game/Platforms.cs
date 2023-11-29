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
        Rectangle sourceRecLeft, sourceRecMid, sourceRecRight;
        int numMidBlocks = 1;
        public Platforms(Vector2 pos, int numBlocks = 1) : base(pos)
        {
            numMidBlocks = numBlocks;
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
            startSize.X = 32;
            startSize.Y = 32;

            //Load texture for spriteComponent
            spriteComponent.LoadSpriteTexture(S_TextureHandler.GetImage("platforms"));

            //Set source rectange if there is no animation component attached.
            sourceRecLeft = new Rectangle(0, 32, 32, 32);
			sourceRecMid = new Rectangle(32, 32, 32, 32);
			sourceRecRight = new Rectangle(64, 32, 32, 32);

			//Set default values that may be important. Scale object here instead of changing size
			scale = new Vector2(4f, 4f);
            rotation = 0;

            if (GetComponent(E_ComponentID.C_BOXCOLLISION) is C_BoxCollision box)
            {
                box.AddOffset(new Vector2(0, 50));
                box.ChangeSize(new Vector2(32 * (numMidBlocks + 2), -25));
            }

            base.Load();
        }

        public override void Draw() 
        {
			if (spriteComponent != null && isVisible)
			{
				Raylib.DrawTexturePro(spriteComponent.texture, sourceRecLeft, targetRec, origin, rotation, Color.WHITE);

                for(int i = 0; i < numMidBlocks; i++)
                {
                    targetRec.X += targetRec.Width;
					Raylib.DrawTexturePro(spriteComponent.texture, sourceRecMid, targetRec, origin, rotation, Color.WHITE);
				}
                targetRec.X += targetRec.Width;
				Raylib.DrawTexturePro(spriteComponent.texture, sourceRecRight, targetRec, origin, rotation, Color.WHITE);

			}

		}
    }
}
