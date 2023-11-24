using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
	internal class C_Camera : Component
	{
		public static E_ComponentID id = E_ComponentID.C_CAMERA;

		public Vector2 offset = new Vector2();
		public Vector2 position = new Vector2();
		public float zoom = 1f;

		public C_Camera(Object parentObj) : base(id, parentObj)
		{
			
		}

		public override void Load()
		{
			offset = new Vector2(-Program.SCREEN_WIDTH * 0.5f, -Program.SCREEN_HEIGHT * 0.6f);
			position = GetParentObject().position + offset;
			
			base.Load();
		}

		public override void Update()
		{
			
			position = GetParentObject().position + offset;
			base.Update();
		}

		public Vector2 GetPosition()
		{
			return position;
		}


	}
}
