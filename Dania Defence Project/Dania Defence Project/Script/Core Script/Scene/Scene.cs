using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class Scene
	{
		protected string name;
		protected bool updateEnabled;
		protected bool drawEnabled;
		protected bool isInitialized;
		protected bool isMouseOverUI = false;

		protected List<Component> components = new List<Component>();
		protected List<GameObject> gameObjects = new List<GameObject>();
		protected List<GameObject> guis = new List<GameObject>();
		protected List<Component> componentsToBeCreated = new List<Component>();
		protected List<Component> componentsToBeDestroyed = new List<Component>();

		public string Name { get { return name; } set { name = value; } }
		public bool UpdateEnabled { get { return updateEnabled; } set { updateEnabled = value; } }
		public bool DrawEnabled { get { return drawEnabled; } set { drawEnabled = value; } }
		public List<Component> Components { get { return components; } private set { components = value; } }
		public List<GameObject> GameObjects { get { return gameObjects; } private set { gameObjects = value; } }
		public List<GameObject> Guis { get { return guis; } private set { guis = value; } }

		public bool IsMouseOverUI { get => isMouseOverUI; set => isMouseOverUI = value; }

		public virtual void Initialize()
		{
			isInitialized = true;
		}

		public virtual void OnSwitchToThisScene()
		{
			if (isInitialized == false)
			{
				this.Initialize();
			}
		}

		public virtual void OnSwitchAwayFromThisScene()
		{

		}

		public virtual void Update()
		{
			CheckForGUI();

			foreach (Component component in components)
			{
				if (component.IsActive)
				{
					component.Update();
				}
			}

			foreach (GameObject gameObject in gameObjects)
			{
				if (gameObject.IsActive)
				{
					gameObject.Update();
				}
			}

			foreach (GameObject gameObject in guis)
			{
				if (gameObject.IsActive)
				{
					gameObject.Update();
				}
			}

			CallDestroyGameObject();
			CallInstantiate();
			SceneController.Camera.Update();
			IsMouseOverUI = false;
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, transformMatrix: SceneController.Camera.Transform);
			foreach (GameObject gameObject in gameObjects)
			{
				if (gameObject.IsActive)
				{
					gameObject.Draw(spriteBatch);
				}
			}
			spriteBatch.End();

			spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
			foreach (GameObject gameObject in guis)
			{
				if (gameObject.IsActive)
				{
					gameObject.Draw(spriteBatch);
				}
			}
			spriteBatch.End();
		}

		public void CheckForGUI()
		{
			MouseState currentMouse = Mouse.GetState();
			Rectangle mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

			foreach (GameObject x in Guis)
			{
				if ((x is GUI) && mouseRectangle.Intersects((x as GUI).GUImouseBlockCollision))
				{
					IsMouseOverUI = true;
				}
			}
		}

		#region Instantiate And Destroy
		/// <summary>
		/// Will instantiate a new gameObject in to the game.
		/// </summary>
		/// <param name="gameObject">The GameObject to be add to game.</param>
		public void Instantiate(Component component)
		{
			this.componentsToBeCreated.Add(component);
		}
		/// <summary>
		/// Will destroy this gameobject
		/// </summary>
		/// <param name="gameObject">destroy this gameobject</param>
		public void Destroy(Component component)
		{
			this.componentsToBeDestroyed.Add(component);
		}
		/// <summary>
		/// Call this to Destroy all GameObjects
		/// </summary>
		public void DestroyAllGameObjects()
		{
			this.components.Clear();
		}
		/// <summary>
		/// Add all GameObjects To Be Created to current GameObject List.
		/// </summary>
		private void CallInstantiate()
		{
			// Call Awake
			List<Component> awakeCall = new List<Component>();
			awakeCall.AddRange(this.componentsToBeCreated);
			this.componentsToBeCreated.Clear();

			foreach (Component component in awakeCall)
			{
				component.MyScene = this;
				component.Awake();

				if (component is GameObject && component is GUI == false)
				{
					gameObjects.Add(component as GameObject);
				}
				else if (component is GUI)
				{
                    if((component as GUI).IsWorldGui == true)
                    {
                        gameObjects.Add(component as GameObject);
                    }
                    else
                    {
                        guis.Add(component as GUI);
                    }
				}
				else
				{
					components.Add(component);
				}
			}			
		}
		/// <summary>
		/// TODO
		/// Remove all GameObjects To Be Remove from current GameObject List.
		/// </summary>
		private void CallDestroyGameObject()
		{
			// Remove GameObjects
			foreach (Component component in this.componentsToBeDestroyed)
			{				
				if (component is GameObject && component is GUI == false)
				{
					gameObjects.Remove(component as GameObject);
				}
				else if (component is GUI)
				{
					if ((component as GUI).IsWorldGui == true)
					{
						gameObjects.Remove(component as GameObject);
					}
					else
					{
						guis.Remove(component as GUI);
					}
				}
				else
				{
					components.Remove(component);
				}
			}
			this.componentsToBeDestroyed.Clear();
		}
		#endregion
	}
}
