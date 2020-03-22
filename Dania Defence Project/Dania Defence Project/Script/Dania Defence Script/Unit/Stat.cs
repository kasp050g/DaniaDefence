using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
    public class Stat
    {
        private float currentValue; // den nuværende værdi som uniten har
        private float maxValue; // den maximale værdi som unit kan få (i spillet "dør" uniten vis den når denne værdi)
        //private float armorValue;
        //bool isSlowed;

        public float CurrentValue { get => currentValue; set => currentValue = value; } //dette gør at den kan hente værdien.
        public float MaxValue { get => maxValue; set => maxValue = value; } // kan hente værdine og sætte værdien for maxvalue

        public void SubtrackValue(float input) // metod til at kunne trække en værdi fra vores knowledge bar (hp bar)
        {
            currentValue -= input; // kan trække en værdi fra
            if (currentValue < 0) // tjekker om den nuværende værdi er mindre ind 0
            {
                currentValue = 0; // vis værdien er mindre end 0 bliver den 0?????
            }

        }
        public void AddValue(float input) // metod til at kunne tilføje en værdi til vores knowledge bar (hp bar)
        {
            currentValue += input; // kan tilføje en værdi
            if (currentValue > maxValue) // tjekker om den nuværende værdi er over den total værdi den kan have.
            {
                currentValue = maxValue;
            }
        }
    }
}
