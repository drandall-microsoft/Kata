using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.DependsOn
{
    public static class DependencyLoader
    {
        private static readonly Dictionary<Dependency.Name, Dependency> Loaders = new Dictionary<Dependency.Name, Dependency>();

        internal static Dependency GetLoaderByName(Dependency.Name name)
        {
            return Loaders[name];
        }

        internal static void RegisterDependency(Dependency dependency)
        {
            Loaders[dependency.MyName] = dependency;
        }

        public static void ClearForTests()
        {
            Loaders.Clear();
        }
    }
}
