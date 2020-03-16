using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyXMLData;

namespace Dania_Defence_Project
{
    public static class XmlContainer
    {
        public static MyLevel myLevel;

        public static void LoadContent(ContentManager content)
        {
            //// Normal Font
            //normalFont = content.Load<SpriteFont>("Font/NormalFont");

            //// Sole Sprite
            //AddSprite(content.Load<Texture2D>("Texture/Test/Pixel"), "Pixel");

            //// List of Sprite
            //AddSpriteList(new List<Texture2D>(){
            //    content.Load<Texture2D>("Texture/Test/Pixel"),
            //    content.Load<Texture2D>("Texture/Test/Pixel"),
            //    content.Load<Texture2D>("Texture/Test/Pixel")},
            //"NameTest");

            //myLevel = content.Load<MyLevel>("File");
            //myLevel = content.Load<MyLevel>("_jamen");
        }

        //private static void AddXml(Texture2D texture2D, string name)
        //{
        //    sprite.Add(name, texture2D);
        //}

        //private static void AddXmlList(List<Texture2D> texture2Ds, string name)
        //{
        //    spriteList.Add(name, texture2Ds);
        //}
    }
}
