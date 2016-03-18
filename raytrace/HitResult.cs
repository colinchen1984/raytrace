namespace raytrace
{
	public class HitResult
	{
		public Vector3 HitPostion { get; private set; }

		public ISurceface HitSurceface { get; private set; }

		public float DistenceToRaySource { get; private set; }

		public Color Color { get; private set; }

		public HitResult(Vector3 hitPostion, ISurceface hitSurceface, float distenceToRaySource, Color color)
		{
			this.HitPostion = hitPostion;
			this.HitSurceface = hitSurceface;
			this.DistenceToRaySource = distenceToRaySource;
			this.Color = color;
		}
	}
}