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
		GameObject mouseTile;
		public int sizeOfTile = 100;
		public WorldEditor(int _sizeOfTile)
		{
			this.sizeOfTile = _sizeOfTile;
		}
		public override void Awake()
		{
			base.Awake();
			MakeWorldEditorUI();
		}
		public override void Start()
		{
			base.Start();
			MadeTileOnMouse();
		}

		public override void Update()
		{
			base.Update();
			ShowTileOnMouse();
			SelectTileOnClick();
		}

		public void SelectTileOnClick()
		{
			if (Input.GetMouseButtonDown(MyMouseButtonsEnum.LeftButton) && !MyScene.IsMouseOverUI)
			{
				foreach (GameObject item in myScene.GameObjects)
				{
					if (item is Tile == true && item.Transform.Position == mouseTile.Transform.Position)
					{
                        (item as Tile).ChangeTile(TileTypeEnum.Tower);
					}
				}
			}
			if (Input.GetMouseButtonDown(MyMouseButtonsEnum.RightButton) && !MyScene.IsMouseOverUI)
			{
				foreach (GameObject item in myScene.GameObjects)
				{
					if (item is Tile == true && item.Transform.Position == mouseTile.Transform.Position)
					{
                        (item as Tile).ChangeTile(TileTypeEnum.Empty);
                    }
				}
			}
		}

		public void ShowTileOnMouse()
		{
			if (!MyScene.IsMouseOverUI)
			{
				int mousex = Mouse.GetState().Position.X;
				int mousey = Mouse.GetState().Position.Y;
				Vector2 newPosition = new Vector2(mousex, mousey);

				Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));

				int positonX = (int)(worldPosition.X / sizeOfTile) * sizeOfTile;
				int positonY = (int)(worldPosition.Y / sizeOfTile) * sizeOfTile;

				if (positonX < 0)
				{
					positonX -= sizeOfTile;
				}

				if (positonY < 0)
				{
					positonY -= sizeOfTile;
				}

				if (worldPosition.X > -sizeOfTile && worldPosition.X < 0.0f)
				{
					positonX = -sizeOfTile;
				}
				if (worldPosition.Y > -sizeOfTile && worldPosition.Y < 0.0f)
				{
					positonY = -sizeOfTile;
				}

				mouseTile.Transform.Position = new Vector2(positonX, positonY);
			}
		}

		public void MadeTileOnMouse()
		{
			mouseTile = new GameObject();
			mouseTile.Transform.Scale = new Vector2(sizeOfTile, sizeOfTile);
			mouseTile.LayerDepth = 0.5f;
			Instantiate(mouseTile);
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
