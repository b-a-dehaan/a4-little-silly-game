using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
	//Component class for handeling animation on objects. Different from Animation class.
	internal class C_Animation : Component
	{
		static E_ComponentID id = E_ComponentID.C_ANIMATION;
		//Dictionary list of animations, sorted by type.
		public Dictionary<AnimationType, Animation> animations = new Dictionary<AnimationType, Animation>();

		public Animation curAnimation = new Animation(AnimationType.NONE);
		public Frame curFrame;
		public int curFrameNum = 0;
		public int curInterval = 0;

		public C_Animation(Object parentObj) : base(id, parentObj)
		{

		}
		public override void Update()
		{
			GoToNextFrame();
			base.Update();
		}
		public void AddAnimation(AnimationType aType, Animation a)
		{
			animations.Add(aType, a);
		}
		public void SwitchAnimation(AnimationType aType)
		{
			if (animations.TryGetValue(aType, out Animation? curAnim))
			{
				curAnimation = curAnim;
				curFrameNum = 0;
				curFrame = curAnimation.frames[0];
				curInterval = 0;
			}
			else
			{
				Program.WriteError($"Animation {aType} does not exist for {this.GetParentObject().name}.");
			}
		}
		public void GoToNextFrame()
		{
			if (curInterval > curFrame.interval && curAnimation.frames.Count > 0)
			{
				curFrameNum = curFrameNum < curAnimation.frames.Count - 1 ? curFrameNum + 1 : 0;
				curFrame = curAnimation.frames[curFrameNum];
				curInterval = 0;
			}
			else
			{
				curInterval++;
			}

		}
		public Rectangle GetFrameRectangle(bool reversed)
		{
			if (reversed)
			{
				return new Rectangle(curFrame.x, curFrame.y, -curFrame.width, curFrame.height);
			}
			else
			{
				return new Rectangle(curFrame.x, curFrame.y, curFrame.width, curFrame.height);
			}
		}
	}

}
