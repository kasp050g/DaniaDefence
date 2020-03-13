using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class WorldEditor : Component
	{
		
		public override void Awake()
		{
			base.Awake();
			MakeWorldEditorUI();
		}
		public override void Start()
		{
			base.Start();
		}

		public override void Update()
		{
			base.Update();
		}



		public void MakeWorldEditorUI()
		{
			#region Button Panel
			// Button Image Panel
			GuiImagePanel buttonImagePanel = new GuiImagePanel(
				// Texture2D
				SpriteContainer.sprite["Pixel"],
				// Position
				new Vector2(0, GraphicsSetting.ScreenSize.Y),
				// Scale
				new Vector2(GraphicsSetting.ScreenSize.X, 100),
				// Layer Depth
				0.5f,
				// Origin
				OriginPositionEnum.BottomLeft
				);
			Instantiate(buttonImagePanel);
			#endregion

			#region Tile
			// Made Tile
			for (int i = 0; i < 4; i++)
			{
				GuiButton guiButton = new GuiButton(
				// Texture2D
				SpriteContainer.sprite["Pixel"],
				// Position
				new Vector2(50 + i * 100, -85),
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

		}
	}
}
