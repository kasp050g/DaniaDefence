using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
    public class WaveController : Component
    {

        Unit unit = new Unit();


        WaveContainer waveContainer = new WaveContainer();
        Wave nextWave;
        int currentWave = 0;

        bool jamrufuf = false;
        float currentCoundownTime;
        string countdownText = "COUNTDOWN";
        GuiText countdownUIText;

        public override void Awake()
        {
            base.Awake();
            countdownUIText = new GuiText(SpriteContainer.normalFont,
                countdownText,
                new Vector2(GraphicsSetting.ScreenSize.X / 2, GraphicsSetting.ScreenSize.Y / 2 - 200),
                new Vector2(1,1), 
                1,
                OriginPositionEnum.Mid );

            countdownUIText.IsActive = false;
            Instantiate(countdownUIText);

        }

        public override void Start()
        {
            base.Start();

            unit.onUnitGraduation += OnUnitGraduation;
        }

        public override void Update()
        {

            base.Update();

        }

        public void CountdownUntilWave()
        {
            if (currentCoundownTime > 0)
            {
                currentCoundownTime -= Time.deltaTime;

                if (currentCoundownTime <= 0)
                {
                    SpawnUnit();
                }
            }


        }
        public void SpawnUnit()
        {
            // Instantiate Unit
            nextWave = waveContainer.Waves[currentWave];

            foreach (Unit item in nextWave.Units)
            {
                item.Transform.Position = nextWave.Positions[0];
                Instantiate(item);
            }
        }

        public void StartNewWave()
        {
            currentCoundownTime = 10;


        }

        public void OnUnitGraduation()
        {
            unit.UnitGraduation();
        }

        

        




    }
}
