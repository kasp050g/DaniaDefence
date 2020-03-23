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

            // The Pixel
            AddSprite(content.Load<Texture2D>("Texture/Test/Pixel"), "Pixel");
            // Tower 
            AddSprite(content.Load<Texture2D>("Texture/Towers/Tower_Dennis"), "Tower_Dennis");
            AddSprite(content.Load<Texture2D>("Texture/Towers/Tower_Jonathan"), "Tower_Jonathan");
            AddSprite(content.Load<Texture2D>("Texture/Towers/Tower_Kenneth"), "Tower_Kenneth");
            AddSprite(content.Load<Texture2D>("Texture/Towers/Tower_Mikael"), "Tower_Mikael");
            AddSprite(content.Load<Texture2D>("Texture/Towers/Tower_Milo"), "Tower_Milo");
            // Tile
            AddSprite(content.Load<Texture2D>("Texture/Tile/Grass_Tile"), "Grass_Tile");
            AddSprite(content.Load<Texture2D>("Texture/Tile/Stone_Tile"), "Stone_Tile");
            // Icon
            AddSprite(content.Load<Texture2D>("Texture/Icon/Coin1"), "coin");
            AddSprite(content.Load<Texture2D>("Texture/Icon/heart"), "heart");
            // Students
            AddSprite(content.Load<Texture2D>("Texture/Students/Student_Kasper"), "Student_Kasper");
            AddSprite(content.Load<Texture2D>("Texture/Students/Student_Gordon"), "Student_Gordon");
            AddSprite(content.Load<Texture2D>("Texture/Students/Student_Casper"), "Student_Casper");
            AddSprite(content.Load<Texture2D>("Texture/Students/Student_Marius"), "Student_Marius");
            // Face
            AddSprite(content.Load<Texture2D>("Texture/Face/Dennis_Sprite"), "Face_Dennis");
            AddSprite(content.Load<Texture2D>("Texture/Face/Jonathan_Sprite"), "Face_Jonathan");
            AddSprite(content.Load<Texture2D>("Texture/Face/Kenneth_Sprite"), "Face_Kennet");
            AddSprite(content.Load<Texture2D>("Texture/Face/Mikael_Sprite"), "Face_Mikae");
            AddSprite(content.Load<Texture2D>("Texture/Face/Milo_Sprite"), "Face_Milo");
            // Projectiles
            AddSprite(content.Load<Texture2D>("Texture/Projectiles/Projectile_CSharp"), "Projectile_CSharp");
            AddSprite(content.Load<Texture2D>("Texture/Projectiles/Projectile_Dennis"), "Projectile_Dennis");
            AddSprite(content.Load<Texture2D>("Texture/Projectiles/Projectile_MonoGame"), "Projectile_MonoGame");
            AddSprite(content.Load<Texture2D>("Texture/Projectiles/Projectile_PowerPoint"), "Projectile_PowerPoint");
            AddSprite(content.Load<Texture2D>("Texture/Projectiles/Projectile_VisualStudio"), "Projectile_VisualStudio");

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
