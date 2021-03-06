﻿using System;

namespace raytrace
{
	public class PerspectiveCamera : Camera
	{
		private float fovTangle = 0.0f;

		public PerspectiveCamera(Vector3 position, Vector3 up, Vector3 lookAt, float fov) : base(position, up, lookAt)
		{
			fovTangle = (float) Math.Tan(Math.PI*(fov/360));
		}

		public override Ray GenerateRays(float x, float y)
		{
			var u = Right*fovTangle*(2.0f*x - 1);
			var v = Up*fovTangle*(2.0f*y - 1);
			var dir = this.Direction + u + v;
			return new Ray(Position, dir);
		}
	}
}