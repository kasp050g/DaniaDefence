using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyXMLData
{
    public class MyLevel
    {
        public string LevelName;
        public int MaxEnemies;
        public Vector2 Position;
        public List<string> listName = new List<string>();
    }
}
