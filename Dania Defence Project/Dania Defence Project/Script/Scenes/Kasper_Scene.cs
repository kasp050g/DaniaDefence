using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MyXMLData;

namespace Dania_Defence_Project
{
	public class Kasper_Scene : Scene
	{
        public int sizeOfTile = 50;
        public override void Initialize()
		{
			base.Initialize();
            MadeGrid();
			MakeGameGui();
            MadeSpawer();
            Instantiate(new SetTowers(sizeOfTile));
            _Astar_Test _Astar_Test = new _Astar_Test(sizeOfTile);
            Instantiate(_Astar_Test);
            
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

		public void MakeGameGui()
		{
			#region Button Panel
			// Button Image Panel
			GuiImagePanel buttonImagePanel = new GuiImagePanel(
				// Texture2D
				SpriteContainer.sprite["Pixel"],
				// Position
				new Vector2(0,GraphicsSetting.ScreenSize.Y),
				// Scale
				new Vector2(GraphicsSetting.ScreenSize.X,100),
				// Layer Depth
				0.5f,
				// Origin
				OriginPositionEnum.BottomLeft
				);
			Instantiate(buttonImagePanel);
			#endregion

			#region Tower buttons
			// Made Tower Button's
			for (int i = 0; i < 4; i++)
			{
				GuiButton guiButton = new GuiButton(
				// Texture2D
				SpriteContainer.sprite["Pixel"],
				// Position
				new Vector2(50 + i * 100,-85),
				// Scale
				new Vector2(70, 70),
				// Layer Depth
				0.9f,
				// Origin
				OriginPositionEnum.TopLeft
				);

				guiButton.ParentGUI = buttonImagePanel;
				guiButton.Transform.Position += buttonImagePanel.Transform.Position;
				guiButton.Color = Color.Blue;
				guiButton.IsHoveringColor = Color.Red;

				Instantiate(guiButton);
			}
			#endregion

			#region Show Currency 
			// Show Currency Image
			GuiImagePanel showCurrencyImage = new GuiImagePanel(
				// Texture2D
				SpriteContainer.sprite["Pixel"],
				// Position
				new Vector2(GraphicsSetting.ScreenSize.X - 100, 20),
				// Scale
				new Vector2(40,40),
				// Layer Depth
				0.9f,
				// Origin
				OriginPositionEnum.TopRight
				);
			Instantiate(showCurrencyImage);

			// Show Currency Text
			GuiText showCurrencyText = new GuiText(
				// SpriteFont
				SpriteContainer.normalFont,
				// Texture2D
				"Money: ?",
				// Position
				new Vector2(5, 10),
				// Scale
				new Vector2(0.4f, 0.4f),
				// Layer Depth
				0.9f,
				// Origin
				OriginPositionEnum.MidRight
				);
			showCurrencyText.ParentGUI = showCurrencyImage;
			showCurrencyText.Transform.Position += showCurrencyText.ParentGUI.Transform.Position;
			Instantiate(showCurrencyText);
			#endregion

			#region Show Life
			// Show Life Image
			GuiImagePanel showLifeImage = new GuiImagePanel(
				// Texture2D
				SpriteContainer.sprite["Pixel"],
				// Position
				new Vector2(20, 20),
				// Scale
				new Vector2(40, 40),
				// Layer Depth
				0.9f,
				// Origin
				OriginPositionEnum.TopLeft
				);
			Instantiate(showLifeImage);

			// Show Life Text
			GuiText showLifeText = new GuiText(
				// SpriteFont
				SpriteContainer.normalFont,
				// Texture2D
				"Life: ?",
				// Position
				new Vector2(5, 10),
				// Scale
				new Vector2(0.4f, 0.4f),
				// Layer Depth
				0.9f,
				// Origin
				OriginPositionEnum.MidRight
				);
			showLifeText.ParentGUI = showLifeImage;
			showLifeText.Transform.Position += showLifeText.ParentGUI.Transform.Position + new Vector2(showLifeText.ParentGUI.Transform.Scale.X,0);
			Instantiate(showLifeText);
			#endregion
		}

        public void MadeSpawer()
        {
            foreach (GameObject item in gameObjects)
            {
                if(item is Tile == true && (item as Tile).TileType == TileTypeEnum.Spawn)
                {
                    Instantiate(new Spawner(
                        item.Transform.Position + 
                        new Vector2(sizeOfTile / 2, sizeOfTile / 2)
                        ));
                }
            }
        }

        public void MadeGrid()
        {
            int GridNumber = 25;
            for (int x = 0; x < GridNumber; x++)
            {
                for (int y = 0; y < GridNumber; y++)
                {
                    Tile tile = new Tile(sizeOfTile);
                    tile.Transform.Scale = new Vector2(sizeOfTile, sizeOfTile);
                    tile.Transform.Position = new Vector2(sizeOfTile * x, sizeOfTile * y);
                    tile.Transform.Position -= new Vector2(sizeOfTile * (GridNumber / 2), sizeOfTile * (GridNumber / 2));
                    tile.Color = Color.ForestGreen;
                    tile.LayerDepth = 0.01f;
                    if (tile.Transform.Position == new Vector2(0, 0))
                    {
                        tile.TileType = TileTypeEnum.Center;
                        tile.Color = Color.MediumVioletRed;
                    }
                    if (tile.Transform.Position == new Vector2(-sizeOfTile * 10, 0))
                    {
                        tile.TileType = TileTypeEnum.Spawn;
                        tile.Color = Color.Red;
                    }
                    BlockTile(tile);
                    Instantiate(tile);
                }
            }
        }

        public void BlockTile(Tile _tile)
        {
            // Left Wall
            BlockTileMader(_tile, 12, 0);
            BlockTileMader(_tile, 12, -5);
            BlockTileMader(_tile, 12, -4);
            BlockTileMader(_tile, 12, -3);
            BlockTileMader(_tile, 12, -2);
            BlockTileMader(_tile, 12, -1);
            BlockTileMader(_tile, 12, 5);
            BlockTileMader(_tile, 12, 4);
            BlockTileMader(_tile, 12, 3);
            BlockTileMader(_tile, 12, 2);
            BlockTileMader(_tile, 12, 1);

            // Rigth Wall
            BlockTileMader(_tile, -9, 0);
            BlockTileMader(_tile, -9, -5);
            BlockTileMader(_tile, -9, -4);
            BlockTileMader(_tile, -9, -3);
            BlockTileMader(_tile, -9, -2);
            BlockTileMader(_tile, -9, -1);
            BlockTileMader(_tile, -9, 5);
            BlockTileMader(_tile, -9, 4);
            BlockTileMader(_tile, -9, 3);
            BlockTileMader(_tile, -9, 2);
            BlockTileMader(_tile, -9, 1);

            // Buttom Wall
            BlockTileMader(_tile, 11, 5);
            BlockTileMader(_tile, 10, 5);
            BlockTileMader(_tile, 9, 5);
            BlockTileMader(_tile, 8, 5);
            BlockTileMader(_tile, 7, 5);
            BlockTileMader(_tile, 6, 5);
            BlockTileMader(_tile, 5, 5);
            BlockTileMader(_tile, 4, 5);
            BlockTileMader(_tile, 3, 5);
            BlockTileMader(_tile, 2, 5);
            BlockTileMader(_tile, 1, 5);
            BlockTileMader(_tile, 0, 5);
            BlockTileMader(_tile, -1, 5);
            BlockTileMader(_tile, -2, 5);
            BlockTileMader(_tile, -3, 5);
            BlockTileMader(_tile, -4, 5);
            BlockTileMader(_tile, -5, 5);
            BlockTileMader(_tile, -6, 5);
            BlockTileMader(_tile, -7, 5);
            BlockTileMader(_tile, -8, 5);
            BlockTileMader(_tile, -9, 5);

            // Top Wall
            BlockTileMader(_tile, 11, -5);
            BlockTileMader(_tile, 10, -5);
            BlockTileMader(_tile, 9, -5);
            BlockTileMader(_tile, 8, -5);
            BlockTileMader(_tile, 7, -5);
            BlockTileMader(_tile, 6, -5);
            BlockTileMader(_tile, 5, -5);
            BlockTileMader(_tile, 4, -5);
            BlockTileMader(_tile, 3, -5);
            BlockTileMader(_tile, 2, -5);
            BlockTileMader(_tile, 1, -5);
            BlockTileMader(_tile, 0, -5);
            BlockTileMader(_tile, -1, -5);
            BlockTileMader(_tile, -2, -5);
            BlockTileMader(_tile, -3, -5);
            BlockTileMader(_tile, -4, -5);
            BlockTileMader(_tile, -5, -5);
            BlockTileMader(_tile, -6, -5);
            BlockTileMader(_tile, -7, -5);
            BlockTileMader(_tile, -8, -5);
            BlockTileMader(_tile, -9, -5);
        }
        public void BlockTileMader(Tile _tile,int _x,int _y)
        {
            if (_tile.Transform.Position == new Vector2(-sizeOfTile * _x, -sizeOfTile * _y))
            {
                _tile.TileType = TileTypeEnum.Block;
            }
        }
    }
}
