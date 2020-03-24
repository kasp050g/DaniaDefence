using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class Unit_Casper : Unit
	{
		public Unit_Casper()
		{

		}
		public Unit_Casper(Tile _myTarget, int _tileSize) : base(_myTarget, _tileSize)
		{
			this.myTarget = _myTarget;
			this.tileSize = _tileSize;
		}

		public override void Awake()
		{
			MadeUnit();
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
		public void MadeUnit()
		{
			sprite = SpriteContainer.sprite["Student_Casper"];
			movementspeed.MaxValue = 50f;
			knowlegde.MaxValue = 500f;
		}
	}
}
