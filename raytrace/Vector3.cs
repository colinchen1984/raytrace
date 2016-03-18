using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace raytrace
{
	public struct Vector3
	{
		private float[] data;

		public Vector3(float x, float y, float z)
		{
			data = new[] {0.0f, 0.0f, 0.0f};
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public float x
		{
			get { return data[0]; }
			set { data[0] = value; }
		}

		public float y
		{
			get { return data[1]; }
			set { data[1] = value; }
		}

		public float z
		{
			get { return data[2]; }
			set { data[2] = value; }
		}

		public static Vector3 operator +(Vector3 c1, Vector3 c2)
		{
			var ret = new Vector3(0.0f, 0.0f, 0.0f);
			for (int i = 0; i < ret.data.Length; ++i)
			{
				ret.data[i] = c2.data[i] + c1.data[i];
			}
			return ret;
		}

		public static Vector3 operator -(Vector3 c1, Vector3 c2)
		{
			var ret = new Vector3(0.0f, 0.0f, 0.0f);
			for (int i = 0; i < ret.data.Length; ++i)
			{
				ret.data[i] = c1.data[i] - c2.data[i];
			}
			return ret;
		}

		public static Vector3 operator *(Vector3 c1, float c2)
		{
			var ret = new Vector3(0.0f, 0.0f, 0.0f);
			for (int i = 0; i < c1.data.Length; ++i)
			{
				ret.data[i] = c2*c1.data[i];
			}
			return ret;
		}

		public static Vector3 operator *(float c2, Vector3 c1)
		{
			return c1*c2;
		}

		public Vector3 Cross(Vector3 other)
		{
			float x = data[1]*other.data[2] - data[2]*other.data[1];
			float y = data[0]*other.data[2] - data[2]*other.data[0];
			float z = data[0]*other.data[1] - data[1]*other.data[0];
			return new Vector3(x, y, z);
		}

		public float Dot(Vector3 other)
		{
			float ret = 0.0f;
			for (int i = 0; i < data.Length; ++i)
			{
				ret += data[i] * other.data[i];
			}
			return ret;
		}

		public Vector3 Normalize()
		{
			float f = (float) Math.Pow(this.Dot(this), -0.5f);
			return this * f;
		}

		public float SqrtLength()
		{
			return this.Dot(this);
		}

		public override string ToString()
		{
			return string.Format("x:{0}, y:{1}, z:{2}", x, y, z);
		}
	}
}