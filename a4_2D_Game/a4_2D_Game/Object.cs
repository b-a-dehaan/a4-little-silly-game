using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace a4_2D_Game
{

	//This class is the parent class for all objects in the game.
	//No instances of this class will be created because there are no actual "Object" objects in the game.
	//Each child class extends Object and inherits all of its values and subroutines.

	//Use 'class ChildClassName : Object' to create a new class that inherits from object.
	//Everything drawn on the screen should inherit from object.

	//Use the override keyword to use the non default subroutines for the object.
	//See player class for example.

	internal class Object
	{
		
		public List<Component> components = new List<Component>();
		public C_Sprite? spriteComponent;
		public Rectangle sourceRec = new Rectangle(0, 0, 0, 0);
		public Rectangle targetRec = new Rectangle(0,0,0,0);

		public Vector2 position = new Vector2(0,0);
		public Vector2 nextPosition = new Vector2(0,0);
		public Vector2 startSize = new Vector2(0, 0);
		public Vector2 scaledSize = new Vector2(0, 0);
		public Vector2 scale = new Vector2(1, 1);
		public Vector2 origin = new Vector2(0,0);
		public Vector2 velocity = new Vector2(0, 0);
		public Vector2 curAcceleration;
		public float rotation = 0;

		public const float MAXVELOCITY = 250.0f;
		public const float ACCELERATION_RATE = 50;
		public const float GRAVITY = 9.8f;
		public const float FRICTION = -20f;

		public bool canMove = false; //If the object can move or is static.
		public bool falling = false; //If the object is currently falling.
		public bool onGround = false; //If the object is currently on the ground. This is different than falling.
		public bool isVisible = true; //Should the object be drawn on the screen? Call this in inherited draw method.
		public bool startedColliding = false;

		public string name = "";

		public Object(Vector2 pos)
		{
			position = pos;
		}

		//Happens before loading. Declare components here.
		public virtual void Awake()
		{
			//All objects have a sprite component
			spriteComponent = new C_Sprite(this);
			components.Add(spriteComponent);
		}
		public virtual void Load()
		{
			isVisible = true;
			nextPosition = position;
			scaledSize = startSize * scale;

			//Load components added in the child class's load method (i.e. player) 
			foreach (var component in components)
			{
				component.Load();
			}
		}
		public virtual void Update()
		{
			if (canMove) Move();
			//Update existing components
			
			foreach (var component in components)
			{
				component.Update();
			}
		}

		public virtual void LateUpdate()
		{
			position = nextPosition;
		}
		
		public virtual void Draw()
		{
			
			if(spriteComponent != null && isVisible)
			{
				Raylib.DrawTexturePro(spriteComponent.texture, sourceRec, targetRec, origin, rotation, Color.WHITE);
			}
			
		}

		public virtual void Move()
		{
			if (!isVisible) { return; }

			if (velocity.X > MAXVELOCITY)velocity.X = MAXVELOCITY;
			else if (velocity.X < -MAXVELOCITY) velocity.X = -MAXVELOCITY;
			else velocity.X += curAcceleration.X;
			
			if(!onGround)
			{
				curAcceleration.Y = GRAVITY;
			}
			else
			{
				velocity.Y = 0;
				curAcceleration.Y = 0;
			}
			
			velocity.Y += curAcceleration.Y;

			nextPosition += velocity * Raylib.GetFrameTime();
			

		}
		public bool HasComponent(E_ComponentID ID)
		{
			foreach(var component in components)
			{
				if(component.GetId() == ID) return true;
			}
			
			return false;
		}

		public Component? GetComponent(E_ComponentID ID)
		{
			return components.Find(x => x.GetId() == ID);
		}
		
		public virtual void OnHit(Object otherObj)
		{

		}

		public virtual void SetTargetRect(Vector2 pos, Vector2 size)
		{
			targetRec = new Rectangle(pos.X, pos.Y, size.X, size.Y);
		}
	}
}
