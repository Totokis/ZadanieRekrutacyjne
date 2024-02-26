namespace Extensions
{
    using System;
    using System.Collections.Generic;

    public static class CollectionExtension
    {
        private static readonly Random rng = new();

        public static T RandomElementOrDefault<T>(this IList<T> list)
        {
            if (list != null && list.Count != 0)
            {
                return list[rng.Next(list.Count)];
            }

            return default;

        }
    }
}