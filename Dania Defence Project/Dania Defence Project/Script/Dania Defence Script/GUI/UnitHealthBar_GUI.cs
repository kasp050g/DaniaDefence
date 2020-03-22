using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
    public class UnitHealthBar_GUI : GUI
    {
        #region Fields
        private Unit unit;
        private float fadeTime;
        private float currentFadeTime;
        private float timeBeforFade;
        private float currentTimeBeforFade;
        private int tileSize;
        private Color healthBarcolor;
        private Color currentHealthBarcolor;
        private Color backGroundColor;
        private Color currentBackGroundColor;
        private Vector2 healthBarScale;
        #endregion

        #region Properties
        public Unit Unit { get => unit; set => unit = value; }
        public float FadeTime { get => fadeTime; set => fadeTime = value; }
        public float CurrentFadeTime { get => currentFadeTime; set => currentFadeTime = value; }
        public int TileSize { get => tileSize; set => tileSize = value; }
        #endregion

        #region Constructor
        public UnitHealthBar_GUI(Texture2D _sprite, Unit _unit,float _timeBeforFade,float _fadeTime,int _tileSize, Vector2 _scale, float _layerDepth, OriginPositionEnum _originPositionEnum)
        {
            this.sprite = _sprite;
            this.unit = _unit;
            this.timeBeforFade = _timeBeforFade;
            this.fadeTime = _fadeTime;
            this.tileSize = _tileSize;
            this.transform.Scale = _scale;
            this.layerDepth = _layerDepth;
            this.originPositionEnum = _originPositionEnum;
        }
        #endregion

        #region Core Methods
        public override void Awake()
        {
            healthBarcolor = Color.Blue;
            backGroundColor = Color.CornflowerBlue;
            IsWorldGui = true;
            MoveWithUnit();
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
            StartFadeOut();
        }

        public override void Update()
        {
            base.Update();
            MoveWithUnit();
            TimeToStartFadeOut();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                // Texture2D
                sprite,
                // Position
                this.transform.Position,
                // Source Rectangle
                null,
                // Color
                currentHealthBarcolor,
                // Rotation
                MathHelper.ToRadians(this.transform.Rotation),
                // Origin
                this.transform.Origin,
                // Scale
                healthBarScale,
                // SpriteEffects
                this.spriteEffects,
                // LayerDepth
                this.layerDepth
            );
            spriteBatch.Draw(
                // Texture2D
                sprite,
                // Position
                this.transform.Position,
                // Source Rectangle
                null,
                // Color
                currentBackGroundColor,
                // Rotation
                MathHelper.ToRadians(this.transform.Rotation),
                // Origin
                this.transform.Origin,
                // Scale
                this.transform.Scale,
                // SpriteEffects
                this.spriteEffects,
                // LayerDepth
                this.layerDepth - 0.0001f
            );
        }
        #endregion

        #region Methods


        public void SizeOfHealtBar()
        {
            healthBarScale = new Vector2(
                transform.Scale.X * ((float)unit.Knowlegde.CurrentValue / (float)unit.Knowlegde.MaxValue),
                transform.Scale.Y
                );
        }
        public void MoveWithUnit()
        {
            Vector2 offset = new Vector2(-tileSize/4, - tileSize/2);
            transform.Position = unit.Transform.Position + offset;
        }

        public void TimeToStartFadeOut()
        {
            if(currentFadeTime > 0)
            {
                if(currentTimeBeforFade > 0)
                {
                    currentTimeBeforFade -= Time.deltaTime;
                }
                else
                {
                    FadeOutOverTime();
                }
            }
        }

        public void FadeOutOverTime()
        {
            if(currentFadeTime > 0)
            {
                currentFadeTime -= Time.deltaTime;
                if(currentFadeTime < 0)
                {
                    currentFadeTime = 0;
                }
                currentHealthBarcolor = healthBarcolor * (currentFadeTime / fadeTime);
                currentBackGroundColor = backGroundColor * (currentFadeTime / fadeTime);
            }
        }
        
        public void StartFadeOut()
        {
            SizeOfHealtBar();
            currentTimeBeforFade = timeBeforFade;
            currentFadeTime = fadeTime;
            currentHealthBarcolor = healthBarcolor;
            currentBackGroundColor = backGroundColor;
        }
        #endregion
    }
}