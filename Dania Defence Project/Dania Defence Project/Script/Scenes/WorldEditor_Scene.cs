using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class WorldEditor_Scene : Scene
	{
		public int sizeOfTile = 50;
		public override void Initialize()
		{
			base.Initialize();
			MadeScene();
		}

		public override void OnSwitchToThisScene()
		{
			base.OnSwitchToThisScene();
		}

		public override void OnSwitchAwayFromThisScene()
		{
			base.OnSwitchAwayFromThisScene();
		}

		public override void Update()
		{
			base.Update();
		}
			List<GameObject> tielsNameShow = new List<GameObject>();
		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

			tielsNameShow.Clear();

			foreach (var item in gameObjects)
			{
				if (item is Tile)
				{
					tielsNameShow.Add(item);
				}
			}

			for (int i = 0; i < tielsNameShow.Count; i++)
			{
				spriteBatch.DrawString(
					// SpriteFont
					SpriteContainer.normalFont,
					// String text
					"Tile Nr: " + i.ToString(),
					// Position
					new Vector2(10, 20 * i + 10),
					// Color
					Color.Black,
					// Rotation
					0,
					// Origin
					Vector2.Zero,
					// Scale
					new Vector2(0.5f, 0.5f),
					// SpriteEffects
					SpriteEffects.None,
					// LayerDepth
					1
				);
			}
			spriteBatch.End();



		}

		public void MadeScene()
		{
			MadeGrid();

			WorldEditor worldEditor = new WorldEditor(sizeOfTile);
			Instantiate(worldEditor);
		}

		public void MadeGrid()
		{
			for (int x = 0; x < 100; x++)
			{
				for (int y = 0; y < 100; y++)
				{
					ShowGrid showGrid = new ShowGrid(sizeOfTile);
					showGrid.LayerDepth = 0.99f;
					showGrid.Transform.Position = new Vector2(sizeOfTile * x, sizeOfTile * y);
					showGrid.Transform.Position -= new Vector2(sizeOfTile * 100 / 2, sizeOfTile * 100 / 2);
					Instantiate(showGrid);
				}
			}
		}
	}
}
