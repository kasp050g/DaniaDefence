using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dania_Defence_Project
{
    public class Spawner : GameObject
    {
        public Spawner()
        {

        }
        public Spawner(Vector2 _position)
        {
            this.transform.Position = _position;
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
