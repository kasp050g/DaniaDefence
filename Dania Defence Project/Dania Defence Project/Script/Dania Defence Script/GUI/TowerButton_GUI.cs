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
        }

        public override void Start()
        {
            base.Start();
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
