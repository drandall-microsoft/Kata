using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpKatas.DependsOn
{
    public class Dependency
    {
        private HashSet<Dependency> dependencies = new HashSet<Dependency>();

        private bool hasLoaded;

        public Dependency(params Dependency[] dependencies)
        {
            foreach (var dep in dependencies)
            {
                this.dependencies.Add(dep);
            }
        }

        public bool CanLoad()
        {
            return !dependencies.Any(d => d.hasLoaded == false);
        }

        public void Load()
        {
            hasLoaded = true;
        }
    }
}
