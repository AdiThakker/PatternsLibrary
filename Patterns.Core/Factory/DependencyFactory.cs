using System;
using System.Collections.Concurrent;

namespace Patterns.Core.Factory
{
    public static class DependencyFactory
    {
        private static ConcurrentDictionary<Type, Func<object>> factory = new ConcurrentDictionary<Type, Func<object>>();

        public static void Set<TType>(Type key, Func<TType> create) where TType : class, new()
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (create == null)
                throw new ArgumentNullException(nameof(create));

            factory.AddOrUpdate(key, create, (index, createFunc) => create);
        }

        public static TResult Get<TResult>()
        {
            if (!factory.TryGetValue(typeof(TResult), out Func<object> func))
                throw new InvalidOperationException($"No dependency registered for {typeof(TResult)}");

            return (TResult)func();
        }
    }
}
