using System;

namespace raytrace
{
	public interface ISurceface
	{
		bool Intersection(Ray ray, out Vector3 intersection);
	}

	public abstract class Surceface : ISurceface
	{
		protected Vector3 postion;

		public Surceface(Vector3 position)
		{
			this.postion = position;
		}

		public abstract bool Intersection(Ray ray, out Vector3 intersection);
	}

	public class Sphere : Surceface
	{
		private float radius = 0.0f;
		private float radiusSqrt = 0.0f;
		public Sphere(Vector3 position, float radius)
			: base(position)
		{
			this.radius = radius;
			this.radiusSqrt = radius*radius;
		}

		//http://www.cnblogs.com/miloyip/archive/2010/03/29/1698953.html
		public override bool Intersection(Ray ray, out Vector3 intersection)
		{
			intersection = new Vector3();
			var v = ray.Position - this.postion;
			float DdotV = ray.Direction.Dot(v);
			var a0 = ray.Direction.Dot(ray.Direction) * (v.Dot(v) - radiusSqrt);
			var discr = DdotV * DdotV - a0;
			if (discr < 0.0f)
			{
				return false;
			}

			float distence = (float) (-DdotV - Math.Sqrt(discr));
			intersection = ray.GetPoint(distence);
			return true;
		}
	}
}