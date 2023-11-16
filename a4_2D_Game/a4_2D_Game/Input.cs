using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a4_2D_Game
{
	internal class Input
	{
		//Handles the keyboard input. Usually for the player.
		public Dictionary<E_Inputs, bool> activeInputs = new Dictionary<E_Inputs, bool>();
		public enum E_Inputs
		{
			DEFAULT = 0,
			INTERACT = 1,
			MOVELEFT = 2,
			MOVERIGHT = 3,
			JUMP = 4,
			CROUCH = 5

		};

		public Input()
		{
			Load();
		}

		public void Load()
		{
			foreach (var inputKey in activeInputs.Keys)
			{
				activeInputs[inputKey] = false;
			}
		}

		//Update which keys are being pressed and make them true if they are. You can add new keys here.
		//Don't forget to add them to E_Inputs as well!
		public void Update()
		{
			activeInputs[E_Inputs.INTERACT] = Raylib.IsKeyDown(KeyboardKey.KEY_E);
			activeInputs[E_Inputs.MOVELEFT] = Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT);
			activeInputs[E_Inputs.MOVERIGHT] = Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT);
			activeInputs[E_Inputs.JUMP] = Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) || Raylib.IsKeyDown(KeyboardKey.KEY_UP) || Raylib.IsKeyDown(KeyboardKey.KEY_W);
			activeInputs[E_Inputs.CROUCH] = Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_CONTROL);

			//Add new keys to monitor here:



		}


	}
}

