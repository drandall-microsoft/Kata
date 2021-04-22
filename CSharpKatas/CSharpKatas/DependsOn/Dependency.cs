using System.Collections.Generic;
using System.Linq;

namespace CSharpKatas.DependsOn
{
    public class Dependency
    {
        private HashSet<Dependency> dependencies = new HashSet<Dependency>();

        public bool IsLoading { get; private set; }
        public bool DoneLoading { get; private set; }

        private bool DependenciesDoneLoading => !dependencies.Any(d => d.DoneLoading == false);

        public Dependency(params Dependency[] dependencies)
        {
            foreach (var dep in dependencies)
            {
                this.dependencies.Add(dep);
            }
        }

        public bool CanLoad()
        {
            return !DoneLoading && DependenciesDoneLoading;
        }

        public void Load()
        {
            DoneLoading = true;
        }

    }
}
