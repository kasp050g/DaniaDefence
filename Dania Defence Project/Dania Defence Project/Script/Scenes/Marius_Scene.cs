using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class Marius_Scene : Scene
	{
		public override void Initialize()
		{
			base.Initialize();
			TeacherTowers();
		}

		public override void OnSwitchToThisScene()
		{
			base.OnSwitchToThisScene();
		}

		public override void OnSwitchAwayFromThisScene()
		{
			base.OnSwitchAwayFromThisScene();
		}

		public override void Update()
		{
			HandleInput();
			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public void TeacherTowers()
		{
			Towers towerObjects = new Towers(
				//Texture
				SpriteContainer.sprite["Mikael"],

				//Position
				new Vector2(GraphicsSetting.ScreenSize.X / 4, GraphicsSetting.ScreenSize.Y / 4),

				//Scale
				new Vector2(0.33f, 0.33f),

				//Layer Depth
				0.25f,

				//Origin
				OriginPositionEnum.Mid);

			Instantiate(towerObjects);
		}

		public void Projectile()
		{
			Instantiate(new TowerProjectile(
				//Texture
				SpriteContainer.sprite["TMP"],

				//Position
				new Vector2(0.25f, 0.33f),

				//Scale
				new Vector2(0.75f, 0.75f),

				//Layer Depth
				0.2f,

				//Origin
				OriginPositionEnum.Mid
				));
		}

		public void HandleInput()
		{
			MouseState state = Mouse.GetState();

			if(state.RightButton == ButtonState.Pressed)
			{
				Projectile();
			}
		}
	}
}
