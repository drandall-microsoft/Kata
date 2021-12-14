using System;
using System.Collections.Generic;

namespace CSharpKatas.DependsOn
{
    public class Dependency
    {
        public enum Name
        {
            Zero, One, Two, Three, Four, Five
        }

        public enum LoadingState { NotLoaded, Loading, DoneLoading };

        public ISet<Name> Dependencies { get; } = new HashSet<Name>();

        public LoadingState CurrentState { get; private set; } = LoadingState.NotLoaded;

        private readonly Func<LoadingState> updateAction;
        private readonly Func<LoadingState> resetAction;
        public Name MyName { get; }

        public Dependency(Name dependencyName, Func<LoadingState> updateAction, Func<LoadingState> resetAction, params Name[] dependencies)
        {
            MyName = dependencyName;
            this.updateAction = updateAction;
            this.resetAction = resetAction;

            foreach (var dep in dependencies)
            {
                Dependencies.Add(dep);
            }

            DependencyLoader.RegisterDependency(this);
            }

            public void Load()
            {
                if (CurrentState != LoadingState.NotLoaded)
                {
                    throw new Exception($"{MyName} Called load, but was in the state {CurrentState}");
                }

                CurrentState = LoadingState.Loading;
            }

            public void Reset()
            {
                if (CurrentState != LoadingState.DoneLoading)
                {
                    CurrentState = LoadingState.NotLoaded;
                    return;
                }

                if (resetAction != null)
                {
                    CurrentState = resetAction();
                }
            }

            public void Update()
            {
                if (CurrentState == LoadingState.Loading)
                {
                    CurrentState = updateAction();
                }
            }
        }
    }
