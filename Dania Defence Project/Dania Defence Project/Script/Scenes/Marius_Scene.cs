using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class Marius_Scene : Scene
	{
		#region Scene Nedarving
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
			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
		#endregion

		#region Constructors
		public void TeacherTowers()
		{
			Towers DennisTower = new Towers(
				//Texture
				SpriteContainer.sprite["Dennis"],

				//Position
				new Vector2(-320, 180),

				//Scale
				new Vector2(0.25f, 0.25f),

				//Layer Depth
				0.25f,

				//Origin
				OriginPositionEnum.Mid, 
				
				//Speed
				60f,

				//Fire Rate
				1f
				);

			Towers MiloTower = new Towers(SpriteContainer.sprite["Milo"], new Vector2(0, 180), 
				new Vector2(0.25f, 0.25f), 0.25f, OriginPositionEnum.Mid, 300f, 1f);

			Towers MikaelTower = new Towers(SpriteContainer.sprite["Mikael"], new Vector2(360, 180),
				new Vector2(0.25f, 0.25f), 0.25f, OriginPositionEnum.Mid, 600f, 0.33f);

			Instantiate(DennisTower);
			Instantiate(MiloTower);
			Instantiate(MikaelTower);
		}
		#endregion
	}
}
