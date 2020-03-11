using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dania_Defence_Project
{
	public class TestScene01 : Scene
	{
        PlayerTest playerTest = new PlayerTest();
        public override void Initialize()
		{
			base.Initialize();
			
			playerTest.Transform.Scale = new Vector2(20f, 20f);
			playerTest.Transform.Position = new Vector2(1, 1);
			playerTest.Sprite = SpriteContainer.sprite["Pixel"];
			Instantiate(playerTest);

            

			JamenTest jamen = new JamenTest();
			jamen.Transform.Scale = new Vector2(5f, 5f);
			jamen.Transform.Position = new Vector2(200, 0);
			jamen.Player = playerTest.Transform;
			Instantiate(jamen);

			JamenTest jamen01 = new JamenTest();
			jamen01.Transform.Scale = new Vector2(5f, 5f);
			jamen01.Transform.Position = new Vector2(300, 0);
			jamen01.Player = jamen.Transform;
			Instantiate(jamen01);

			JamenTest jamen02 = new JamenTest();
			jamen02.Transform.Scale = new Vector2(5f, 5f);
			jamen02.Transform.Position = new Vector2(400, 0);
			jamen02.Player = jamen01.Transform;
			Instantiate(jamen02);

			TemplateObject jojoj = new TemplateObject();
			jojoj.Transform.Scale = new Vector2(5f, 5f);
			jojoj.Transform.Position = new Vector2(-200, -200);
			jojoj.object01 = playerTest.Transform;
			jojoj.object02 = jamen.Transform;
			Instantiate(jojoj);

            GuiButton guiButton = new GuiButton();
            guiButton.Text = "Hey";
            guiButton.Transform.Scale = new Vector2(1, 1);
            guiButton.Transform.Scale = new Vector2(100, 50);
            guiButton.Color = Color.Red;
            guiButton.HoveringColor = Color.Blue;
			guiButton.OriginPositionEnum = OriginPositionEnum.BottomMid;
			guiButton.Transform.Position = new Vector2(GraphicsSetting.ScreenSize.X / 2, GraphicsSetting.ScreenSize.Y);
			guiButton.OnClick = () => { Console.WriteLine("Click that button"); };
            Instantiate(guiButton);
		}

		public override void OnSwitchToThisScene()
		{
            SceneController.Camera.Target = playerTest;

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
	}
}
