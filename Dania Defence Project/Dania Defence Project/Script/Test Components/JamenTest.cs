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
	public class JamenTest : GameObject
	{
		private float speed = 200;
		private Vector2 velocity = new Vector2(0, 0);
		public Transform Player;

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
			if (Input.GetKey(Keys.T))
			{
				Transform.Rotation += 3;
			}
			if (Input.GetKey(Keys.Y))
			{
				Transform.Rotation -= 3;
			}

			velocity = Vector2.Zero;

			if (Input.GetKey(Keys.Up))
			{
				velocity += new Vector2(0, -1);
			}

			if (Input.GetKey(Keys.Down))
			{
				velocity += new Vector2(0, 1);
			}

			if (Input.GetKey(Keys.Left))
			{
				velocity += new Vector2(-1, 0);
			}

			if (Input.GetKey(Keys.Right))
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
