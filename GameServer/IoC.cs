using System;
using System.Collections.Generic;

namespace GameServer
{
    public static class IoC
    {
        private static readonly Dictionary<string, Func<object[], object>> _dependencies = new();

        public static void Register(string key, Func<object[], object> resolver)
        {
            _dependencies[key] = resolver;
        }

        public static T Resolve<T>(string key, params object[] args)
        {
            if (!_dependencies.TryGetValue(key, out var resolver))
                throw new KeyNotFoundException($"Dependency '{key}' not registered.");
            return (T)resolver(args);
        }
    }
}
