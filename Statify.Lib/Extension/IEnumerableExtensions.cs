namespace Statify.Lib.Extension
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach(var value in collection) {
                action(value);
            }

            return collection;
        }
    }
}
