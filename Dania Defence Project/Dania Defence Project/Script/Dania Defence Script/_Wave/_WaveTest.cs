using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class _WaveTest : GameObject
	{
		Tile spawnTile;
		Vector2 startPosition;
		int tileSize;

        float time = 1.0f;
        float currentTime;
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

            if(currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                currentTime = time;
                SwaperUnit();
            }
		}

		public void SwaperUnit()
		{
            List<Unit> units = new List<Unit>();


            units.Add(new Unit_Kasper(spawnTile, tileSize));
            units.Add(new Unit_Casper(spawnTile, tileSize));
            units.Add(new Unit_Marius(spawnTile, tileSize));
            //units.Add(new Unit_GordenFreeMan(spawnTile, tileSize));


   //         Unit_Kasper unit1 = new Unit_Kasper(spawnTile, tileSize);
			//Unit_Casper unit2 = new Unit_Casper(spawnTile, tileSize);
			//Unit_Marius unit3 = new Unit_Marius(spawnTile, tileSize);
			//Unit_GordenFreeMan unit4 = new Unit_GordenFreeMan(spawnTile, tileSize);

            Unit unit = units[Helper.GetRandomValue(0, units.Count)];

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
