using System;
using System.CodeDom;

namespace raytrace
{
	public class Material
	{
		private Color tintColor = Color.Black;

		public Func<Vector3, Vector3, ILight, Color, Color, Color> FakeShader = null;
 
		public Color CaculateColor(Vector3 postion, Vector3 normal, ILight light, Color color)
		{
			return FakeShader(postion, normal, light, tintColor, color);
		}

		private Color DiffuseShader(Vector3 postion, Vector3 normal, ILight light, Color tintColor, Color color)
		{
			float cosAngel = light.Direction.Dot(normal);
			Color ret = color + light.Color * cosAngel;
			return ret;
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