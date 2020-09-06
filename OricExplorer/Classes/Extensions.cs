namespace OricExplorer
{
    using System.Linq;

    public static class Extensions
    {
        public static bool In<T>(this T @object, params T[] values)
        {
            return values.ToList().Contains(@object);
        }
    }
}