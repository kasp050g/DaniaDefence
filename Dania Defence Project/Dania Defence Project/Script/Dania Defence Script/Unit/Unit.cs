using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{

    public class Unit: GameObject
    {
        Stat knowlegde = new Stat(); // henter knowlegde værdien fra stat classen
        Stat movementspeed = new Stat(); // henter movementspeed værdien fra stat classen
        bool isalive = true; // en tjekker for om en unit er i live

        public override void Awake() // dette er kode der køre inden spillet går i gang
        {
            base.Awake();
            knowlegde.MaxValue = 100; // sætter hvad max værdien for knowlegde kan være (hvor meget hp units har)
            movementspeed.MaxValue = 100; // sætter hvor hurtigt units kan bevæge sig
        }

        public void Takedamage(float input) // method for når uniten tager skade
        {
            knowlegde.AddValue(input);
            if (knowlegde.CurrentValue >= knowlegde.MaxValue)
            {
                isalive = false;
            }
        }

        public override void Start() // den første gang spillet kommer til at gøre noget
        {
            base.Start();
        }

        public override void Update() // den der køre hele tiden, skade skal ske gennem denne
        {
            base.Update();
            transform.Position = new Vector2 (transform.Position.X, transform.Position.Y * Time.deltaTime);
        }

        public override void Draw(SpriteBatch spriteBatch) //tegne sprites der høre til units
        {
            base.Draw(spriteBatch);

        }


        


    }
}
