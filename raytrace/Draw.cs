
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

		public void Draw(int x, int y, Color color)
		{
			Draw(x, y, color.ToSystemColor());
		}

		public void Draw(int x, int y, System.Drawing.Color color)
		{
			dest.SetPixel(x, dest.Height - 1 - y, color);
		}

		public void Dispose()
		{
			dest.Save(path, ImageFormat.Bmp);
			dest.Dispose();
		}
	}
}