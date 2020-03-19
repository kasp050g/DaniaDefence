using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
    public class _Astar_Test : Component
    {
        public bool runAstar = true;
        int tileSize = 1;
        Tile start;
        Tile goal;

        Tile currentTile;

        List<Tile> open = new List<Tile>();
        List<Tile> close = new List<Tile>();

        public List<Tile> tiles = new List<Tile>();
        public _Astar_Test(int _tileSize)
        {
            this.tileSize = _tileSize;
        }
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

            if (Input.GetKeyDown(Keys.E))
            {
                DoTheAStar();
            }
        }

        public void DoTheAStar()
        {
            tiles.Clear();
            open.Clear();
            close.Clear();

            GetTileList();
            StartAndFindGoal(tiles);
            MainLoop();
        }

        public void GetTileList()
        {
            
            List<Tile> newTiles = new List<Tile>();
            foreach (var item in myScene.GameObjects)
            {
                if(item is Tile)
                {
                    newTiles.Add(item as Tile);
                }
            }
            tiles = newTiles;
        }

        public void StartAndFindGoal(List<Tile> _tiles)
        {
            foreach (Tile item in _tiles)
            {
                if (item.TileType == TileTypeEnum.Spawn)
                {
                    start = item;  //TODO set start to current Position
                }
                if (item.TileType  == TileTypeEnum.Center)
                {
                    goal = item;
                }
            }
            AddOpen(start, 0);
        }

        public void MainLoop()
        {
            while (runAstar == true)
            {
                
                if (open.Count == 0)
                {
                    break;
                }

                FindLowerCostCell();

                if (currentTile == goal)
                {
                    GoHome();
                    break;
                }

                CellroundTarget(currentTile);
            }
        }

        public void FindLowerCostCell()
        {
            currentTile = open[0];
            foreach (Tile item in open)
            {
                if (currentTile.F > item.F || currentTile.F >= item.F && currentTile.H > item.H)
                {
                    currentTile = item;
                }
            }
            currentTile.Color = Color.CadetBlue;
            open.Remove(currentTile);
            close.Add(currentTile);
        }

        public void AddOpen(Tile cell, int gCost)
        {
            
            int y = (int)cell.Transform.Position.Y;
            int x = (int)cell.Transform.Position.X;

            int distane = 0;

            // Y
            while (true)
            {
                if (y == goal.Transform.Position.Y)
                {
                    break;
                }
                else
                {
                    if (goal.Transform.Position.Y > y)
                    {
                        y += tileSize;
                    }
                    else
                    {
                        y -= tileSize;
                    }
                    distane += 10;
                }
            }
            // X
            while (true)
            {
                if (x == goal.Transform.Position.X)
                {
                    break;
                }
                else
                {
                    if (goal.Transform.Position.X > x)
                    {
                        x += tileSize;
                    }
                    else
                    {
                        x -= tileSize;
                    }
                    distane += 10;
                }
            }

            cell.H = distane;
            cell.G = gCost + (currentTile != null ? currentTile.G : 0);
            cell.F = cell.G + cell.H;
            cell.LastTile = currentTile;

            open.Add(cell);
        }


        public void CellroundTarget(Tile target)
        {
            List<Tile> cells = new List<Tile>();

            foreach (Tile item in tiles)
            {
                // - - - Y bot - - - 
                // Y+1 X+1
                if (item.Transform.Position.X + tileSize == target.Transform.Position.X && item.Transform.Position.Y + tileSize == target.Transform.Position.Y)
                {
                    //BeforOpenAdd(item, 14);
                }
                // Y+1 X 0
                else if (item.Transform.Position.X == target.Transform.Position.X && item.Transform.Position.Y + tileSize == target.Transform.Position.Y)
                {
                    BeforOpenAdd(item, 10);
                }
                // Y+tileSize X-tileSize
                else if (item.Transform.Position.X - tileSize == target.Transform.Position.X && item.Transform.Position.Y + tileSize == target.Transform.Position.Y)
                {
                    //BeforOpenAdd(item, tileSize4);
                }
                // - - - Y mid - - - 
                // Y+0 X+tileSize
                if (item.Transform.Position.X + tileSize == target.Transform.Position.X && item.Transform.Position.Y == target.Transform.Position.Y)
                {
                    BeforOpenAdd(item, 10);
                }
                // Y+0 X-tileSize
                else if (item.Transform.Position.X - tileSize == target.Transform.Position.X && item.Transform.Position.Y == target.Transform.Position.Y)
                {
                    BeforOpenAdd(item, 10);
                }
                // - - - Y Top - - - 
                // Y-tileSize X+tileSize
                if (item.Transform.Position.X + tileSize == target.Transform.Position.X && item.Transform.Position.Y - tileSize == target.Transform.Position.Y)
                {
                    //BeforOpenAdd(item, tileSize4);
                }
                // Y-tileSize X 0
                else if (item.Transform.Position.X == target.Transform.Position.X && item.Transform.Position.Y - tileSize == target.Transform.Position.Y)
                {
                    BeforOpenAdd(item, 10);
                }
                // Y-tileSize X-tileSize
                else if (item.Transform.Position.X - tileSize == target.Transform.Position.X && item.Transform.Position.Y - tileSize == target.Transform.Position.Y)
                {
                    //BeforOpenAdd(item, 14);
                }
            }

        }

        public void BeforOpenAdd(Tile cell, int gCost)
        {
            if (!close.Contains(cell) && !open.Contains(cell) && cell.TileType != TileTypeEnum.Block && cell.TileType != TileTypeEnum.Tower)
            {
                AddOpen(cell, gCost);
            }
            else
            {
                //if (cell.g > gCost)
                //{
                //	cell.g = gCost;
                //}
            }
        }

        public void GoHome()
        {
            while (true)
            {
                currentTile.Color = Color.Blue;
                if (currentTile == start)
                {
                    break;
                }
                currentTile = currentTile.LastTile;
            }
        }
    }
}
