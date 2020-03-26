using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dania_Defence_Project
{
    public class TowerButton_GUI : GuiButton
    {
        private Tower tower;
        private GuiText _text;
        private GuiImagePanel _background;
        private string text;

        public Tower Tower { get => tower; set => tower = value; }

        public TowerButton_GUI(Texture2D _sprite, Vector2 _position, Vector2 _scale, float _layerDepth, OriginPositionEnum _originPositionEnum) : base(_sprite, _position, _scale, _layerDepth, _originPositionEnum)
        {

        }

        public TowerButton_GUI(Texture2D _sprite, Vector2 _position, Vector2 _scale, float _layerDepth, OriginPositionEnum _originPositionEnum, SpriteFont _font, string _text, Vector2 _fontScale) : base(_sprite, _position, _scale, _layerDepth, _originPositionEnum, _font, _text, _fontScale)
        {

        }

        public override void Awake()
        {
            base.Awake();
            MakeHoveringInfo();
            MakeText();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();

            if (isHovering == true)
            {
                _background.IsActive = true;
                _text.IsActive = true;
            }
            else
            {
                _background.IsActive = false;
                _text.IsActive = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void MakeText()
        {
            text = "Name: ";
            text += tower.Name;
            text += "\nTower Cost: ";
            text += tower.TowerCost.ToString();
            text += "\nFireRate: ";
            text += tower.FireRate.ToString();
            text += "\nTile Range: ";
            text += tower.Range.ToString();
            text += "\nDamage: ";
            text += tower.Damage.ToString();
            text += "\nProjectile Speed: ";
            text += tower.Speed.ToString();

            _text.Text = text;
        }

        public void MakeHoveringInfo()
        {
            // Show Life Image
            _background = new GuiImagePanel(
                // Texture2D
                SpriteContainer.sprite["Pixel"],
                // Position
                new Vector2(10, -10),
                // Scale
                new Vector2(180f, 125f),
                // Layer Depth
                0.99f,
                // Origin
                OriginPositionEnum.BottomLeft
                );
            _background.Color = Color.Black;
            _background.Transform.Position += this.Transform.Position;
            Instantiate(_background);

            // Show Life Text
            _text = new GuiText(
                // SpriteFont
                SpriteContainer.normalFont,
                // Texture2D
                "Life: ?",
                // Position
                new Vector2(5, 5),
                // Scale
                new Vector2(0.4f, 0.4f),
                // Layer Depth
                0.999f,
                // Origin
                OriginPositionEnum.MidRight
                );
            _text.ParentGUI = _background;
            _text.Transform.Position += _text.ParentGUI.Transform.Position + new Vector2(0,-125f);
            Instantiate(_text);
        }
    }
}
