using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class Towers : GameObject
	{
		#region Constructor
		public Towers(Texture2D _sprite, Vector2 _position, Vector2 _scale, float _layerDepth, OriginPositionEnum _originPositionEnum)
		{
			this.sprite = _sprite;
			this.Transform.Position = _position;
			this.Transform.Scale = _scale;
			this.LayerDepth = _layerDepth;
			this.OriginPositionEnum = _originPositionEnum;
		}
		#endregion

		#region Methods
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
			Texture2D _sprite = sprite;
			Color _color = Color;

			spriteBatch.Draw(
				//Texture
				_sprite, 
				
				//Position
				this.transform.Position, 
				
				//Sprite Rectangle
				null, 
				
				//Colour
				Color, 
				
				//Rotation
				MathHelper.ToRadians(this.transform.Rotation), 
				
				//Origin
				this.transform.Origin, 
				
				//Scale
				this.transform.Scale, 
				
				//Sprite Effect
				this.spriteEffects, 
				
				//Layer Depth
				this.LayerDepth
				);
		}
		#endregion
	}
}
