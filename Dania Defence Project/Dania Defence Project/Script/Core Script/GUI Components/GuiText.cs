using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class GuiText : GUI
	{
		#region Fields
		protected string text;
		protected SpriteFont font;
		protected Vector2 fontScale = new Vector2(1, 1);
		#endregion

		#region Properties
		public string Text { get => text; set => text = value; }
		public SpriteFont Font { get => font; set => font = value; }
		public Vector2 FontScale { get => fontScale; set => fontScale = value; }
		#endregion

		#region Constructor
		public GuiText(SpriteFont _font, string _text, Vector2 _position, Vector2 _scale, float _layerDepth, OriginPositionEnum _originPositionEnum)
		{
			this.font = _font;
			this.text = _text;
			this.transform.Position = _position;
			this.FontScale =  _scale;
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
			spriteBatch.DrawString(
				// SpriteFont
				this.font,
				// String text
				this.Text,
				// Position
				this.transform.Position,
				// Color
				this.color,
				// Rotation
				MathHelper.ToRadians(this.transform.Rotation),
				// Origin
				Vector2.Zero,
				// Scale
				this.FontScale,
				// SpriteEffects
				SpriteEffects.None,
				// LayerDepth
				this.layerDepth
			);
		}
		#endregion
	}
}
