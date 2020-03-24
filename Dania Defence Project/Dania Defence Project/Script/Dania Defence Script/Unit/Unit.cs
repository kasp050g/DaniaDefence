using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dania_Defence_Project
{
	public class Unit : GameObject
	{
        protected Stat knowlegde = new Stat(); // henter knowlegde værdien fra stat classen
        protected Stat movementspeed = new Stat(); // henter movementspeed værdien fra stat classen
        protected bool isAlive = true; // en tjekker for om en unit er i live

        protected float moveSpeed = 100f;
        protected Tile myTarget;
        protected Vector2 velocity;
        protected int tileSize;
        protected UnitHealthBar_GUI unitHealthBar;
        protected int moenyOnDeath = 5;

        public virtual Rectangle UnitCollision
        {
            get
            {
                return new Rectangle(
                    (int)transform.Position.X - (int)(transform.Origin.X * transform.Scale.X),
                    (int)transform.Position.Y - (int)(transform.Origin.Y * transform.Scale.Y),
                    (int)(sprite.Width * transform.Scale.X),
                    (int)(sprite.Height * transform.Scale.Y)
                    );
            }
        }

        public Stat Knowlegde { get => knowlegde; set => knowlegde = value; }
        public Stat Movementspeed { get => movementspeed; set => movementspeed = value; }
        public bool IsAlive { get => isAlive; set => isAlive = value; }
        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public Tile MyTarget { get => myTarget; set => myTarget = value; }
        public Vector2 Velocity { get => velocity; set => velocity = value; }
        public int TileSize { get => tileSize; set => tileSize = value; }

        public Unit()
        {

        }
        public Unit(Tile _myTarget,int _tileSize)
		{
			this.myTarget = _myTarget;
			this.tileSize = _tileSize;
		}
		public override void Awake()
		{
            knowlegde.CurrentValue = 0;
            knowlegde.MaxValue = 100; // sætter hvad max værdien for knowlegde kan være (hvor meget hp units har)
            movementspeed.MaxValue = 100; // sætter hvor hurtigt units kan bevæge sig

            originPositionEnum = OriginPositionEnum.Mid;
			base.Awake();
            float newScale = (float)tileSize / 300;
            transform.Scale = new Vector2(newScale, newScale);
			layerDepth = 0.9f;

            unitHealthBar = new UnitHealthBar_GUI(
                SpriteContainer.sprite["Pixel"],
                this,
                1,
                1,
                tileSize,
                new Vector2(tileSize/2,tileSize/8),
                1,
                OriginPositionEnum.BottomLeft
                );
            Instantiate(unitHealthBar);
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

        public void Takedamage(float input) // method for når uniten tager skade
        {
            knowlegde.AddValue(input);
            unitHealthBar.StartFadeOut();
            if (knowlegde.CurrentValue >= knowlegde.MaxValue)
            {
                Die();
            }
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

        public void Die()
        {
            (myScene as Kasper_Scene).currentCoin += moenyOnDeath;
            (myScene as Kasper_Scene).UpdateLiveCoin();
            isAlive = false;
            //onUnitGraduation();
            Destroy(this);
            Destroy(unitHealthBar);
            isActive = false;
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
                    (myScene as Kasper_Scene).currentLive -= 1;
                    (myScene as Kasper_Scene).UpdateLiveCoin();
                    Die();
                }

			}
		}
	}
}
