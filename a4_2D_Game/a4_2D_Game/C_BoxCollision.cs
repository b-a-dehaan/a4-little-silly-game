using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{


	//The C_ means that it is a component and will be attached to an object
	internal class C_BoxCollision : Component
	{
		public Vector2 position;
		public Vector2 offset = new Vector2(0, 0);
		public Vector2 size;

		static E_ComponentID ID = E_ComponentID.C_BOXCOLLISION; //This is true for all Box colliders so static
		public C_BoxCollision(Object parentObj) : base(ID, parentObj)
		{

		}

		public override void Load()
		{
			position = GetParentObject().nextPosition + offset - GetParentObject().origin;
			size = GetParentObject().scaledSize;

			base.Load();
		}

		public override void Update()
		{
			if(GetParentObject().canMove)
			{
				position = GetParentObject().nextPosition + offset - GetParentObject().origin;
			}
			
			base.Update();
		}

		public void ChangeSize(Vector2 s)
		{
			size += s;
		}
		public void AddOffset(Vector2 off)
		{
			offset += off;
		}

	}
}
