﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public enum InputState { GetKey, GetKeyDown, GetKeyUp }
	public enum MyInputStateEnum { GetMouseButton, GetMouseButtonDown, GetMouseButtonUp }
	public enum MyMouseButtonsEnum { LeftButton, MiddleButton, RightButton }

	public static class Input
	{
		// Contains all current use keys
		private static Dictionary<Keys, InputState> keyStates = new Dictionary<Keys, InputState>();

		private static Dictionary<MyMouseButtonsEnum, MyInputStateEnum> myMouseStates = new Dictionary<MyMouseButtonsEnum, MyInputStateEnum>();

		public static void Update()
		{
			KeysUpdate();
			MouseButton();
		}

		#region Mouse Input
		public static bool GetMouseButtonDown(MyMouseButtonsEnum monoMouseButton)
		{
			if (Input.myMouseStates.TryGetValue(monoMouseButton, out MyInputStateEnum myInputState))
			{
				return myInputState == MyInputStateEnum.GetMouseButtonDown;
			}
			else
			{
				return false;
			}
		}

		public static bool GetMouseButton(MyMouseButtonsEnum monoMouseButton)
		{
			if (Input.myMouseStates.TryGetValue(monoMouseButton, out MyInputStateEnum myInputState))
			{
				return myInputState == MyInputStateEnum.GetMouseButtonDown || myInputState == MyInputStateEnum.GetMouseButton;
			}
			else
			{
				return false;
			}
		}

		public static bool GetMouseButtonUp(MyMouseButtonsEnum monoMouseButton)
		{
			if (Input.myMouseStates.TryGetValue(monoMouseButton, out MyInputStateEnum myInputState))
			{
				return myInputState == MyInputStateEnum.GetMouseButtonUp;
			}
			else
			{
				return false;
			}
		}

		private static void MouseButton()
		{
			MouseState monoMouseState = Mouse.GetState();

			List<MyMouseButtonsEnum> monoPressedMouseButtons = new List<MyMouseButtonsEnum>();

			if (monoMouseState.LeftButton == ButtonState.Pressed) monoPressedMouseButtons.Add(MyMouseButtonsEnum.LeftButton);
			if (monoMouseState.MiddleButton == ButtonState.Pressed) monoPressedMouseButtons.Add(MyMouseButtonsEnum.MiddleButton);
			if (monoMouseState.RightButton == ButtonState.Pressed) monoPressedMouseButtons.Add(MyMouseButtonsEnum.RightButton);

			MouseDown(monoPressedMouseButtons);
			MouseUp(monoPressedMouseButtons);
		}

		// Handle mouse button release
		private static void MouseDown(List<MyMouseButtonsEnum> monoPressedMouseButtons)
		{
			var myMouseStatesNew = new Dictionary<MyMouseButtonsEnum, MyInputStateEnum>(Input.myMouseStates);  // Copy states

			foreach (KeyValuePair<MyMouseButtonsEnum, MyInputStateEnum> amaInputStatePairInLoop in Input.myMouseStates)
			{
				MyMouseButtonsEnum monoMouseButtonInLoop = amaInputStatePairInLoop.Key;

				if (false == monoPressedMouseButtons.Contains(monoMouseButtonInLoop))
				{
					if (amaInputStatePairInLoop.Value == MyInputStateEnum.GetMouseButton || amaInputStatePairInLoop.Value == MyInputStateEnum.GetMouseButtonDown)
					{
						myMouseStatesNew[monoMouseButtonInLoop] = MyInputStateEnum.GetMouseButtonUp;
					}
					else
					{
						myMouseStatesNew.Remove(monoMouseButtonInLoop);
					}
				}
			}

			Input.myMouseStates.Clear();
			Input.myMouseStates = myMouseStatesNew;
		}

		// Handle mouse button press
		private static void MouseUp(List<MyMouseButtonsEnum> monoPressedMouseButtons)
		{
			var myMouseStatesNew = new Dictionary<MyMouseButtonsEnum, MyInputStateEnum>(Input.myMouseStates);  // Copy states

			foreach (MyMouseButtonsEnum monoMouseButton in monoPressedMouseButtons)
			{
				if (Input.myMouseStates.ContainsKey(monoMouseButton))
				{
					myMouseStatesNew[monoMouseButton] = MyInputStateEnum.GetMouseButton;
				}
				else
				{
					myMouseStatesNew[monoMouseButton] = MyInputStateEnum.GetMouseButtonDown;
				}
			}

			Input.myMouseStates.Clear();
			Input.myMouseStates = myMouseStatesNew;
		}
		#endregion


		#region Key Input
		private static void KeysUpdate()
		{
			// Get current state of keyboard.
			KeyboardState keyboardState = Keyboard.GetState();
			// Check if any keys are Pressed's
			Keys[] getPressedKeys = keyboardState.GetPressedKeys();

			KeyUp(getPressedKeys);
			KeyDown(getPressedKeys);
		}

		private static void KeyUp(Keys[] getPressedKeys)
		{
			// Copy the stats of 'contains all current use keys'
			Dictionary<Keys, InputState> myKeyStatesNew = new Dictionary<Keys, InputState>(Input.keyStates);

			foreach (KeyValuePair<Keys, InputState> currentKeys in Input.keyStates)
			{
				Keys keyInLoop = currentKeys.Key;

				// Here we will look if 'getPressedKeys' exists in Input.keyStates.
				// getPressedKeys is the current keys that are pressed.
				// keyInLoop is the current key in use as 'GetKey, GetKeyDown, GetKeyUp'
				// why == false, well we only want to check for GetKeyUp when you release the key.
				// TODO : why do it need ' _key => _key ==' that i dont know ¯\_(ツ)_/¯
				if (false == Array.Exists(getPressedKeys, _key => _key == keyInLoop))
				{
					if (currentKeys.Value == InputState.GetKey || currentKeys.Value == InputState.GetKeyDown)
					{
						myKeyStatesNew[keyInLoop] = InputState.GetKeyUp;
					}
					else
					{
						myKeyStatesNew.Remove(keyInLoop);
					}
				}
			}

			Input.keyStates.Clear();
			Input.keyStates = myKeyStatesNew;
		}

		private static void KeyDown(Keys[] getPressedKeys)
		{
			// Copy the stats of 'contains all current use keys'
			Dictionary<Keys, InputState> newKeyStates = new Dictionary<Keys, InputState>(Input.keyStates);

			foreach (Keys key in getPressedKeys)
			{
				if (Input.keyStates.ContainsKey(key))
				{
					newKeyStates[key] = InputState.GetKey;
				}
				else
				{
					newKeyStates[key] = InputState.GetKeyDown;
				}
			}

			Input.keyStates.Clear();
			Input.keyStates = newKeyStates;
		}

		public static bool GetKeyDown(Keys key)
		{
			// Check if the key is in use.
			if (Input.keyStates.TryGetValue(key, out InputState inputState))
			{
				// Check if the key is 'GetKeyDown, GetKey, GetKeyUp'
				// if it is the rigth one return true else return false.
				return inputState == InputState.GetKeyDown;
			}
			else
			{
				return false;
			}
		}

		public static bool GetKey(Keys key)
		{
			// Check if the key is in use.
			if (Input.keyStates.TryGetValue(key, out InputState inputState))
			{
				// Check if the key is 'GetKeyDown, GetKey, GetKeyUp'
				// if it is the rigth one return true else return false.
				return inputState == InputState.GetKey;
			}
			else
			{
				return false;
			}
		}

		public static bool GetKeyUp(Keys key)
		{
			// Check if the key is in use.
			if (Input.keyStates.TryGetValue(key, out InputState inputState))
			{
				// Check if the key is 'GetKeyDown, GetKey, GetKeyUp'
				// if it is the rigth one return true else return false.
				return inputState == InputState.GetKeyUp;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
}
