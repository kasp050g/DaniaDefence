using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public static class SpriteContainer
	{
		public static Dictionary<string, Texture2D> sprite = new Dictionary<string, Texture2D>();
		public static Dictionary<string, List<Texture2D>> spriteList = new Dictionary<string, List<Texture2D>>();
        public static SpriteFont normalFont;

		public static void LoadContent(ContentManager content)
		{
            // Normal Font
            normalFont = content.Load<SpriteFont>("Font/NormalFont");

            // Sole Sprite
            AddSprite(content.Load<Texture2D>("Texture/Test/Pixel"), "Pixel");

			//Towers
			AddSprite(content.Load<Texture2D>("Texture/Towers/Tower_Mikael"), "Mikael");
			AddSprite(content.Load<Texture2D>("Texture/Towers/Tower_Milo"), "Milo");
			AddSprite(content.Load<Texture2D>("Texture/Towers/Tower_Dennis"), "Dennis");
			AddSprite(content.Load<Texture2D>("Texture/Towers/Tower_Kenneth"), "Kenneth");
			AddSprite(content.Load<Texture2D>("Texture/Towers/Tower_Jonathan"), "Jonathan");

			//Students
			AddSprite(content.Load<Texture2D>("Texture/Students/Student_Casper"), "Casper");
			AddSprite(content.Load<Texture2D>("Texture/Students/Student_Kasper"), "Kasper");
			AddSprite(content.Load<Texture2D>("Texture/Students/Student_Marius"), "Marius");
			AddSprite(content.Load<Texture2D>("Texture/Students/Student_Gordon"), "Freeman");

			//Projectiles
			AddSprite(content.Load<Texture2D>("Texture/Projectiles/Projectile_Dennis"), "PDennis");
			AddSprite(content.Load<Texture2D>("Texture/Projectiles/Projectile_MonoGame"), "Monogame");
			AddSprite(content.Load<Texture2D>("Texture/Projectiles/Projectile_CSharp"), "C_Sharp");
			AddSprite(content.Load<Texture2D>("Texture/Projectiles/Projectile_VisualStudio"), "VisualStudio");
			AddSprite(content.Load<Texture2D>("Texture/Projectiles/Projectile_PowerPoint"), "PowerPoint");

			AddSprite(content.Load<Texture2D>("Texture/Towers/TowerProjectileTMP"), "TMP");

			// List of Sprite
			AddSpriteList(new List<Texture2D>(){
				content.Load<Texture2D>("Texture/Test/Pixel"),
				content.Load<Texture2D>("Texture/Test/Pixel"),
				content.Load<Texture2D>("Texture/Test/Pixel")},
			"NameTest");
		}

		private static void AddSprite(Texture2D texture2D, string name)
		{
			sprite.Add(name, texture2D);
		}

		private static void AddSpriteList(List<Texture2D> texture2Ds, string name)
		{
			spriteList.Add(name, texture2Ds);
		}
	}
}
