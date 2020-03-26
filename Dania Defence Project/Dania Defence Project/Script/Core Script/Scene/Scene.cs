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
        protected bool pauseGame;



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
        public bool PauseGame { get => pauseGame; set => pauseGame = value; }

        public bool IsMouseOverUI { get => isMouseOverUI; set => isMouseOverUI = value; }
        public bool threadCanLoadList = false;

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
            if (!pauseGame)
            {
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
            }

            if (Input.GetKeyDown(Keys.P))
            {
                pauseGame = !pauseGame;
            }

            foreach (GameObject gameObject in guis)
            {
                if (gameObject.IsActive)
                {
                    gameObject.Update();
                }
            }

            threadCanLoadList = false;
            CallDestroyGameObject();
            CallInstantiate();
            threadCanLoadList = true;
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
                    if (gameObject is Tower)
                    {
                        //DrawCollisionBox(gameObject as Tower, spriteBatch, SpriteContainer.sprite["Pixel"]);
                    }
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

        private void DrawCollisionBox(Tower go, SpriteBatch spriteBatch, Texture2D collisionTexture)
        {
            Rectangle collisionBox = go.TowerRangeCollision;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rigthLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

            spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rigthLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

        public void CheckForGUI()
        {
            MouseState currentMouse = Mouse.GetState();
            Rectangle mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            foreach (GameObject x in Guis)
            {
                if ((x is GUI) && mouseRectangle.Intersects((x as GUI).GUImouseBlockCollision) && x.IsActive == true)
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
            if(this.componentsToBeCreated.Count > 0)
            {
                // Call Awake
                List<Component> awakeCall = new List<Component>();
                awakeCall.AddRange(this.componentsToBeCreated);
                this.componentsToBeCreated.Clear();

                List<Component> _components = new List<Component>();
                List<GameObject> _gameObjects = new List<GameObject>();
                List<GameObject> _guis = new List<GameObject>();


                foreach (Component component in awakeCall)
                {
                    component.MyScene = this;
                    component.Awake();

                    if (component is GameObject && component is GUI == false)
                    {
                        _gameObjects.Add(component as GameObject);
                    }
                    else if (component is GUI)
                    {
                        if ((component as GUI).IsWorldGui == true)
                        {
                            _gameObjects.Add(component as GameObject);
                        }
                        else
                        {
                            _guis.Add(component as GUI);
                        }
                    }
                    else
                    {
                        _components.Add(component);
                    }
                }

                components.AddRange(_components);
                gameObjects.AddRange(_gameObjects);
                guis.AddRange(_guis);
            }
        }
        /// <summary>
        /// TODO
        /// Remove all GameObjects To Be Remove from current GameObject List.
        /// </summary>
        private void CallDestroyGameObject()
        {
            if(this.componentsToBeDestroyed.Count > 0)
            {
                List<Component> _components = new List<Component>(components);
                List<GameObject> _gameObjects = new List<GameObject>(gameObjects);
                List<GameObject> _guis = new List<GameObject>(guis);

                // Remove GameObjects
                foreach (Component component in this.componentsToBeDestroyed)
                {
                    if (component is GameObject && component is GUI == false)
                    {
                        _gameObjects.Remove(component as GameObject);
                    }
                    else if (component is GUI)
                    {
                        if ((component as GUI).IsWorldGui == true)
                        {
                            _gameObjects.Remove(component as GameObject);
                        }
                        else
                        {
                            _guis.Remove(component as GUI);
                        }
                    }
                    else
                    {
                        _components.Remove(component);
                    }
                }

                for (int i = 0; i < this.componentsToBeDestroyed.Count; i++)
                {
                    this.componentsToBeDestroyed[i] = null;
                }

                components = _components;
                gameObjects = _gameObjects;
                guis = _guis;

                this.componentsToBeDestroyed.Clear();
            }
        }
        #endregion
    }
}
