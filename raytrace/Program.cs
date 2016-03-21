
namespace raytrace
{
	class Program
	{
		static void Main(string[] args)
		{
			var paiter = new DrawPaint(1024, 1024, "test.png");

			var camera = new PerspectiveCamera(new Vector3(0.0f, 0.0f, -1.0f), 
				new Vector3(0.0f, 1.0f, 0.0f), 
				new Vector3(0.0f, 0.0f, 0f), 
				90.0f);

			var sceneManager = new SceneManager();

			var sphere = new Sphere(new Vector3(0f, 0.0f, 4), 3.0f,
				Material.DiffuseMaterial(Color.Red), Color.Green);

			sceneManager.AddSurceface(sphere);
			
			sceneManager.AddLight(new DirectionalLigh(new Vector3(1.0f, 1.0f, 0.0f), Color.White));
			for (int y = 0; y < 1024; ++y)
			{
				float fy = ((float)y) / 1024.0f;
				for (int x = 0; x < 1024; ++x)
				{
					float fx = ((float)x) / 1024.0f;
					var ray = camera.GenerateRays(fx, fy);
					HitResult t = sceneManager.Intersection(camera, ray);
					if (null != t)
					{
						paiter.Draw(x, y, t.Color);
					}
					else
					{
						paiter.Draw(x, y, System.Drawing.Color.Black);
					}
				}
			}
			paiter.Dispose();
		}
	}
}
