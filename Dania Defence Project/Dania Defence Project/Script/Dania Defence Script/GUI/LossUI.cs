using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
    public class LossUI : Component
    {
        GuiImagePanel imagePanel;
        GuiText lossText;
        GuiButton guiButton;

        public GuiImagePanel ImagePanel { get => imagePanel; set => imagePanel = value; }
        public GuiText LossText { get => lossText; set => lossText = value; }
        public GuiButton GuiButton { get => guiButton; set => guiButton = value; }

        public override void Awake()
        {
            base.Awake();
            MadeThis();
            Close();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();
        }

        public void Open()
        {
             imagePanel.IsActive = true;
             guiButton.IsActive = true;
             lossText.IsActive = true;
        }

        public void Close()
        {
            imagePanel.IsActive = false;
            guiButton.IsActive = false;
            lossText.IsActive = false;
        }

        public void MadeThis()
        {
            // - - - - - Show Currency Image
            imagePanel = new GuiImagePanel(
                // Texture2D
                SpriteContainer.sprite["Pixel"],
                // Position
                new Vector2(
                    GraphicsSetting.ScreenSize.X / 2 - 400,
                    GraphicsSetting.ScreenSize.Y - 550),
                // Scale
                new Vector2(800f, 350f),
                // Layer Depth
                0.999f,
                // Origin
                OriginPositionEnum.TopLeft
                );
            imagePanel.Color = Color.Black;
            Instantiate(imagePanel);

            string startText = "Too many students failed\n" +
                "Game over\n\n" +
                "\n" +
                "\n" +
                "Want to become a game developer who code games?\n"+
                "Email Sheena Ann Bilde Healy Now! shhe@eadania.dk"
                ;

            // - - - - - Start Info text
            lossText = new GuiText(
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
            lossText.Color = Color.White;
            lossText.ParentGUI = imagePanel;
            Instantiate(lossText);

            // - - - - - Start Button
            guiButton = new GuiButton(
                // Texture2D
                SpriteContainer.sprite["Pixel"],
                // Position
                new Vector2(
                    imagePanel.Transform.Position.X + imagePanel.Transform.Scale.X / 2,
                    imagePanel.Transform.Position.Y + imagePanel.Transform.Scale.Y - 10
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
                "Restart Game",
                // Font Scale
                new Vector2(0.5f, 0.5f)
            );

            guiButton.ParentGUI = imagePanel;
            Instantiate(guiButton);

            guiButton.Color = Color.White;
            guiButton.FontColor = Color.Black;
            guiButton.IsHoveringColor = Color.Green;

            guiButton.OnClick = () => {
                SceneController.CurrentScene = new Kasper_Scene();
            };
        }
    }
}
