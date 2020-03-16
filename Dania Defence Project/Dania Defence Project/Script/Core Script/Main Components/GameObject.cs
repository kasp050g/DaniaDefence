using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dania_Defence_Project
{
	public class GameObject : Component
	{
		protected OriginPositionEnum originPositionEnum = OriginPositionEnum.TopLeft;
		protected SpriteEffects spriteEffects = SpriteEffects.None;
		protected Transform transform = new Transform();
		protected Color color = Color.White;
		protected float layerDepth = 0;
		protected Texture2D sprite;
		protected Vector2 velocity;
		protected float speed;

		public OriginPositionEnum OriginPositionEnum { get => originPositionEnum; set => originPositionEnum = value; }
		public SpriteEffects SpriteEffects { get => spriteEffects; set => spriteEffects = value; }
		public Transform Transform { get => transform; set => transform = value; }
		public Color Color { get => color; set => color = value; }
		public float LayerDepth { get => layerDepth; set => layerDepth = value; }
		public Texture2D Sprite { get => sprite; set => sprite = value; }
		public Vector2 Velocity { get => velocity; set => velocity = value; }
		public float Speed { get => speed; set => speed = value; }

        public virtual Rectangle Rectangle
        {
            get
            {
                return new Rectangle(
                    (int)Transform.Position.X - (int)(Transform.Origin.X * Transform.Scale.X),
                    (int)Transform.Position.Y - (int)(Transform.Origin.Y * Transform.Scale.Y),
                    (int)(sprite.Width * Transform.Scale.X),
                    (int)(sprite.Height * Transform.Scale.Y));
            }
        }

        public override void Awake()
		{
			if (Sprite == null)
			{
				Sprite = SpriteContainer.sprite["Pixel"];
			}
			UpdateOrigin();
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

		public virtual void Draw(SpriteBatch spriteBatch)
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
				this.layerDepth
			);
		}

		private void UpdateOrigin()
		{
			// --- Top ---

			// top left
			if (OriginPositionEnum.TopLeft == originPositionEnum)
			{
				Transform.Origin = new Vector2(0, 0);
			}
			// top mid
			if (OriginPositionEnum.TopMid == originPositionEnum)
			{
				Transform.Origin = new Vector2((float)sprite.Width / 2f, 0);
			}
			// top rigth
			if (OriginPositionEnum.TopRight == originPositionEnum)
			{
				Transform.Origin = new Vector2((float)sprite.Width, 0);
			}

			// --- Mid ---

			// mid left
			if (OriginPositionEnum.MidLeft == originPositionEnum)
			{
				Transform.Origin = new Vector2(0, (float)sprite.Height / 2f);
			}
			// mid 
			if (OriginPositionEnum.Mid == originPositionEnum)
			{
				Transform.Origin = new Vector2((float)sprite.Width / 2f, (float)sprite.Height / 2f);
			}
			// mid rigth
			if (OriginPositionEnum.MidRight == originPositionEnum)
			{
				Transform.Origin = new Vector2((float)sprite.Width, (float)sprite.Height / 2f);
			}

			// --- Bottom ---

			// bottom left
			if (OriginPositionEnum.BottomLeft == originPositionEnum)
			{
				Transform.Origin = new Vector2(0, (float)sprite.Height);
			}
			// bottom mid
			if (OriginPositionEnum.BottomMid == originPositionEnum)
			{
				Transform.Origin = new Vector2((float)sprite.Width / 2f, (float)sprite.Height);
			}
			// bottom rigth
			if (OriginPositionEnum.BottomRight == originPositionEnum)
			{
				Transform.Origin = new Vector2((float)sprite.Width, (float)sprite.Height);
			}
		}
	}
}
