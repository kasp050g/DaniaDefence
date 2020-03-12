using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class Kasper_Scene : Scene
	{
		public override void Initialize()
		{
			base.Initialize();
			GridBox();
		}

		public override void OnSwitchToThisScene()
		{
			base.OnSwitchToThisScene();
		}

		public override void OnSwitchAwayFromThisScene()
		{
			base.OnSwitchAwayFromThisScene();
		}

		public override void Update()
		{
			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public void GridBox()
		{

			for (int x = 0; x < 100; x++)
			{
				for (int y = 0; y < 100; y++)
				{
					ShowGrid showGrid = new ShowGrid();
					showGrid.Transform.Position = new Microsoft.Xna.Framework.Vector2(100 * x, 100 * y);
					showGrid.Transform.Position -= new Microsoft.Xna.Framework.Vector2(1000, 1000);
					Instantiate(showGrid);
				}
			}

		}
	}
}
