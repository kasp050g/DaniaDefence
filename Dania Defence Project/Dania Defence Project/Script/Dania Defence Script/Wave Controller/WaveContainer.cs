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
                1,
                // Tank Unit
                2,
                // Fast Unit
                3
                ));

        }

        public Wave CreateNewWave(List<Vector2> _position, int _normalUnit, int _tankUnity, int _fastUnit)
        {
            Wave _wave = new Wave();

            _wave.Positions = _position;

            for (int i = 0; i < _normalUnit; i++)
            {
                //TODO: _wave.units.add(new normalUnit)
            }

            for (int i = 0; i < _tankUnity; i++)
            {
                //TODO: _wave.units.add(new tankUnit)
            }

            for (int i = 0; i < _fastUnit; i++)
            {
                //TODO: _wave.units.add(new fastUnit)
            }

            return _wave;
        }


    }
}
