using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public static class _Astar_Test_For_unit 
	{
		public static bool runAstar = true;
		static int  tileSize = 1;
		static Tile start;
		static Tile goal;

		static Tile currentTile;

		static List<Tile> open = new List<Tile>();
		static List<Tile> close = new List<Tile>();

		public static List<Tile> tiles = new List<Tile>();

		public static int TileSize { get => tileSize; set => tileSize = value; }

		public static Tile GetAstarWay(Tile _myPosition,List<Tile> _tiles)
		{
			tiles.Clear();
			open.Clear();
			close.Clear();

			start = _myPosition;
			tiles = _tiles;

			StartAndFindGoal(tiles);
			MainLoop();

			return currentTile;
		}

		public static void StartAndFindGoal(List<Tile> _tiles)
		{
			foreach (Tile item in _tiles)
			{
				if (item.TileType == TileTypeEnum.Center)
				{
					goal = item;
				}
			}
			AddOpen(start, 0);
		}

		public static void MainLoop()
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

		public static void FindLowerCostCell()
		{
			currentTile = open[0];
			foreach (Tile item in open)
			{
				if (currentTile.F > item.F || currentTile.F >= item.F && currentTile.H > item.H)
				{
					currentTile = item;
				}
			}

			open.Remove(currentTile);
			close.Add(currentTile);
		}

		public static void AddOpen(Tile cell, int gCost)
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


		public static void CellroundTarget(Tile target)
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

		public static void BeforOpenAdd(Tile cell, int gCost)
		{
			if (!close.Contains(cell) && !open.Contains(cell) && cell.TileType != TileTypeEnum.Block && cell.TileType != TileTypeEnum.Tower)
			{
				AddOpen(cell, gCost);
			}
		}

		public static void GoHome()
		{
			while (true)
			{
				if (currentTile.LastTile == start)
				{
					break;
				}
				currentTile = currentTile.LastTile;
			}
		}
	}
}
