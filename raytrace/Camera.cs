using System.Collections.Generic;

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
			this.Position = position;
			this.Up = up.Normalize();
			this.Direction = (lookAt - position).Normalize();
			this.Right = this.Up.Cross(this.Direction).Normalize();
		}

		public abstract Ray GenerateRays(float x, float y);

	}
}