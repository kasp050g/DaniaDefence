using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
    public class StartInfo : Component
    {
        GuiImagePanel imagePanel;
        GuiText startInfoText;
        GuiButton guiButton;

        public override void Awake()
        {
            base.Awake();
            MadeThis();
        }
        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();
        }

        public void MadeThis()
        {
            // - - - - - Show Currency Image
            imagePanel = new GuiImagePanel(
                // Texture2D
                SpriteContainer.sprite["Pixel"],
                // Position
                new Vector2(
                    GraphicsSetting.ScreenSize.X / 2 -300,
                    GraphicsSetting.ScreenSize.Y - 550),
                // Scale
                new Vector2(600f, 350f),
                // Layer Depth
                0.999f,
                // Origin
                OriginPositionEnum.TopLeft
                );
            imagePanel.Color = Color.Black;
            Instantiate(imagePanel);

            string startText = "Move Camera With\n" +
                "W A S D keys\n\n" +
                "Left Click to set tower.\n" +
                "You cant delete towers so be careful";

            // - - - - - Start Info text
            startInfoText = new GuiText(
                // SpriteFont
                SpriteContainer.normalFont,
                // Texture2D
                startText,
                // Position
                new Vector2(
                    imagePanel.Transform.Position.X + 10,
                    imagePanel.Transform.Position.Y + 10
                    ),
                // Scale
                new Vector2(0.6f, 0.6f),
                // Layer Depth
                0.9991f,
                // Origin
                OriginPositionEnum.TopLeft
                );
            startInfoText.Color = Color.White;
            startInfoText.ParentGUI = imagePanel;
            Instantiate(startInfoText);

            // - - - - - Start Button
            guiButton = new GuiButton(
                // Texture2D
                SpriteContainer.sprite["Pixel"],
                // Position
                new Vector2(
                    imagePanel.Transform.Position.X + imagePanel.Transform.Scale.X / 2,
                    imagePanel.Transform.Position.Y + imagePanel.Transform.Scale.Y -10
                    ),
                // Scale
                new Vector2(150, 50),
                // Layer Depth
                0.9991f,
                // Origin
                OriginPositionEnum.BottomMid,
                // Sprite font
                SpriteContainer.normalFont,
                // Button Text
                "Start Game",
                // Font Scale
                new Vector2(0.5f,0.5f)
            );

            guiButton.ParentGUI = imagePanel;
            Instantiate(guiButton);

            guiButton.Color = Color.White;
            guiButton.FontColor = Color.Black;
            guiButton.IsHoveringColor = Color.Green;

            guiButton.OnClick = () => {
                myScene.PauseGame = false;
                imagePanel.IsActive = false;
                startInfoText.IsActive = false;
            };
        }
    }
}
