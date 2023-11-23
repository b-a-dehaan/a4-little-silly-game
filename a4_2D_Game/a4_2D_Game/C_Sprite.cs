using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace a4_2D_Game
{
	public struct Frame
	{
		public Frame(int x, int y, int width, int height, float interval)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
			this.interval = interval;
		}
		public int x { get; }
		public int y { get; }
		public int width { get; }
		public int height { get; }
		public float interval { get; }
	}


	internal class C_Sprite : Component
	{
		static E_ComponentID ID = E_ComponentID.C_SPRITE;

		public List<Frame> frames = new List<Frame>();
		public Texture2D texture;
		public Frame curFrame;
		public int curFrameNum = 0;
		public int curInterval = 0;

		public C_Sprite(Object parentObj) :base (ID,parentObj)
		{
			
		}

		public override void Load()
		{
			base.Load();
		}

		public void LoadSpriteTexture(Image sourceImage)
		{
			texture = Raylib.LoadTextureFromImage(sourceImage);
			
		}

		public void GoToNextFrame()
		{
			if(curInterval > curFrame.interval)
			{
				curFrameNum = curFrameNum < frames.Count - 1 ? curFrameNum + 1 : 0;
				curFrame = frames[curFrameNum];
				curInterval = 0;
			}
			else
			{
				curInterval++;
			}
			
		}

		//Adds a new frame to the frame list component
		public void AddTextureFrame(int sourceX, int sourceY, int sourceWidth, int sourceHeight, float interval)
		{
			frames.Add(new Frame(sourceX, sourceY, sourceWidth, sourceHeight, interval));
			curFrame = frames[0];
		}

		public Rectangle GetFrameRectangle()
		{
			return new Rectangle(curFrame.x, curFrame.y, curFrame.width, curFrame.height);
		}


	}
}
