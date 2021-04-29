using System.Collections.Generic;
using System.Linq;

using static CSharpKatas.DependsOn.Dependency.LoadingState;

namespace CSharpKatas.DependsOn
{
    internal class BatchedAsyncDependencyLoader : ILoaderStrategy
    {
        private readonly Dictionary<Dependency.Name, HashSet<Dependency.Name>> missingDependencies = new Dictionary<Dependency.Name, HashSet<Dependency.Name>>();
        private readonly List<Dependency> loadingDependencies = new List<Dependency>();

        public void Load(Dependency.Name target)
        {
            missingDependencies.Clear();
            ConstructDependencyTree(target);
            LoadBatch();
        }

        public void Update()
        {
            if (!loadingDependencies.Any())
            {
                return; //everything loaded
            }

            List<Dependency> toRemove = new List<Dependency>();

            foreach (var dep in loadingDependencies)
            {
                if (dep.CurrentState == DoneLoading)
                {
                    toRemove.Add(dep);
                }
                else
                {
                    dep.Update();
                }
            }

            loadingDependencies.RemoveAll(dep => toRemove.Contains(dep));
            if (!loadingDependencies.Any())
            {
                LoadBatch();
            }
        }

        private void LoadBatch()
        {
            var toLoad = missingDependencies
                .Where(kvp => !kvp.Value.Any())
                .Select(kvp => DependencyLoader.GetLoaderByName(kvp.Key))
                .Where(dep => dep.CurrentState != DoneLoading);

            loadingDependencies.AddRange(toLoad);
            foreach (var dep in toLoad)
            {
                dep.Load();
            }
        }

        private void ConstructDependencyTree(Dependency.Name root)
        {
            if (missingDependencies.ContainsKey(root))
            {
                return;
            }

            missingDependencies[root] = new HashSet<Dependency.Name>();
            var loader = DependencyLoader.GetLoaderByName(root);
            foreach (var name in loader.Dependencies)
            {
                ConstructDependencyTree(name);
                missingDependencies[root].AddRange(missingDependencies[name]);
            }
        }
    }
}
