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
		public TowerProjectile(Texture2D _sprite, Vector2 _position, Vector2 _scale, float _layerDepth, OriginPositionEnum _originPositionEnum)
		{
			this.sprite = _sprite;
			this.Transform.Position = _position;
			this.Transform.Scale = _scale;
			this.layerDepth = _layerDepth;
			this.OriginPositionEnum = _originPositionEnum;
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
			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
		#endregion
	}
}
