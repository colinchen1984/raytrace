using System;

namespace raytrace
{
	public interface ISurceface
	{
		bool Intersection(Ray ray, out HitResult intersection);

		Material Mat { set; }
	}

	public abstract class Surceface : ISurceface
	{
		protected Vector3 postion;

		protected Color color;

		public Surceface(Vector3 position, Material mat, Color color)
		{
			this.Mat = mat;
			this.postion = position;
			this.color = color;
		}

		public abstract bool Intersection(Ray ray, out HitResult intersection);

		public Material Mat { set; get; }

		protected abstract Color CaculatePointColor(Vector3 postion);
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
		public override bool Intersection(Ray ray, out HitResult intersection)
		{
			var v = ray.Position - this.postion;
			float DdotV = ray.Direction.Dot(v);
			var a0 = ray.Direction.SqrtLength() * (v.SqrtLength() - radiusSqrt);
			var discr = DdotV * DdotV - a0;
			if (discr < 0.0f)
			{
				intersection = null;
				return false;
			}

			float distence = (float) (-DdotV - Math.Sqrt(discr));
			var hitPosition = ray.GetPoint(distence);
			var surfacePixelColor = CaculatePointColor(hitPosition);
			intersection = new HitResult(hitPosition, this, distence, surfacePixelColor);
			return true;
		}

		static ILight light = new DirectionalLigh(new Vector3(0.0f, 0.0f, -1.0f), Color.Withe);

		protected override Color CaculatePointColor(Vector3 postion)
		{
			return Mat.CaculateColor(postion, (postion - this.postion).Normalize(), light, color);
		}
	}
}