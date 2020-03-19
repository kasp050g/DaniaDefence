using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
    public class WaveContainer
    {
        private List<Wave> waves = new List<Wave>();

        public List<Wave> Waves { get => waves; set => waves = value; }

        public void CreateAllWaves()
        {
            // Wave 1
            waves.Add(CreateNewWave(
                // Positions
                new List<Vector2> { new Vector2(1, 1) },
                // Normal Unit
                5,
                // Tank Unit
                2,
                // Fast Unit
                3,
				// Boss Unit
				0
                ));

        }

        public Wave CreateNewWave(List<Vector2> _position, int _normalUnit, int _tankUnity, int _fastUnit,int _bossUnit)
        {
            Wave _wave = new Wave();

            //_wave.Positions = _position;

            for (int i = 0; i < _normalUnit; i++)
            {
				_wave.Units.Add(new Unit_Casper());
            }

            for (int i = 0; i < _tankUnity; i++)
            {
				_wave.Units.Add(new Unit_Kasper());
			}

			for (int i = 0; i < _fastUnit; i++)
            {
				_wave.Units.Add(new Unit_Marius());
			}

			for (int i = 0; i < _bossUnit; i++)
			{
				_wave.Units.Add(new Unit_GordenFreeMan());
			}

			return _wave;
        }


    }
}
