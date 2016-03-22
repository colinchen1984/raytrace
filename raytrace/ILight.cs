namespace raytrace
{
	public interface ILight
	{
		Vector3 Direction { get; } 
		Color Color { get; }
		Vector3 Position { get; }
	}

	public class DirectionalLigh : ILight
	{
		public DirectionalLigh(Vector3 position, Vector3 dir, Color color)
		{
			this.Position = position;
			this.Direction = dir.Normalize();
			this.Color = color;
		}

		public Vector3 Direction { get; private set; }
		public Color Color { get; private set; }
		public Vector3 Position { get; private set; }
	}
}