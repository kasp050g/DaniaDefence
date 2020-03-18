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
        public int sizeOfTile = 100;
        public SetTowers(int _sizeOfTile)
        {
            this.sizeOfTile = _sizeOfTile;
        }
        public override void Awake()
        {
            base.Awake();
        }
        public override void Start()
        {
            base.Start();
            MadeTileOnMouse();
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
                        (item as Tile).ChangeTile(TileTypeEnum.Tower);
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
    }
}
