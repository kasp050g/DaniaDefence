using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
    public class Unit : GameObject
    {
        public event Action onUnitDeath;
        
        public void UnitDeath()
        {
            if (onUnitDeath != null)
            {
                onUnitDeath();
            }
        }


        
    }
}
