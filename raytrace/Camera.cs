
namespace raytrace
{
	public abstract class Camera
	{
		public Vector3 Position { get; private set; }

		public Vector3 Up { get; private set; }

		public Vector3 Direction { get; private set; }

		public Vector3 Right { get; private set; }


		protected Camera(Vector3 position, Vector3 up, Vector3 lookAt)
		{
			Position = position;
			Up = up.Normalize();
			Direction = (lookAt - position).Normalize();
			Right = Up.Cross(Direction).Normalize();

		}

		public abstract Ray GenerateRays(float x, float y);

	}
}