using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dania_Defence_Project
{
    public class Tower : GameObject
    {
        #region Fields
        protected float fireRate = 2;
        protected float currentFireRate;
        protected float range = 3;
        protected float speed = 300;
        protected int damage = 10;
        protected int tileSize = 0;
        protected Vector2 velocity;
        protected Unit myTarget;
        protected TowerProjectile myProjectile;
        protected bool myTargetIsInRange;
        protected float layerDepthPosition;
        protected int towerCost = 115;
        protected string name;

        public float FireRate { get => fireRate; set => fireRate = value; }
        public float CurrentFireRate { get => currentFireRate; set => currentFireRate = value; }
        public float Range { get => range; set => range = value; }
        public float Speed { get => speed; set => speed = value; }
        public int Damage { get => damage; set => damage = value; }
        public int TileSize { get => tileSize; set => tileSize = value; }
        public Vector2 Velocity { get => velocity; set => velocity = value; }
        public Unit MyTarget { get => myTarget; set => myTarget = value; }
        public TowerProjectile MyProjectile { get => myProjectile; set => myProjectile = value; }
        public int TowerCost { get => towerCost; set => towerCost = value; }
        public string Name { get => name; set => name = value; }
        public virtual Rectangle TowerRangeCollision
        {
            get
            {
                return new Rectangle(
                    (int)transform.Position.X - (int)(((range + 0.5f) * 2 * tileSize) / 2),
                    (int)transform.Position.Y - (int)(((range + 0.5f) * 2 * tileSize) / 2) - (int)(((float)tileSize * 0.98f) / 2f),
                    (int)(((range + 0.5f) * 2 * tileSize)),
                    (int)(((range + 0.5f) * 2 * tileSize))
                    );
            }
        }

        #endregion

        public Tower()
        {

        }
        public Tower(int _towerCost)
        {
            towerCost = _towerCost;
        }
        public Tower(Vector2 _position, Vector2 _scale, int _tileSize)
        {
            transform.Position = _position;
            transform.Scale = _scale;
            tileSize = _tileSize;

            layerDepthPosition = _position.Y / 1000000;
        }
        public Tower(Texture2D _sprite, Vector2 _position, Vector2 _scale, float _layerDepth, OriginPositionEnum _origin, int _tileSize,int _towerCost)
        {
            sprite = _sprite;
            transform.Position = _position;
            transform.Scale = _scale;
            layerDepth = _layerDepth;
            originPositionEnum = _origin;
            tileSize = _tileSize;
            towerCost = _towerCost;
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
            FindTarget();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                // Texture2D
                this.sprite,
                // Postion
                this.transform.Position,
                // Source Rectangle
                null,
                // Color
                this.color,
                // Rotation
                MathHelper.ToRadians(this.transform.Rotation),
                // Origin
                this.transform.Origin,
                // Scale
                this.transform.Scale,
                // SpriteEffects
                this.spriteEffects,
                // LayerDepth
                this.layerDepth + layerDepthPosition
            );
        }

        public virtual void FireProjectile()
        {
            currentFireRate = fireRate;


        }

        public void CheckIfTargetIsInRange()
        {
            if (MyTarget != null)
            {
                myTargetIsInRange = false;
                foreach (GameObject item in myScene.GameObjects)
                {
                    if (item is Unit)
                    {
                        if ((item as Unit) == myTarget && TowerRangeCollision.Intersects((item as Unit).UnitCollision))
                        {
                            myTargetIsInRange = true;
                            break;
                        }
                    }
                }
                if (myTargetIsInRange == false)
                {
                    myTarget = null;
                }
            }
        }

        public void FindTarget()
        {
            CheckIfTargetIsInRange();
            if (MyTarget == null)
            {
                List<Unit> tmp = new List<Unit>();
                foreach (GameObject item in myScene.GameObjects)
                {
                    if (item is Unit)
                    {
                        if (TowerRangeCollision.Intersects((item as Unit).UnitCollision))
                        {
                            tmp.Add((item as Unit));
                            //MyTarget = (item as Unit);
                        }
                    }
                }

                if (tmp.Count > 0)
                {
                    myTarget = tmp[Helper.GetRandomValue(0, tmp.Count)];
                }
            }
            else if (currentFireRate <= 0)
            {
                if (!myTarget.IsAlive)
                {
                    myTarget = null;
                }
                else
                {
                    FireProjectile();
                }
            }
            else
            {
                currentFireRate -= (float)Time.deltaTime;
            }
        }
    }
}
