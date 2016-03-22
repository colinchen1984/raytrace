
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

			var sphere = new Sphere(new Vector3(0.0f, 0.0f, 9), 3.0f,
				Material.DiffuseMaterial(Color.Red), Color.Green);

			sceneManager.AddSurceface(sphere);
			
			sceneManager.AddLight(new DirectionalLigh(new Vector3(1.0f, 1.0f, 0.0f), new Vector3(1.0f, 1.0f, 0.0f), Color.White));
			for (int y = 0; y < paiter.Hight; ++y)
			{
				float fy = ((float)y) / paiter.Hight;
				for (int x = 0; x < paiter.Width; ++x)
				{
					float fx = ((float)x) / paiter.Width;
					var ray = camera.GenerateRays(fx, fy);
					HitResult t = sceneManager.Intersection(camera, ray);
					paiter.Draw(x, y, t.Color);
				}
			}
			paiter.Dispose();
		}
	}
}
