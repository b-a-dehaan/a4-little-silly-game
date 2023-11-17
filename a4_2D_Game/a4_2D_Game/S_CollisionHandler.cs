using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
	//This class is a system (S_) and it handles collision between any two objects with collision components
	internal static class S_CollisionHandler
	{
		public static bool IsColliding(Object obj1, Object obj2)
		{
			if (!obj1.HasComponent(E_ComponentID.C_BOXCOLLISION) || !obj2.HasComponent(E_ComponentID.C_BOXCOLLISION)) return false;

			List<Component> componentList1 = obj1.components.FindAll(c => c.GetId() == E_ComponentID.C_BOXCOLLISION);
			List<Component> componentList2 = obj2.components.FindAll(c => c.GetId() == E_ComponentID.C_BOXCOLLISION);

			foreach(var c1 in componentList1)
			{
				foreach (var c2 in componentList2)
				{
					if(CheckCollision((C_BoxCollision)c1, (C_BoxCollision)c2))
					{
						return true;
					}

				}
			}

			return false;

		}
		private static bool CheckCollision(C_BoxCollision c1, C_BoxCollision c2)
		{
			Rectangle rect1 = new Rectangle((int)c1.position.X, (int)c1.position.Y, (int)c1.size.X, (int)c1.size.Y);
			Rectangle rect2 = new Rectangle((int)c2.position.X, (int)c2.position.Y, (int)c2.size.X, (int)c2.size.Y);

			return rect1.IntersectsWith(rect2);
		}



	}
}
