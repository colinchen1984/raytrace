using System;
using System.Collections.Generic;

namespace raytrace
{
	public interface ISurceface
	{
		HitResult Intersection(Ray ray);

		Material Mat { set; }

		Color CaculatePointColor(Camera camera, Vector3 postion, IList<ILight> lights);
	}

	public abstract class Surceface : ISurceface
	{
		protected Vector3 postion;

		protected Color color;

		protected Surceface(Vector3 position, Material mat, Color color)
		{
			this.Mat = mat;
			this.postion = position;
			this.color = color;
		}
		public abstract HitResult Intersection(Ray ray);

		public Material Mat { set; get; }

		public abstract Color CaculatePointColor(Camera camera, Vector3 postion, IList<ILight> lights);
	}

	public class Sphere : Surceface
	{
		private float radius = 0.0f;
		private float radiusSqrt = 0.0f;
		public Sphere(Vector3 position, float radius, Material mat, Color color)
			: base(position, mat, color)
		{
			this.radius = radius;
			this.radiusSqrt = radius*radius;
		}

		//http://www.cnblogs.com/miloyip/archive/2010/03/29/1698953.html
		public override HitResult Intersection(Ray ray)
		{
			var v = ray.Position - this.postion;
			float DdotV = ray.Direction.Dot(v);
			var a0 = ray.Direction.SqrtLength() * (v.SqrtLength() - radiusSqrt);
			var discr = DdotV * DdotV - a0;
			if (discr < 0.0f)
			{
				var result = new HitResult(new Vector3(), null, Single.MaxValue);
				result.Color = Color.Black;
				return result;
			}

			float distence = (float) (-DdotV - Math.Sqrt(discr));
			var hitPosition = ray.GetPoint(distence);
			var ret = new HitResult(hitPosition, this, distence);
			return ret;
		}

		public override Color CaculatePointColor(Camera camera, Vector3 postion, IList<ILight> lights)
		{
			return Mat.CaculateColor(camera, postion, (postion - this.postion).Normalize(), lights, color);
		}
	}
}