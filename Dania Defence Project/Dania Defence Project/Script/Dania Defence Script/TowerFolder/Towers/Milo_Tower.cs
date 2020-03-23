using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dania_Defence_Project
{
	public class Milo_Tower : Tower
	{
        #region Constructors

        public Milo_Tower(Texture2D _sprite, Vector2 _position, Vector2 _scale, float _layerDepth, OriginPositionEnum _origin, int _tileSize) : base(_sprite, _position, _scale, _layerDepth, _origin, _tileSize)
        {

        }

        public Milo_Tower()
        {

        }

        public Milo_Tower(Vector2 _position, Vector2 _scale, int _tileSize) : base(_position, _scale, _tileSize)
        {

        }




        #endregion

        #region Methods
        public override void Awake()
        {
            MakeTower();
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void MakeTower()
        {
            sprite = SpriteContainer.sprite["Tower_Milo"];
            transform.Scale = new Vector2((float)TileSize / 400, (float)TileSize / 400);
            layerDepth = 0.8f;
            originPositionEnum = OriginPositionEnum.BottomMid;
            this.speed = 300;
            fireRate = 1f;
        }

        public override void FireProjectile()
        {
            myProjectile = new TowerProjectile(
                // Mytarget Unit
                myTarget,
                // Texture
                SpriteContainer.sprite["Projectile_PowerPoint"],
                // Position
                new Vector2(transform.Position.X, transform.Position.Y - ((float)tileSize / 2f)),
                // Scale
                new Vector2(0.5f, 0.5f),
                // Layer Depth
                0.95f,
                // Origin
                OriginPositionEnum.Mid,
                // Speed
                this.speed,
                // Damage
                damage
            );

            Instantiate(myProjectile);

            base.FireProjectile();
        }
        #endregion
    }
}
