using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Dania_Defence_Project
{
	public class Unit_GordenFreeMan : Unit
	{
		public Unit_GordenFreeMan()
		{

		}
		public Unit_GordenFreeMan(Tile _myTarget, int _tileSize) : base(_myTarget, _tileSize)
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
			sprite = SpriteContainer.sprite["Pixel"];
			movementspeed.MaxValue = 100f;
			knowlegde.MaxValue = 100f;
		}
	}
}
