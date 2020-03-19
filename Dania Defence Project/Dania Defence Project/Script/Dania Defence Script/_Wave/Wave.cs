using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
    public class Wave
    {
        private List<Unit> units = new List<Unit>();
        //private List<Vector2> positions = new List<Vector2>();

        public List<Unit> Units { get => units; set => units = value; }
        //public List<Vector2> Positions { get => positions; set => positions = value; }
    }
}
