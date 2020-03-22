using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class _WaveTest : Component
	{
		Tile spawnTile;
		Vector2 startPosition;
		int tileSize;

		public _WaveTest(int _tileSize)
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
			foreach (var item in myScene.GameObjects)
			{
				if (item is Tile && (item as Tile).TileType == TileTypeEnum.Spawn)
				{
					spawnTile = item as Tile;
					startPosition = spawnTile.Transform.Position;
					startPosition += new Vector2((myScene as Kasper_Scene).sizeOfTile / 2, (myScene as Kasper_Scene).sizeOfTile / 2);
				}
			}
		}
		public override void Update()
		{
			base.Update();
			if (Input.GetKeyDown(Microsoft.Xna.Framework.Input.Keys.F))
			{
				SwaperUnit();
			}
		}

		public void SwaperUnit()
		{
			Unit_Kasper unit = new Unit_Kasper(spawnTile, tileSize);
			foreach (var item in myScene.GameObjects)
			{
				//if (item is Tile && (item as Tile).TileType == TileTypeEnum.Center)
				//{
				//	unit.myTarget = (item as Tile);
				//}
				if (item is Tile && (item as Tile).TileType == TileTypeEnum.Spawn)
				{
					unit.Transform.Position = item.Transform.Position;
					unit.Transform.Position += new Vector2((myScene as Kasper_Scene).sizeOfTile / 2, (myScene as Kasper_Scene).sizeOfTile / 2);
				}
			}
			
			Instantiate(unit);
		}
	}
}
