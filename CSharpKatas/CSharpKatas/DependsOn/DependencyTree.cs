using System;
using System.Collections.Generic;
using System.Linq;

using static CSharpKatas.DependsOn.Dependency.LoadingState;

namespace CSharpKatas.DependsOn
{
    public class DependencyTree
    {
        private readonly Dictionary<Dependency.Name, HashSet<Dependency.Name>> missingDependencies = new Dictionary<Dependency.Name, HashSet<Dependency.Name>>();

        public DependencyTree(Dependency.Name root)
        {
            ConstructDependencyTree(root, new LinkedList<Dependency.Name>());
        }

        public IEnumerable<Dependency> ReadyToLoad()
        {
            var doneLoading = Ready.Where(d => d.CurrentState == DoneLoading).Select(d => d.MyName);
            foreach (var notDone in NotReady)
            {
                missingDependencies[notDone.MyName].RemoveWhere(d => doneLoading.Contains(d));
            }

            return Ready.Where(dep => dep.CurrentState != DoneLoading);
        }

        public IEnumerable<Dependency> ListInOrder()
        {
            return missingDependencies.OrderBy(kvp => kvp.Value.Count).Select(kvp => DependencyLoader.GetLoaderByName(kvp.Key));
        }

        private void ConstructDependencyTree(Dependency.Name root, LinkedList<Dependency.Name> parents)
        {
            if (missingDependencies.ContainsKey(root))
            {
                return;
            }

            if (parents.Contains(root))
            {
                string cycle = string.Join(" -> ", parents.Select(p => p.ToString()));
                cycle += $" -> {root}";
                throw new Exception($"Cycle detected: {cycle}");
            }

            parents.AddLast(root);
            var dependencyNames = new HashSet<Dependency.Name>();
            var loader = DependencyLoader.GetLoaderByName(root);
            foreach (var name in loader.Dependencies)
            {
                ConstructDependencyTree(name, parents);
                dependencyNames.Add(name);
                dependencyNames.AddRange(missingDependencies[name]);
            }

            missingDependencies[root] = dependencyNames;
            parents.RemoveLast();
        }

        private IEnumerable<Dependency.Name> FreeNames => missingDependencies.Where(kvp => !kvp.Value.Any()).Select(kvp => kvp.Key);
        private IEnumerable<Dependency.Name> NotFreeNames => missingDependencies.Where(kvp => kvp.Value.Any()).Select(kvp => kvp.Key);

        private IEnumerable<Dependency> Ready => FreeNames.Select(name => DependencyLoader.GetLoaderByName(name));
        private IEnumerable<Dependency> NotReady => NotFreeNames.Select(name => DependencyLoader.GetLoaderByName(name));
    }
}
