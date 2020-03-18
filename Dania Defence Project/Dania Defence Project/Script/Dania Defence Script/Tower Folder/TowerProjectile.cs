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

		public Vector2 myTarget;

		#region Constructor
		public TowerProjectile(Texture2D _sprite, Vector2 _position, float _layerDepth, 
			OriginPositionEnum _originPositionEnum, float _speed)
		{
			this.sprite = _sprite;
			this.Transform.Position = new Vector2(_position.X, _position.Y - 100);
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

			var mouseX = state.Position.X;
			var mouseY = state.Position.Y;

			Vector2 newPosition = new Vector2(mouseX, mouseY);

			Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));

			myTarget = worldPosition;

			if(transform.Position.X < worldPosition.X)
			{
				tmpDirection += new Vector2(1, 0);
			}
		
			if (transform.Position.X > worldPosition.X)
			{
				tmpDirection += new Vector2(-1, 0);
			}

			if(transform.Position.Y < worldPosition.Y)
			{
				tmpDirection += new Vector2(0, 1);
			}

			if (transform.Position.Y > worldPosition.Y)
			{
				tmpDirection += new Vector2(0, -1);
			}

			tmpDirection.Normalize();

			velocity = tmpDirection;
		}

		public static float CalculateAngleBetweenPositions(Vector2 fromPosition, Vector2 toPosition)
		{
			Vector2 vectorTowardsToVector = toPosition - fromPosition;
			float distance = vectorTowardsToVector.Length();
			if (distance > 0)
			{
				float dot = Vector2.Dot(
					new Vector2(1, 0), // Vector point right
					Vector2.Normalize(vectorTowardsToVector) // Vector pointing towards destination
				);

				float degrees = MathHelper.ToDegrees((float)Math.Acos(dot));

				if (vectorTowardsToVector.Y < 0)
				{
					degrees = 180 + (180 - degrees);
				}

				return degrees;
			}
			else
			{
				return 0;
			}
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

			float angle1 = Helper.CalculateAngleBetweenPositions(transform.Position, myTarget);

			transform.Rotation = angle1 - 90;

			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
		#endregion
	}
}
