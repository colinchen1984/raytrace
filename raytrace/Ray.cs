namespace raytrace
{
	public struct Ray
	{
		public Vector3 Position;

		public Vector3 Direction;

		public Ray(Vector3 position, Vector3 direction)
		{
			Position = position;
			Direction = direction;
		}

		public Vector3 GetPoint(float distence)
		{
			return Position + distence*Direction;
		}
	}
}