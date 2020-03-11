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
				GuiButton tmp = new GuiButton();
				tmp.Text = SceneController.SceneContainer.Scenes[i].Name;
				tmp.Transform.Scale = new Vector2(150,50);
				tmp.Transform.Position = new Vector2(10, 60 * i);
				tmp.FontScale = new Vector2(0.4f, 0.4f);

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
