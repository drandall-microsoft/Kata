using System.Collections.Generic;
using System.Linq;

namespace CSharpKatas.DependsOn
{
    public abstract class Dependency
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
            return !IsLoading && !DoneLoading && DependenciesDoneLoading;
        }

        public void Load()
        {
            IsLoading = true;
            LoadImpl();
        }

        public abstract void Update();
        protected void FinishedLoading()
        {
            IsLoading = false;
            DoneLoading = true;
        }
        protected abstract void LoadImpl();
    }
}
