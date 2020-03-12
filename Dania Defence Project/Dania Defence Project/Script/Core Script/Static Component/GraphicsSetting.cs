using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public static class GraphicsSetting
	{
		private static GraphicsDeviceManager graphics;

		public static GraphicsDeviceManager Graphics { get => graphics; set => graphics = value; }
		public static Vector2 ScreenSize { get; set; } = new Vector2(0, 0);
		public static Vector2 GameZome { get; set; } = new Vector2(1, 1);

		public static void SetGraphics(GraphicsDeviceManager graphic)
		{
			GraphicsSetting.Graphics = graphic;		

			Vector2 newSceneSize = new Vector2
				(
				graphics.PreferredBackBufferWidth,
				graphics.PreferredBackBufferHeight
				);

			GraphicsSetting.ScreenSize = newSceneSize;
		}
	}
}
