namespace OricExplorer
{
    using System.Drawing;
    using System.Linq;

    public static class Extensions
    {
        public static bool In<T>(this T @object, params T[] values)
        {
            return values.ToList().Contains(@object);
        }

        internal static bool Same(this Image image1, Image image2)
        {
            if (!image1.Size.Equals(image2.Size)) return false;

            Bitmap bmp1 = new Bitmap(image1);
            Bitmap bmp2 = new Bitmap(image2);

            for (int y = 0; y < bmp1.Height; y++)
            {
                for (int x = 0; x < bmp1.Width; x++)
                {
                    if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}