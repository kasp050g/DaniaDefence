using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class ShowGrid : GUI
	{
		public int gridSize = 100;

		public ShowGrid (int _gridSzie)
		{
			this.gridSize = _gridSzie;

		}
		public override void Awake()
		{
			base.Awake();
			IsWorldGui = true;
			color = Color.Black;
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
				new Vector2(gridSize, 1),
				// SpriteEffects
				this.spriteEffects,
				// LayerDepth
				this.layerDepth
			);
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
				new Vector2(1, gridSize),
				// SpriteEffects
				this.spriteEffects,
				// LayerDepth
				this.layerDepth
			);
		}


	}
}
