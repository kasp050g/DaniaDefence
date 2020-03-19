using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{

    public class Unit: GameObject
    {
        //public event Action onUnitGraduation;


        protected Stat knowlegde = new Stat(); // henter knowlegde værdien fra stat classen
        protected Stat movementspeed = new Stat(); // henter movementspeed værdien fra stat classen
        protected bool isalive = true; // en tjekker for om en unit er i live

		public Tile myTarget;
		protected Vector2 velocity;
		protected int tileSize;
		public Unit()
		{

		}
		public Unit(Tile _myTarget, int _tileSize)
		{
			this.myTarget = _myTarget;
			this.tileSize = _tileSize;
		}
		public override void Awake() // dette er kode der køre inden spillet går i gang
		{
			MadeUnit();
			base.Awake();
			knowlegde.CurrentValue = knowlegde.MaxValue;
			movementspeed.CurrentValue = movementspeed.MaxValue;
            //knowlegde.MaxValue = 100; // sætter hvad max værdien for knowlegde kan være (hvor meget hp units har)
            //movementspeed.MaxValue = 100; // sætter hvor hurtigt units kan bevæge sig
        }

        public void Takedamage(float input) // method for når uniten tager skade
        {
            knowlegde.AddValue(input);
            if (knowlegde.CurrentValue >= knowlegde.MaxValue)
            {
                isalive = false;
                //onUnitGraduation();
            }
        }

        public override void Start() // den første gang spillet kommer til at gøre noget
        {
            base.Start();
        }

        public override void Update() // den der køre hele tiden, skade skal ske gennem denne
        {
            base.Update();
			if (myTarget != null)
			{
				Move();
			}
		}

        public override void Draw(SpriteBatch spriteBatch) //tegne sprites der høre til units
        {
            base.Draw(spriteBatch);
        }

		public void MadeUnit()
		{
			originPositionEnum = OriginPositionEnum.Mid;
			transform.Scale = new Vector2(20, 20);
			layerDepth = 1f;
		}

        public void UnitGraduation()
        {

				//onUnitGraduation();
				Destroy(this);
			
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

			myTarget = _Astar_Test_For_unit.GetAstarWay(myTarget, newTiles);
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

			if (transform.Position.Y < Yposition + offSet)
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

			if (velocity != Vector2.Zero)
			{
				velocity.Normalize();

				transform.Position += velocity * movementspeed.CurrentValue * Time.deltaTime;
			}

			double c = Math.Sqrt(tileSize * tileSize + tileSize * tileSize);

			if (Vector2.Distance(transform.Position, myTarget.Transform.Position + new Vector2(tileSize / 2, tileSize / 2)) < 5)
			{
				if ((myTarget as Tile).TileType != TileTypeEnum.Center)
				{
					UseAstar();
				}
				else
				{
					UnitGraduation();
				}

			}
		}
	}
}
