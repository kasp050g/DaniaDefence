using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dania_Defence_Project
{
	public class Tile : GameObject
	{
        private TileTypeEnum tileType = TileTypeEnum.Empty;
        private _Tower tower;
        private int tileSize;

        // Astar
        private int _f;
        private int _h;
        private int _g;
        private Tile lastTile;

        public TileTypeEnum TileType { get => tileType; set => tileType = value; }
        public _Tower Tower { get => tower; set => tower = value; }
        // Astar
        public int F { get => _f; set => _f = value; }
        public int H { get => _h; set => _h = value; }
        public int G { get => _g; set => _g = value; }
        public Tile LastTile { get => lastTile; set => lastTile = value; }
		public int TileSize { get => tileSize; set => tileSize = value; }

		public Tile(int _tileSize)
        {
            this.TileSize = _tileSize;
        }
        public override void Awake()
		{
            tower = new _Tower("Tower_Dennis");
            float towerSize = (float)TileSize / 400;
            tower.Transform.Scale = new Vector2(towerSize, towerSize);
            tower.Transform.Position = transform.Position + new Vector2(TileSize / 2, ((float)TileSize * 0.98f));
            tower.LayerDepth = 0.8f;
            ChangeTile(tileType);
            Instantiate(tower);
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

            spriteBatch.Draw(
                // Texture2D
                sprite,
                // Position
                this.transform.Position,
                // Source Rectangle
                null,
                // Color
                Color.Black,
                // Rotation
                MathHelper.ToRadians(this.transform.Rotation),
                // Origin
                this.transform.Origin,
                // Scale
                new Vector2(TileSize, 1),
                // SpriteEffects
                this.spriteEffects,
                // LayerDepth
                this.layerDepth + 0.001f
            );
            spriteBatch.Draw(
                // Texture2D
                sprite,
                // Position
                this.transform.Position,
                // Source Rectangle
                null,
                // Color
                Color.Black,
                // Rotation
                MathHelper.ToRadians(this.transform.Rotation),
                // Origin
                this.transform.Origin,
                // Scale
                new Vector2(1, TileSize),
                // SpriteEffects
                this.spriteEffects,
                // LayerDepth
                this.layerDepth + 0.001f
            );
        }
        public void ChangeTile(TileTypeEnum _tileType)
        {
            switch (_tileType)
            {
                case TileTypeEnum.Empty:
                    tower.IsActive = false;
                    tileType = _tileType;
                    Color = Color.ForestGreen;
                    break;
                case TileTypeEnum.Block:
                    tower.IsActive = false;
                    tileType = _tileType;
                    Color = Color.SaddleBrown;
                    break;
                case TileTypeEnum.Tower:
                    tower.IsActive = true;
                    tileType = _tileType;
                    Color = Color.GreenYellow;
                    break;
                case TileTypeEnum.Center:
                    tower.IsActive = false;
                    break;
                case TileTypeEnum.Spawn:
                    tower.IsActive = false;
                    break;
                default:
                    break;
            }
        }
    }
}
