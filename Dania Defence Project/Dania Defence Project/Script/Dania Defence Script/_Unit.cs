using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dania_Defence_Project
{
	public class _Unit : GameObject
	{
		float moveSpeed = 100f;
		public Tile myTarget;
		Vector2 velocity;
		int tileSize;
		public _Unit(Tile _myTarget,int _tileSize)
		{
			this.myTarget = _myTarget;
			this.tileSize = _tileSize;
		}
		public override void Awake()
		{
			originPositionEnum = OriginPositionEnum.Mid;
			base.Awake();
			transform.Scale = new Vector2(20, 20);
			layerDepth = 1f;
		}
		public override void Start()
		{
			base.Start();
		}
		public override void Update()
		{
			base.Update();

			if (myTarget != null)
			{
				Move();
			}
		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public void UseAstar()
		{
			List<Tile> newTiles = new List<Tile>();
			foreach (var item in myScene.GameObjects)
			{
				if (item is Tile)
				{
					newTiles.Add(item as Tile);
				}
			}

			myTarget = _Astar_Test_For_unit.GetAstarWay(myTarget,newTiles);
		}



		public void Move()
		{
			int offSet = 1;
			velocity = Vector2.Zero;

			float Yposition = myTarget.Transform.Position.Y + (myTarget.TileSize / 2);
			float Xposition = myTarget.Transform.Position.X + (myTarget.TileSize / 2);

			if (transform.Position.Y + offSet > Yposition)
			{
				velocity += new Vector2(0, -1);
			}

			if (transform.Position.Y  < Yposition + offSet)
			{
				velocity += new Vector2(0, 1);
			}

			if (transform.Position.X + offSet > Xposition)
			{
				velocity += new Vector2(-1, 0);
			}

			if (transform.Position.X < Xposition + offSet)
			{
				velocity += new Vector2(1, 0);
			}

			if(velocity != Vector2.Zero)
			{
				velocity.Normalize();

				transform.Position += velocity * moveSpeed * Time.deltaTime;
			}

			double c = Math.Sqrt(tileSize * tileSize + tileSize * tileSize);		

			if (Vector2.Distance(transform.Position,myTarget.Transform.Position + new Vector2(tileSize / 2,tileSize / 2)) < 5)
			{
				if((myTarget as Tile).TileType != TileTypeEnum.Center)
				{
					UseAstar();
				}
				else
				{

				}

			}
		}
	}
}
