using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
	//Animation class has a name and list of frames. Basically just data.
	internal class Animation
	{
		public List<Frame> frames = new List<Frame>();
		public AnimationType animType = AnimationType.NONE;
		public Animation(AnimationType aType)
		{
			animType = aType;
		}

		public void AddTextureFrame(int sourceX, int sourceY, int sourceWidth, int sourceHeight, float interval)
		{
			frames.Add(new Frame(sourceX, sourceY, sourceWidth, sourceHeight, interval));
		}

	}

	//Frame structure for storing info about frames
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

	//Add animation types here
	public enum AnimationType
	{
		NONE = 0,
		IDLE = 1,
		MOVE = 2,
		JUMP = 3,
		FALL = 4
	}

}
