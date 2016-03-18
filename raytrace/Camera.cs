using System.Collections.Generic;

namespace raytrace
{
	public abstract class Camera
	{
		protected Vector3 position;

		protected Vector3 up;

		protected Vector3 direction;

		protected Vector3 right;


		protected Camera(Vector3 position, Vector3 up, Vector3 lookAt)
		{
			this.position = position;
			this.up = up.Normalize();
			this.direction = (lookAt - position).Normalize();
			this.right = this.up.Cross(this.direction).Normalize();
		}

		public abstract Ray GenerateRays(float x, float y);

	}
}