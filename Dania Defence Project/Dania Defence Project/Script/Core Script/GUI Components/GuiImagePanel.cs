using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class GuiImagePanel : GUI
	{
		#region Fields
		// Null
		#endregion

		#region Properties
		// Null
		#endregion

		#region Constructor
		public GuiImagePanel(Texture2D _sprite, Vector2 _position, Vector2 _scale, float _layerDepth, OriginPositionEnum _originPositionEnum)
		{
			// Button
			this.sprite = _sprite;
			this.transform.Position = _position;
			this.transform.Scale = _scale;
			this.layerDepth = _layerDepth;
			this.originPositionEnum = _originPositionEnum;
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
			spriteBatch.Draw(
				// Texture2D
				sprite,
				// Position
				this.transform.Position,
				// Source Rectangle
				null,
				// Color
				color,
				// Rotation
				MathHelper.ToRadians(this.transform.Rotation),
				// Origin
				this.transform.Origin,
				// Scale
				this.transform.Scale,
				// SpriteEffects
				this.spriteEffects,
				// LayerDepth
				this.layerDepth
			);
		}
		#endregion
	}
}
