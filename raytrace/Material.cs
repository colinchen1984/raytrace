using System;
using System.Collections.Generic;

namespace raytrace
{
	public class Material
	{
		private Color tintColor = Color.Black;

		public Func<Camera, Vector3, Vector3, IList<ILight>, Color, Color, Color> FakeShader = null;
 
		public Color CaculateColor(Camera camera, Vector3 postion, Vector3 normal, IList<ILight> lights, Color color)
		{
			return FakeShader(camera, postion, normal, lights, tintColor, color);
		}

		private Color DiffuseShader(Camera camera, Vector3 postion, Vector3 normal, IList<ILight> lights, Color tintColor, Color color)
		{
			var ret = Color.Black;
			foreach (var light in lights)
			{
				float cosAngel = light.Direction.Dot(normal);
				cosAngel = Math.Max(cosAngel, 0.0f);
				ret += light.Color * cosAngel;

				var viewDir = (camera.Position - postion).Normalize();
				var reflect = Reflect(light.Direction, normal);
				float spec = (float) Math.Pow(Math.Max(viewDir.Dot(reflect), 0.0f), 32);
				ret += light.Color*spec;
			}
			ret *= color;
			//var t = 0.5f + normal * 0.5f;
			//ret = new Color(t.x, t.y, t.z, 1.0f);
			return ret;
		}

		private Vector3 Reflect(Vector3 input, Vector3 normal)
		{
			return (2*input.Dot(normal)*normal - input).Normalize();
		}
		public static Material DiffuseMaterial(Color tintColor)
		{
			var ret = new Material();
			ret.tintColor = tintColor;
			ret.FakeShader = ret.DiffuseShader;
			return ret;
		}
	}
}