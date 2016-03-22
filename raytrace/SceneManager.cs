using System.Collections.Generic;

namespace raytrace
{
	public class SceneManager
	{
		private List<ISurceface> surcefacesList = new List<ISurceface>(32);
  
		private List<ILight> lightsList = new List<ILight>(8);

		public void AddSurceface(ISurceface surceface)
		{
			surcefacesList.Add(surceface);
		}

		public void AddLight(ILight light)
		{
			lightsList.Add(light);
		}

		public HitResult Intersection(Camera camera, Ray ray)
		{
			HitResult ret = null;
			foreach (var surceface in surcefacesList)
			{
				var hitRet = surceface.Intersection(ray);
				if (null == ret ||
				    hitRet.DistenceToRaySource < ret.DistenceToRaySource)
				{
					ret = hitRet;
				}
			}

			if (ret.Hit)
			{
				ret.Color = ret.HitSurceface.CaculatePointColor(camera, ret.HitPostion, lightsList);
			}
			return ret;
		}
	}
}