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
				new Vector2(100,1),
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
				new Vector2(1, 100),
				// SpriteEffects
				this.spriteEffects,
				// LayerDepth
				this.layerDepth
			);
		}


	}
}
