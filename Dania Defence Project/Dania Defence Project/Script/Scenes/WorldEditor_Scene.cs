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
		public int sizeOfTile = 100;
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

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public void MadeScene()
		{
			MadeGrid();

			WorldEditor worldEditor = new WorldEditor(sizeOfTile);
			Instantiate(worldEditor);
		}

		public void MadeGrid()
		{
            int GridNumber = 4;
			for (int x = 0; x < GridNumber; x++)
			{
				for (int y = 0; y < GridNumber; y++)
				{
					//ShowGrid showGrid = new ShowGrid(sizeOfTile);
					//showGrid.LayerDepth = 0.01f;
					//showGrid.Transform.Position = new Vector2(sizeOfTile * x, sizeOfTile * y);
					//showGrid.Transform.Position -= new Vector2(sizeOfTile * GridNumber / 2, sizeOfTile * GridNumber / 2);
					//Instantiate(showGrid);

                    Tile tile = new Tile(sizeOfTile);
                    tile.Transform.Scale = new Vector2(sizeOfTile, sizeOfTile);
                    tile.Transform.Position = new Vector2(sizeOfTile * x, sizeOfTile * y);
                    tile.Transform.Position -= new Vector2(sizeOfTile * GridNumber / 2, sizeOfTile * GridNumber / 2);
                    tile.Color = Color.ForestGreen;
                    tile.LayerDepth = 0.01f;
                    if(tile.Transform.Position == new Vector2(0, 0))
                    {
                        tile.TileType = TileTypeEnum.Center;
                        tile.Color = Color.MediumVioletRed;
                    }
                    Instantiate(tile);
                }
			}
		}
	}
}
