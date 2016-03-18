
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace raytrace
{
	public class DrawPaint : IDisposable
	{
		private Bitmap dest = null;

		private string path = null;
		public DrawPaint(int width, int hight, string path)
		{
			dest = new Bitmap(width, hight);
			this.path = path;
		}

		public void Draw(int x, int y, byte R, byte G, byte B, byte A)
		{
			dest.SetPixel(x, y, Color.FromArgb(A, R, G, B));
		}

		public void Draw(int x, int y, Color color)
		{
			dest.SetPixel(x, y, color);
		}

		public void Dispose()
		{
			dest.Save(path, ImageFormat.Png);
			dest.Dispose();
		}
	}
}