using static CSharpKatas.DependsOn.Dependency.LoadingState;

namespace CSharpKatas.DependsOn
{
    public class RecursiveDependencyLoader : ILoaderStrategy
    {
        public void Load(Dependency.Name target)
        {
            LoadDependency(DependencyLoader.GetLoaderByName(target));
        }

        public void Update()
        {
        }

        private void LoadDependency(Dependency target)
        {
            if (target.CurrentState == DoneLoading)
            {
                return;
            }

            foreach (var name in target.Dependencies)
            {
                LoadDependency(DependencyLoader.GetLoaderByName(name));
            }

            target.Load();

            while (target.CurrentState != DoneLoading)
            {
                target.Update();
            }
        }
    }
}
