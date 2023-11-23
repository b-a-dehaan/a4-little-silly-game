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

		public Camera2D camera;
		
		public float zoom = 1f;

		public C_Camera(Object parentObj) : base(id, parentObj)
		{
			
		}

		public override void Load()
		{
			camera.Offset = new Vector2(0, -300);
			camera.Target = GetParentObject().position;
			camera.Zoom = zoom;
			
			base.Load();
		}

		public override void Update()
		{
			camera.Target = GetParentObject().position;
			base.Update();
		}

	}
}
