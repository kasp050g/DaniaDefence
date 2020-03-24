using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
    public class SetTowers : Component
    {
        GameObject mouseTile;
        int sizeOfTile = 100;
        List<Tower> towers = new List<Tower>();
        Tower currentTower;
        PickTowerType pickTowerType;

        Kasper_Scene kasper_Scene;

        public GameObject MouseTile { get => mouseTile; set => mouseTile = value; }
        public int SizeOfTile { get => sizeOfTile; set => sizeOfTile = value; }
        public List<Tower> Towers { get => towers; set => towers = value; }

        public SetTowers(int _sizeOfTile,Kasper_Scene _kasper_Scene)
        {
            this.sizeOfTile = _sizeOfTile;
            this.kasper_Scene = _kasper_Scene;
        }
        public override void Awake()
        {
            base.Awake();
            Instantiate(new _WaveTest(sizeOfTile));
            _Astar_Test_For_unit.TileSize = sizeOfTile;
        }
        public override void Start()
        {
            base.Start();
            MadeTileOnMouse();
            pickTowerType = PickTowerType.Milo;
        }
        public override void Update()
        {
            base.Update();
            ShowTileOnMouse();
            SelectTileOnClick();
        }

        public void SelectTileOnClick()
        {
            if (Input.GetMouseButtonDown(MyMouseButtonsEnum.LeftButton) && !MyScene.IsMouseOverUI)
            {
                foreach (GameObject item in myScene.GameObjects)
                {
                    if (item is Tile == true && item.Transform.Position == mouseTile.Transform.Position && (item as Tile).TileType == TileTypeEnum.Empty)
                    {
                        if (CheckTowerCost(pickTowerType))
                        {
                            (item as Tile).ChangeTile(TileTypeEnum.Tower);
                            Destroy((item as Tile).Tower);

                            currentTower = MadeNewTower((item as Tile).Transform.Position, pickTowerType);

                            (item as Tile).Tower = currentTower;
                            Instantiate(currentTower);
                        }
                    }
                }
            }
            if (Input.GetMouseButtonDown(MyMouseButtonsEnum.RightButton) && !MyScene.IsMouseOverUI)
            {
                foreach (GameObject item in myScene.GameObjects)
                {
                    if (item is Tile == true && item.Transform.Position == mouseTile.Transform.Position && (item as Tile).TileType == TileTypeEnum.Tower)
                    {
                        (item as Tile).ChangeTile(TileTypeEnum.Empty);
                    }
                }
            }
        }
        public void ShowTileOnMouse()
        {
            if (!MyScene.IsMouseOverUI)
            {
                int mousex = Mouse.GetState().Position.X;
                int mousey = Mouse.GetState().Position.Y;
                Vector2 newPosition = new Vector2(mousex, mousey);

                Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));

                int positonX = (int)(worldPosition.X / sizeOfTile) * sizeOfTile;
                int positonY = (int)(worldPosition.Y / sizeOfTile) * sizeOfTile;

                if (positonX < 0)
                {
                    positonX -= sizeOfTile;
                }
                if (positonY < 0)
                {
                    positonY -= sizeOfTile;
                }

                if (worldPosition.X > -sizeOfTile && worldPosition.X < 0.0f)
                {
                    positonX = -sizeOfTile;
                }
                if (worldPosition.Y > -sizeOfTile && worldPosition.Y < 0.0f)
                {
                    positonY = -sizeOfTile;
                }

                mouseTile.Transform.Position = new Vector2(positonX, positonY);
            }
        }
        public void MadeTileOnMouse()
        {
            mouseTile = new GameObject();
            mouseTile.Transform.Scale = new Vector2(sizeOfTile, sizeOfTile);
            mouseTile.LayerDepth = 0.5f;
            Instantiate(mouseTile);
        }



        public void SetTowerType(PickTowerType _pickTowerType)
        {
            pickTowerType = _pickTowerType;
        }

        public bool CheckTowerCost(PickTowerType _pickTowerType)
        {
            int number = 0;
            switch (_pickTowerType)
            {
                case PickTowerType.Dennis:
                    number = 5;
                    break;
                case PickTowerType.Milo:
                    number = 25;
                    break;
                case PickTowerType.Kenneth:
                    number = 15;
                    break;
                case PickTowerType.Jonathan:
                    number = 10;
                    break;
                case PickTowerType.Mikael:
                    number = 15;
                    break;
                default:
                    break;
            }

            int currentMoney = kasper_Scene.currentCoin;

            int tmp = currentMoney - number;

            if(tmp >= 0)
            {
                kasper_Scene.currentCoin -= number;
                kasper_Scene.UpdateLiveCoin();
                return true;
            }
            else
            {
                return false;
            }            
        }

        public Tower MadeNewTower(Vector2 _position, PickTowerType _pickTowerType)
        {
            // Tile
            int tmpTileSize = sizeOfTile;
            float towerSize = (float)tmpTileSize / 400;

            Tower tmp = new Tower();

            switch (_pickTowerType)
            {
                case PickTowerType.Dennis:
                    tmp = new Dennis_Tower(
                        _position + new Vector2(tmpTileSize / 2, (float)tmpTileSize * 0.98f),
                        new Vector2(towerSize, towerSize),
                        tmpTileSize
                    );
                    break;
                case PickTowerType.Milo:
                    tmp = new Milo_Tower(
                        _position + new Vector2(tmpTileSize / 2, (float)tmpTileSize * 0.98f),
                        new Vector2(towerSize, towerSize),
                        tmpTileSize
                    );
                    break;
                case PickTowerType.Kenneth:
                    tmp = new Kenneth_Tower(
                        _position + new Vector2(tmpTileSize / 2, (float)tmpTileSize * 0.98f),
                        new Vector2(towerSize, towerSize),
                        tmpTileSize
                    );
                    break;
                case PickTowerType.Jonathan:
                    tmp = new Jonathan_Tower(
                        _position + new Vector2(tmpTileSize / 2, (float)tmpTileSize * 0.98f),
                        new Vector2(towerSize, towerSize),
                        tmpTileSize
                    );
                    break;
                case PickTowerType.Mikael:
                    tmp = new Mikael_Tower(
                        _position + new Vector2(tmpTileSize / 2, (float)tmpTileSize * 0.98f),
                        new Vector2(towerSize, towerSize),
                        tmpTileSize
                    );
                    break;
                default:
                    break;
            }

            return tmp;
        }
    }
}
