using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public static class Time
	{
		public static float deltaTime;
		public static float time;

		public static void Update(GameTime gameTime)
		{
			Time.deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			Time.time = (float)gameTime.TotalGameTime.TotalSeconds;
		}
	}
}
