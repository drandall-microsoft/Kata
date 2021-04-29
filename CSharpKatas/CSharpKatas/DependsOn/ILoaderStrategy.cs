namespace CSharpKatas.DependsOn
{
    internal interface ILoaderStrategy
    {
        void Load(Dependency.Name target);
        void Update();
    }
}
