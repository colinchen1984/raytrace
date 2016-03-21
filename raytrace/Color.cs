using System;

namespace raytrace
{
	public class Color
	{
		public static Color Black
		{
			get { return new Color(0.0f, 0.0f, 0.0f, 1.0f); }
		}

		public static Color Red
		{
			get { return new Color(1.0f, 0.0f, 0.0f, 1.0f); }
		}

		public static Color Green
		{
			get { return new Color(0.0f, 1.0f, 0.0f, 1.0f); }
		}

		public static Color Blue
		{
			get { return new Color(0.0f, 0.0f, 1.0f, 1.0f); }
		}

		public static Color White
		{
			get { return new Color(1.0f, 1.0f, 1.0f, 1.0f); }
		}


		private static readonly int aShift = 0;
		private static readonly int rShift = 1;
		private static readonly int gShift = 2;
		private static readonly int bShift = 3;
		private float[] color = new[] {0.0f, 0.0f, 0.0f, 0.0f};

		public Color(float r, float g, float b, float a)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		public float r
		{
			get { return color[rShift]; }
			set { color[rShift] = value; }
		}

		public float g
		{
			get { return color[gShift]; }
			set { color[gShift] = value; }
		}

		public float b
		{
			get { return color[bShift]; }
			set { color[bShift] = value; }
		}

		public float a
		{
			get { return color[aShift]; }
			set { color[aShift] = value; }
		}

		public System.Drawing.Color ToSystemColor()
		{
			return System.Drawing.Color.FromArgb(Math.Min(0xff, (int)(a * 0xff)),
				System.Drawing.Color.FromArgb(Math.Min(0xff, (int)(r * 0xff)), 
				Math.Min(0xff, (int)(g * 0xff)),
				Math.Min(0xff, (int)(b * 0xff))));
		}

		public static Color operator *(Color c1, Color c2)
		{
			Color ret = Color.Black;
			for (int i = 0; i < ret.color.Length; ++i)
			{
				ret.color[i] = c1.color[i]*c2.color[i];
			}
			return ret;
		}

		public static Color operator *(float c1, Color c2)
		{
			return c2*c1;
		}

		public static Color operator *(Color c1, float c2)
		{
			Color ret = Color.Black;
			for (int i = 0; i < ret.color.Length; ++i)
			{
				ret.color[i] = c1.color[i] * c2;
			}
			return ret;
		}

		public static Color operator +(Color c1, Color c2)
		{
			Color ret = Color.Black;
			for (int i = 0; i < ret.color.Length; ++i)
			{
				ret.color[i] =c1.color[i] + c2.color[i];
			}
			return ret;
		}
	}
}