using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public abstract class Component
	{
		protected Scene myScene;
		protected bool isActive = true;
		private bool isFirstUpdate = true;


		public bool IsActive { get => isActive; set => isActive = value; }
		public Scene MyScene { get => myScene; set => myScene = value; }

		/// <summary>
		/// This will be call befor Componet is made.
		/// </summary>
		public virtual void Awake()
		{
			
		}
		/// <summary>
		/// This will be call on first update.
		/// </summary>
		public virtual void Start()
		{			
			
		}

		public virtual void Update()
		{
			if (isFirstUpdate)
			{
				isFirstUpdate = false;
				Start();
			}
		}


		#region Instantiate And Destroy
		/// <summary>
		/// Will instantiate a new component/gameObject in to the game.
		/// </summary>
		/// <param name="gameObject">The GameObject to be add to game.</param>
		public void Instantiate(Component component)
		{
			myScene.Instantiate(component);
		}
		/// <summary>
		/// Will destroy this gameobject
		/// </summary>
		/// <param name="gameObject">destroy this gameobject</param>
		public void Destroy(Component component)
		{
			myScene.Destroy(component);
		}
		#endregion
	}
}
