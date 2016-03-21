namespace raytrace
{
	public class HitResult
	{
		public Vector3 HitPostion { get; private set; }

		public ISurceface HitSurceface { get; private set; }

		public float DistenceToRaySource { get; private set; }

		public Color Color { get; set; }

		public HitResult(Vector3 hitPostion, ISurceface hitSurceface, float distenceToRaySource)
		{
			this.HitPostion = hitPostion;
			this.HitSurceface = hitSurceface;
			this.DistenceToRaySource = distenceToRaySource;
		}
	}
}