using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dania_Defence_Project
{
    public class _Tower : GameObject
    {
        #region Fields
        public float fireRate;
        public float currentFireRate;

        public float range = 300;
        public float speed = 100;
        public Vector2 velocity;

        public Vector2 myTarget;

        public TowerProjectile myProjectile;

        #endregion
        public _Tower()
        {
            sprite = SpriteContainer.sprite["Tower_Dennis"];
            transform.Position = new Vector2(0,0);
            transform.Scale = new Vector2((float)100f / 400f, (float)100f / 400f);
            layerDepth = 0.8f;
            originPositionEnum = OriginPositionEnum.BottomMid;
        }
        public _Tower(Texture2D _sprite, Vector2 _position, Vector2 _scale,float _layerDepth, OriginPositionEnum _origin)
        {
            sprite = _sprite;
            transform.Position = _position;
            transform.Scale = _scale;
            layerDepth = _layerDepth;
            originPositionEnum = _origin;
        }
        public override void Awake()
        {
            base.Awake();
        }
        public override void Start()
        {
            base.Start();
            Console.WriteLine(transform.Position);
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void FireProjectile()
        {
            if (myTarget != null && currentFireRate > 0)
            {
                currentFireRate -= (float)Time.deltaTime;
            }
        }

        //public void FindTarget()
        //{
        //    MouseState state = Mouse.GetState();

        //    var mouseX = state.Position.X;
        //    var mouseY = state.Position.Y;

        //    Vector2 newPosition = new Vector2(mouseX, mouseY);

        //    Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));

        //    myTarget = worldPosition;
        //}

        public virtual Rectangle TowerRangeCollision
        {
            get
            {
                return new Rectangle(
                    (int)transform.Position.X - (int)(range/2),
                    (int)transform.Position.Y - (int)(range / 2),
                    (int)(range),
                    (int)(range)
                    );
            }
        }
    }
}
