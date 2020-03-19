using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class Marius_Scene : Scene
	{
		#region Scene Nedarving
		public override void Initialize()
		{
			base.Initialize();
			TeacherTowers();
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
		#endregion

		#region Constructors
		public void TeacherTowers()
		{
			Instantiate(new Milo_Tower());
			Instantiate(new Mikael_Tower());
			Instantiate(new Kenneth_Tower());
			Instantiate(new Dennis_Tower());
			Instantiate(new Jonathan_Tower());
		}
		#endregion
	}
}
