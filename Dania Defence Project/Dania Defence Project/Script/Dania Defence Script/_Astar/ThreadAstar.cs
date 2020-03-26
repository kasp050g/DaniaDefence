using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Xna.Framework;

namespace Dania_Defence_Project
{
    public class ThreadAstar : Component
    {
        Thread theAstar;
        bool runAstar;
        public ThreadAstar()
        {
            
        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
            StarThread();
        }

        public override void Update()
        {
            base.Update();
        }

        public void StarThread()
        {
            theAstar = new Thread(RunAstar);
            theAstar.IsBackground = true;
            runAstar = true;
            theAstar.Start();
        }

        public void StopThread()
        {
            runAstar = false;
        }

        public void RunAstar()
        {
            Thread.Sleep(50);
            while (true)
            {
                while((myScene as Kasper_Scene).threadCanLoadList == true)
                {
                    //Thread.Sleep(1);
                }

                List<GameObject> gameObjects = new List<GameObject>();
                if ((myScene as Kasper_Scene).threadCanLoadList == true)
                gameObjects = new List<GameObject>(myScene.GameObjects);

                foreach (GameObject item in gameObjects)
                {
                    if (item is Unit)
                    {
                        Unit unit = (item as Unit);
                        if (Vector2.Distance(unit.Transform.Position, unit.MyTarget.Transform.Position + new Vector2(unit.TileSize / 2, unit.TileSize / 2)) < 5)
                        {
                            if ((unit.MyTarget as Tile).TileType != TileTypeEnum.Center)
                            {
                                //unit.UseAstar();
                                UseAstar(unit, gameObjects);
                            }
                            else
                            {
                                unit.Die(false);
                            }
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }

        public void UseAstar(Unit unit,List<GameObject> gameObjects)
        {

            List<Tile> newTiles = new List<Tile>();
            foreach (var item in gameObjects)
            {
                if (item is Tile)
                {
                    newTiles.Add(item as Tile);
                }
            }

            unit.MyTarget = _Astar_Test_For_unit.GetAstarWay(unit.MyTarget, newTiles);
        }


    }
}
