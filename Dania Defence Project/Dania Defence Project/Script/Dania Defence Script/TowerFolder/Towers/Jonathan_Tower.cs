﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dania_Defence_Project
{
	public class Jonathan_Tower : Towers
	{
		#region Constructor
		public Jonathan_Tower(Texture2D _sprite, Vector2 _position, Vector2 _scale, float _layerDepth, OriginPositionEnum _originPositionEnum, float _speed, float _fireRate) : base(_sprite, _position, _scale, _layerDepth, _originPositionEnum, _speed, _fireRate)
		{
		}

		public Jonathan_Tower()
		{
		}

		public void MakeTower()
		{
			sprite = SpriteContainer.sprite["Jonathan"];
			transform.Position = new Vector2(360, 330);
			Transform.Scale = new Vector2(0.25f, 0.25f);
			layerDepth = 0.25f;
			OriginPositionEnum = OriginPositionEnum.BottomMid;
			this.speed = 150;
			fireRate = 1f;
		}

		public override void Projectile()
		{
			myProjectile = new TowerProjectile(
				//Texture
				SpriteContainer.sprite["C_Sharp"],

				//Position
				new Vector2(transform.Position.X, transform.Position.Y - 125),

				//Scale
				new Vector2(0.5f, 0.5f),

				//Layer Depth
				0.2f,

				//Origin
				OriginPositionEnum.Mid,

				//Speed
				this.speed
				);

			Instantiate(myProjectile);

			base.Projectile();
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
		#endregion
	}
}
