using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class TowerProjectile : GameObject
	{
		#region Constructor
		public TowerProjectile(Texture2D _sprite, Vector2 _position, float _layerDepth, 
			OriginPositionEnum _originPositionEnum, float _speed)
		{
			this.sprite = _sprite;
			this.Transform.Position = new Vector2(_position.X, _position.Y - 25);
			this.layerDepth = _layerDepth;
			this.OriginPositionEnum = _originPositionEnum;
			this.speed = _speed;
			this.velocity = new Vector2(0, -1);
		}

		public void UpdateProjectile()
		{
			float deltaTime = Time.deltaTime;

			transform.Position += ((velocity * speed)* deltaTime);
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

			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
		#endregion
	}
}
