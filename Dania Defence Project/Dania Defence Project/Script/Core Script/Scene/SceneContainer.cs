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
			MakeScenes();
		}

		public void MakeScenes()
		{

		}
	}
}
