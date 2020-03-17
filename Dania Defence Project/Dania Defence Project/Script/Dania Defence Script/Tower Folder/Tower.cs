﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class Towers : GameObject
	{
		#region Fields
		public float fireRate;
		public float currentFireRate;
		#endregion

		#region Constructor
		public Towers(Texture2D _sprite, Vector2 _position, Vector2 _scale, float _layerDepth, 
			OriginPositionEnum _originPositionEnum, float _speed, float _fireRate)
		{
			this.sprite = _sprite;
			this.Transform.Position = _position;
			this.Transform.Scale = _scale;
			this.LayerDepth = _layerDepth;
			this.OriginPositionEnum = _originPositionEnum;
			this.speed = _speed;
			this.fireRate = _fireRate;
		}

		public void Projectile()
		{
			Instantiate(new TowerProjectile(
				//Texture
				SpriteContainer.sprite["TMP"],

				//Position
				transform.Position,

				//Layer Depth
				0.2f,

				//Origin
				OriginPositionEnum.Mid,

				//Speed
				this.speed
				));

			currentFireRate = fireRate;
		}

		public void MouseInput()
		{
			velocity = Vector2.Zero;

			//Checks and updates based on the Right Button
			if (currentFireRate <= 0)
			{
				Projectile();
			}
		}
		#endregion

		#region Methods
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
			MouseInput();

			if (currentFireRate > 0)
			{
				currentFireRate -= (float)Time.deltaTime;
			}

			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			Texture2D _sprite = sprite;
			Color _color = Color;

			spriteBatch.Draw(
				//Texture
				_sprite, 
				
				//Position
				this.transform.Position, 
				
				//Sprite Rectangle
				null, 
				
				//Colour
				Color, 
				
				//Rotation
				MathHelper.ToRadians(this.transform.Rotation), 
				
				//Origin
				this.transform.Origin, 
				
				//Scale
				this.transform.Scale, 
				
				//Sprite Effect
				this.spriteEffects, 
				
				//Layer Depth
				this.LayerDepth
				);
		}
		#endregion

	}
}