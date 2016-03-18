using System.Drawing;

namespace raytrace
{
	class Program
	{
		static void Main(string[] args)
		{
			var camera = new PerspectiveCamera(new Vector3(0.0f, 0.0f, -100.0f), 
				new Vector3(0.0f, 1.0f, 0.0f), 
				new Vector3(0.0f, 0.0f, 1f), 
				90.0f);
			
			var sphere = new Sphere(new Vector3(0.0f, 0.0f, 10), 3.0f);

			var paiter = new DrawPaint(1024, 1024, "test.png");
			
			for (int y = 0; y < 1024; ++y)
			{
				float fy = ((float)y) / 1024.0f;
				for (int x = 0; x < 1024; ++x)
				{
					float fx = ((float)x) / 1024.0f;
					var ray = camera.GenerateRays(fx, fy);
					Vector3 t;
					if (sphere.Intersection(ray, out t))
					{
						paiter.Draw(x, y, Color.Black);
					}
					else
					{
						paiter.Draw(x, y, Color.White);
					}
				}
			}
			paiter.Dispose();
		}
	}
}
