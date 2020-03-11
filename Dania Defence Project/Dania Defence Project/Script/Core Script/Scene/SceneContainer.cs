using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project
{
	public class SceneContainer
	{
		private List<Scene> scenes = new List<Scene>();
		public List<Scene> Scenes { get => scenes; set => scenes = value; }



		public void Initialize()
		{
			Test();
		}

		public void Test()
		{
			PickScene pickScene = new PickScene
			{
				Name = "Pick Scene"
			};
			Scenes.Add(pickScene);

			MainScene mainScene = new MainScene
			{
				Name = "Main Scene"
			};
			Scenes.Add(mainScene);

			Kasper_Scene kasper_Scene = new Kasper_Scene
			{
				Name = "Kasper Scene"
			};
			Scenes.Add(kasper_Scene);

			Casper_Scene casper_Scene = new Casper_Scene
			{
				Name = "Casper Scene"
			};
			Scenes.Add(casper_Scene);

			Nicolai_Scene nicolai_Scene = new Nicolai_Scene
			{
				Name = "Nicolai Scene"
			};
			Scenes.Add(nicolai_Scene);

			Marius_Scene marius_Scene = new Marius_Scene
			{
				Name = "Marius Scene"
			};
			Scenes.Add(marius_Scene);
		}
	}
}
