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
        public int sizeOfTile = 100;
        public SetTowers setTowers;

        public int currentLive = 20;
        public int currentCoin = 25;

        GuiText showCurrencyText;
        GuiText showLifeText;

        public override void Initialize()
        {
            base.Initialize();
            setTowers = new SetTowers(sizeOfTile,this);
            Instantiate(setTowers);
            MadeGrid();
            MakeGameGui();
            MadeSpawer();
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
                new Vector2(0, GraphicsSetting.ScreenSize.Y),
                // Scale
                new Vector2(GraphicsSetting.ScreenSize.X, 100),
                // Layer Depth
                0.5f,
                // Origin
                OriginPositionEnum.BottomLeft
                );
            buttonImagePanel.Color = Color.DimGray;
            Instantiate(buttonImagePanel);
            #endregion

            #region Tower buttons
            // Made Tower Button's
            TowerButtom(buttonImagePanel, 0, "Face_Dennis", PickTowerType.Dennis,new Dennis_Tower(5));
            TowerButtom(buttonImagePanel, 1, "Face_Jonathan", PickTowerType.Jonathan,new Jonathan_Tower(10));
            TowerButtom(buttonImagePanel, 2, "Face_Kennet", PickTowerType.Kenneth,new Kenneth_Tower(15));
            TowerButtom(buttonImagePanel, 3, "Face_Mikae", PickTowerType.Mikael,new Mikael_Tower(20));
            TowerButtom(buttonImagePanel, 4, "Face_Milo", PickTowerType.Milo,new Milo_Tower(25));
            #endregion

            #region Show Currency 
            // Show Currency Image
            GuiImagePanel showCurrencyImage = new GuiImagePanel(
                // Texture2D
                SpriteContainer.sprite["coin"],
                // Position
                new Vector2(GraphicsSetting.ScreenSize.X - 75, 10),
                // Scale
                new Vector2(1, 1),
                // Layer Depth
                0.9f,
                // Origin
                OriginPositionEnum.TopRight
                );
            Instantiate(showCurrencyImage);

            // Show Currency Text
            showCurrencyText = new GuiText(
                // SpriteFont
                SpriteContainer.normalFont,
                // Texture2D
                "Money: ?",
                // Position
                new Vector2(5, 6),
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
                SpriteContainer.sprite["heart"],
                // Position
                new Vector2(50, 10),
                // Scale
                new Vector2(0.2f, 0.2f),
                // Layer Depth
                0.9f,
                // Origin
                OriginPositionEnum.TopRight
                );
            Instantiate(showLifeImage);

            // Show Life Text
            showLifeText = new GuiText(
                // SpriteFont
                SpriteContainer.normalFont,
                // Texture2D
                "Life: ?",
                // Position
                new Vector2(5, 7),
                // Scale
                new Vector2(0.4f, 0.4f),
                // Layer Depth
                0.9f,
                // Origin
                OriginPositionEnum.MidRight
                );
            showLifeText.ParentGUI = showLifeImage;
            showLifeText.Transform.Position += showLifeText.ParentGUI.Transform.Position + new Vector2(showLifeText.ParentGUI.Transform.Scale.X, 0);
            Instantiate(showLifeText);
            #endregion

            #region Top Panel
            // Button Image Panel
            GuiImagePanel topImagePanel = new GuiImagePanel(
                // Texture2D
                SpriteContainer.sprite["Pixel"],
                // Position
                new Vector2(0, 0),
                // Scale
                new Vector2(GraphicsSetting.ScreenSize.X, 50),
                // Layer Depth
                0.5f,
                // Origin
                OriginPositionEnum.TopLeft
                );
            topImagePanel.Color = Color.Black;
            Instantiate(topImagePanel);
            #endregion

            UpdateLiveCoin();
        }

        public void TowerButtom(GuiImagePanel _buttonImagePanel, int _rowNumber, string _face, PickTowerType _pickTower,Tower _tower)
        {
            TowerButton_GUI guiButton = new TowerButton_GUI(
                // Texture2D
                SpriteContainer.sprite[_face],
                // Position
                new Vector2(50 + _rowNumber * 100, -100),
                // Scale
                new Vector2(0.3f, 0.3f),
                // Layer Depth
                0.9f,
                // Origin
                OriginPositionEnum.TopLeft
            );

            guiButton.ParentGUI = _buttonImagePanel;
            guiButton.Tower = _tower;
            guiButton.Transform.Position += _buttonImagePanel.Transform.Position;
            guiButton.Color = Color.White;
            guiButton.IsHoveringColor = Color.Green;
            guiButton.OnClick = () => { setTowers.SetTowerType(_pickTower); };
            Instantiate(guiButton);
            TowerCost(
                guiButton.Transform.Position + new Vector2(35,80),
                guiButton.Tower.TowerCost.ToString()
                );
        }

        public void TowerCost(Vector2 _position,string moneyCost)
        {
            // Show Currency Image
            GuiImagePanel showCurrencyImage = new GuiImagePanel(
                // Texture2D
                SpriteContainer.sprite["coin"],
                // Position
                new Vector2(_position.X, _position.Y),
                // Scale
                new Vector2(0.6f, 0.6f),
                // Layer Depth
                0.95f,
                // Origin
                OriginPositionEnum.TopRight
                );
            Instantiate(showCurrencyImage);

            // Show Currency Text
            showCurrencyText = new GuiText(
                // SpriteFont
                SpriteContainer.normalFont,
                // Texture2D
                moneyCost,
                // Position
                new Vector2(
                    5,
                    0
                    ),
                // Scale
                new Vector2(0.4f, 0.4f),
                // Layer Depth
                0.95f,
                // Origin
                OriginPositionEnum.TopLeft
                );
            showCurrencyText.ParentGUI = showCurrencyImage;
            showCurrencyText.Transform.Position += showCurrencyText.ParentGUI.Transform.Position;
            Instantiate(showCurrencyText);
        }

        public void MadeSpawer()
        {
            foreach (GameObject item in gameObjects)
            {
                if (item is Tile == true && (item as Tile).TileType == TileTypeEnum.Spawn)
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
                    tile.Transform.Scale = new Vector2(sizeOfTile / 256f, sizeOfTile / 256f);
                    tile.Transform.Position = new Vector2(sizeOfTile * x, sizeOfTile * y);
                    tile.Transform.Position -= new Vector2(sizeOfTile * (GridNumber / 2), sizeOfTile * (GridNumber / 2));
                    tile.Color = Color.White;
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
        public void BlockTileMader(Tile _tile, int _x, int _y)
        {
            if (_tile.Transform.Position == new Vector2(-sizeOfTile * _x, -sizeOfTile * _y))
            {
                _tile.TileType = TileTypeEnum.Block;
            }
        }

        public void UpdateLiveCoin()
        {
            showCurrencyText.Text = currentCoin.ToString();
            showLifeText.Text = currentLive.ToString();
        }
    }
}
