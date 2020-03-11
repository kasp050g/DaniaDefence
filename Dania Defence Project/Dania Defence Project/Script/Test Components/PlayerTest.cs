using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class PlayerTest : GameObject
	{
		private float speed = 200;
		private Vector2 velocity = new Vector2(0, 0);

		public override void Awake()
		{
			base.Awake();
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Update()
		{
			base.Update();
			InputHanlder();
			Move();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public void Move()
		{
			Transform.Position += ((velocity * speed) * Time.deltaTime);
		}
		public void InputHanlder()
		{
			if (Input.GetKey(Keys.Q))
			{
				Transform.Rotation += 3;
			}
			if (Input.GetKey(Keys.E))
			{
				Transform.Rotation -= 3;
			}

            if (Input.GetKey(Keys.P))
            {
                SceneController.CurrentScene = SceneController.SceneContainer.Scenes.Find(x => x.Name == "Test02");
            }

            velocity = Vector2.Zero;

			if (Input.GetKey(Keys.W))
			{
				velocity += new Vector2(0, -1);
			}

			if (Input.GetKey(Keys.S))
			{
				velocity += new Vector2(0, 1);
			}

			if (Input.GetKey(Keys.A))
			{
				velocity += new Vector2(-1, 0);
			}

			if (Input.GetKey(Keys.D))
			{
				velocity += new Vector2(1, 0);
			}

			if (Math.Abs(velocity.X) > 0 || Math.Abs(velocity.Y) > 0)
			{
				velocity.Normalize();
			}
		}
	}
}
