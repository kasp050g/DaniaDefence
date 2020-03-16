using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class PickScene : Scene
	{
		public override void Initialize()
		{
			base.Initialize();
			PickButton();
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

		public void PickButton()
		{
			for (int i = 1; i < SceneController.SceneContainer.Scenes.Count; i++)
			{
				GuiButton tmp = new GuiButton(
					// Texture2D
					SpriteContainer.sprite["Pixel"],
					// Position
					new Vector2(10, 60 * i),
					// Scale
					new Vector2(150, 50),
					// Layer Depth
					0.9f,
					// Orgin
					OriginPositionEnum.BottomLeft,
					// SpriteFont
					SpriteContainer.normalFont,
					// Text
					SceneController.SceneContainer.Scenes[i].Name,
					// Font Scale
					new Vector2(0.4f, 0.4f)
					);

				// Here we Add the onClick
				// we tell it to load a new scene
				int _sceneNumber = i;
				tmp.OnClick = () =>
				{					
					SceneController.CurrentScene = SceneController.SceneContainer.Scenes[_sceneNumber];
				};

				Instantiate(tmp);
			}
		}


	}
}
