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
    public class GuiButton : GUI
    {
        #region Fields

        private MouseState currentMouse;
        private MouseState previousMouse;
        private bool isHovering;

        protected Action onClick;
        protected SpriteFont font;

        protected Color hoveringColor = Color.Gray;
        protected Color fontColor = Color.Black;
        protected Color fontColorIsHovering = Color.Black;
        protected string text;

        protected Texture2D isHoveringSprite;
        protected Vector2 fontScale = new Vector2(1, 1);

        #endregion



        #region Properties

        public Action OnClick { get => onClick; set => onClick = value; }
        public SpriteFont Font { get => font; set => font = value; }
        public Color HoveringColor { get => hoveringColor; set => hoveringColor = value; }
        public Color FontColor { get => fontColor; set => fontColor = value; }
        public Color FontColorIsHovering { get => fontColorIsHovering; set => fontColorIsHovering = value; }
        public string Text { get => text; set => text = value; }
        public Texture2D IsHoveringSprite { get => isHoveringSprite; set => isHoveringSprite = value; }
        public Vector2 FontScale { get => fontScale; set => fontScale = value; }

        #endregion

        public override void Awake()
        {
            if(font == null)
            {
                font = SpriteContainer.normalFont;
            }
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();

            if (ShowGUI == true)
            {
                previousMouse = currentMouse;
                currentMouse = Mouse.GetState();

                Rectangle mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

                isHovering = false;

                if (mouseRectangle.Intersects(Rectangle))
                {
                    isHovering = true;

                    if (Input.GetMouseButtonDown(MyMouseButtonsEnum.LeftButton))
                    {
                        if (onClick != null)
                        {
                            onClick();
                        }
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (ShowGUI == true)
            {
                Color _color = Color;
                Color _fontColor = fontColor;
                Texture2D _sprite = sprite;

                if (isHovering)
                {
                    _color = hoveringColor;
                    _fontColor = fontColorIsHovering;
                    if (isHoveringSprite != null)
                        _sprite = isHoveringSprite;
                }

                spriteBatch.Draw(
                    // Texture2D
                    _sprite,
                    // Position
                    this.transform.Position,
                    // Source Rectangle
                    null,
                    // Color
                    _color,
                    // Rotation
                    MathHelper.ToRadians(this.transform.Rotation),
                    // Origin
                    this.transform.Origin,
                    // Scale
                    this.transform.Scale,
                    // SpriteEffects
                    this.spriteEffects,
                    // LayerDepth
                    this.layerDepth
                );

                if (!string.IsNullOrEmpty(Text))
                {
                    var x = (Rectangle.X + (Rectangle.Width / 2)) - (font.MeasureString(Text).X / 2) * FontScale.X;
                    var y = (Rectangle.Y + (Rectangle.Height / 2)) - (font.MeasureString(Text).Y / 2) * FontScale.Y;

                    spriteBatch.DrawString(
                        // SpriteFont
                        font,
                        // String text
                        Text,
                        // Position
                        new Vector2(x, y),
                        // Color
                        _fontColor,
                        // Rotation
                        MathHelper.ToRadians(0),
                        // Origin
                        Vector2.Zero,
                        // Scale
                        FontScale,
                        // SpriteEffects
                        SpriteEffects.None,
                        // LayerDepth
                        layerDepth + 0.05f
                    );
                }
            }
        }
    }
}
