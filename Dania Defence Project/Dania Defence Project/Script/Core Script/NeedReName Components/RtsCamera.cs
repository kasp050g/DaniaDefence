using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class RtsCamera
	{
		private bool isFirstUpdate = true;
		public Matrix Transform { get; private set; }
		public Vector2 Position { get; set; }

		public float moveSpeed = 500;

		public RtsCamera()
		{
			this.Transform = Matrix.CreateTranslation(0, 0, 0);
		}

		public void Update()
		{
			if (this.isFirstUpdate == true)
			{
				// On the first update (after each scene switch) the camera should instantly move to destination
				// (meaning that the weight will not have an effect on the movement)


				this.isFirstUpdate = false;
			}

			//this.Position = this.Position * (this.MovementWeight) + (1 - this.MovementWeight);
			MoveCamare();

			Matrix position = Matrix.CreateTranslation(
				-this.Position.X,
				-this.Position.Y,
				0);

			Matrix offset = Matrix.CreateTranslation(
				GraphicsSetting.ScreenSize.X / 2,
				GraphicsSetting.ScreenSize.Y / 2,
				0);

			this.Transform = position * offset;
		}

		public void OnSwitchScene()
		{
			this.isFirstUpdate = true;
		}

		public void MoveCamare()
		{
			Vector2 newMove = new Vector2(0, 0);
			if (Input.GetKey(Keys.W))
			{
				newMove += new Vector2(0, -1);
			}
			if (Input.GetKey(Keys.S))
			{
				newMove += new Vector2(0, 1);
			}
			if (Input.GetKey(Keys.A))
			{
				newMove += new Vector2(-1, 0);
			}
			if (Input.GetKey(Keys.D))
			{
				newMove += new Vector2(1, 0);
			}

			if (Input.GetKey(Keys.LeftShift))
			{
				newMove *= 10;
			}

			Position += newMove * moveSpeed * Time.deltaTime;
		}
	}
}
