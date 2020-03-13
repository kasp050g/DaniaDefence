using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class GUI : GameObject
	{
        private bool showGUI = true;
        private GUI parentGUI;
		private bool isWorldGui = false;

		/// <summary>
		/// This is use to show or hide this GUI.
		/// </summary>
		public bool ShowGUI { get => showGUI; set => showGUI = value; }
		/// <summary>
		/// 
		/// </summary>
		public bool IsWorldGui { get => isWorldGui; set => isWorldGui = value; }
		/// <summary>
		/// Set a parrentGUI that this GUI will follow.
		/// </summary>
		public GUI ParentGUI { get => parentGUI; set => parentGUI = value; }
		/// <summary>
		/// Use to check if you hold your mouse over GUI.
		/// </summary>
		public virtual Rectangle GUImouseBlockCollision
        {
            get
            {
                // returns a new rectangle based on the position, scale, sprite width and height.
                return new Rectangle(
                    (int)this.Transform.Position.X - (int)(this.Transform.Origin.X * this.Transform.Scale.X),
                    (int)this.Transform.Position.Y - (int)(this.Transform.Origin.Y * this.Transform.Scale.Y),
                    (int)(this.Sprite.Width * this.Transform.Scale.X),
                    (int)(this.Sprite.Height * this.Transform.Scale.Y)
                    );
            }
        }

		public override void Awake()
		{
			base.Awake();
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Update()
		{
            UpdateParentGUI();
			base.Update();
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

        private void UpdateParentGUI()
        {
            if (ParentGUI != null)
            {
                if (ShowGUI != ParentGUI.ShowGUI)
                {
                    ShowGUI = ParentGUI.ShowGUI;
                }
            }
        }
    }
}
