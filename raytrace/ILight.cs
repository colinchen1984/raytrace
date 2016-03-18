namespace raytrace
{
	public interface ILight
	{
		Vector3 Direction { get; } 
		Color Color { get; }
	}

	public class DirectionalLigh : ILight
	{
		public DirectionalLigh(Vector3 dir, Color color)
		{
			this.Direction = dir;
			this.Color = color;
		}

		public Vector3 Direction { get; private set; }
		public Color Color { get; private set; }
	}
}