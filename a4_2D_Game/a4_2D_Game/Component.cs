using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{

	//The base class for all components. They will be attached to an object, but this class is abstract
	//and it will not be actually created.
	abstract class Component
	{
		Object parentObject;
		E_ComponentID id;
		public Component(E_ComponentID ID, Object parentObj)
		{
			parentObject = parentObj;
			id = ID;
		}
		public Object GetParentObject() { return parentObject; }
		public E_ComponentID GetId() { return id; }

		public virtual void Load()
		{
			
		}
		public virtual void Update()
		{

		}


	}
}
