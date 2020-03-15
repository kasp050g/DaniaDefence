using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dania_Defence_Project
{
	public class Kasper_Scene : Scene
	{
		public override void Initialize()
		{
			base.Initialize();
			GridBox();
			MakeGameGui();

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

		public void MakeGameGui()
		{
			#region Button Panel
			// Button Image Panel
			GuiImagePanel buttonImagePanel = new GuiImagePanel(
				// Texture2D
				SpriteContainer.sprite["Pixel"],
				// Position
				new Vector2(0,GraphicsSetting.ScreenSize.Y),
				// Scale
				new Vector2(GraphicsSetting.ScreenSize.X,100),
				// Layer Depth
				0.5f,
				// Origin
				OriginPositionEnum.BottomLeft
				);
			Instantiate(buttonImagePanel);
			#endregion

			#region Tower buttons
			// Made Tower Button's
			for (int i = 0; i < 4; i++)
			{
				GuiButton guiButton = new GuiButton(
				// Texture2D
				SpriteContainer.sprite["Pixel"],
				// Position
				new Vector2(50 + i * 100,-85),
				// Scale
				new Vector2(70, 70),
				// Layer Depth
				0.9f,
				// Origin
				OriginPositionEnum.TopLeft
				);

				guiButton.ParentGUI = buttonImagePanel;
				guiButton.Transform.Position += buttonImagePanel.Transform.Position;
				guiButton.Color = Color.Blue;
				guiButton.IsHoveringColor = Color.Red;

				Instantiate(guiButton);
			}
			#endregion

			#region Show Currency 
			// Show Currency Image
			GuiImagePanel showCurrencyImage = new GuiImagePanel(
				// Texture2D
				SpriteContainer.sprite["Pixel"],
				// Position
				new Vector2(GraphicsSetting.ScreenSize.X - 100, 20),
				// Scale
				new Vector2(40,40),
				// Layer Depth
				0.9f,
				// Origin
				OriginPositionEnum.TopRight
				);
			Instantiate(showCurrencyImage);

			// Show Currency Text
			GuiText showCurrencyText = new GuiText(
				// SpriteFont
				SpriteContainer.normalFont,
				// Texture2D
				"Money: ?",
				// Position
				new Vector2(5, 10),
				// Scale
				new Vector2(0.4f, 0.4f),
				// Layer Depth
				0.9f,
				// Origin
				OriginPositionEnum.MidRight
				);
			showCurrencyText.ParentGUI = showCurrencyImage;
			showCurrencyText.Transform.Position += showCurrencyText.ParentGUI.Transform.Position;
			Instantiate(showCurrencyText);
			#endregion

			#region Show Life
			// Show Life Image
			GuiImagePanel showLifeImage = new GuiImagePanel(
				// Texture2D
				SpriteContainer.sprite["Pixel"],
				// Position
				new Vector2(20, 20),
				// Scale
				new Vector2(40, 40),
				// Layer Depth
				0.9f,
				// Origin
				OriginPositionEnum.TopLeft
				);
			Instantiate(showLifeImage);

			// Show Life Text
			GuiText showLifeText = new GuiText(
				// SpriteFont
				SpriteContainer.normalFont,
				// Texture2D
				"Life: ?",
				// Position
				new Vector2(5, 10),
				// Scale
				new Vector2(0.4f, 0.4f),
				// Layer Depth
				0.9f,
				// Origin
				OriginPositionEnum.MidRight
				);
			showLifeText.ParentGUI = showLifeImage;
			showLifeText.Transform.Position += showLifeText.ParentGUI.Transform.Position + new Vector2(showLifeText.ParentGUI.Transform.Scale.X,0);
			Instantiate(showLifeText);
			#endregion
		}

		public void GridBox()
		{
			for (int x = 0; x < 100; x++)
			{
				for (int y = 0; y < 100; y++)
				{
					ShowGrid showGrid = new ShowGrid();
					showGrid.Transform.Position = new Vector2(100 * x, 100 * y);
					showGrid.Transform.Position -= new Vector2(1000, 1000);
					Instantiate(showGrid);
				}
			}
		}
	}
}
