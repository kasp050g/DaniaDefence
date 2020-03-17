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
	public class TowerProjectile : GameObject
	{
		public float rotationVelocity = 3f;
		public float LinearVelocity = 4f;

		#region Constructor
		public TowerProjectile(Texture2D _sprite, Vector2 _position, float _layerDepth, 
			OriginPositionEnum _originPositionEnum, float _speed)
		{
			this.sprite = _sprite;
			this.Transform.Position = new Vector2(_position.X, _position.Y - 150);
			this.layerDepth = _layerDepth;
			this.OriginPositionEnum = _originPositionEnum;
			this.speed = _speed;
		}

		public void UpdateProjectile()
		{
			float deltaTime = Time.deltaTime;

			transform.Position += ((velocity * speed)* deltaTime);
		}

		public void ProjectileMovement()
		{
			Vector2 tmpDirection = new Vector2(0, 0);

			MouseState state = Mouse.GetState();

			if(transform.Position.X < state.X)
			{
				tmpDirection += new Vector2(1, 0);
			}

			if (transform.Position.X > state.X)
			{
				tmpDirection += new Vector2(-1, 0);
			}

			if(transform.Position.Y < state.Y)
			{
				tmpDirection += new Vector2(0, 1);
			}

			if (transform.Position.Y > state.Y)
			{
				tmpDirection += new Vector2(0, -1);
			}

			tmpDirection.Normalize();

			velocity = tmpDirection;
		}
		#endregion

		#region Method
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
			UpdateProjectile();
			ProjectileMovement();

			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
		#endregion
	}
}
