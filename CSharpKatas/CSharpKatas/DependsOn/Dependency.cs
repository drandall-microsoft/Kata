using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpKatas.DependsOn
{
    public class Dependency
    {
        public enum Known
        {
            Zero, One, Two, Three, Four, Five
        }

        public ISet<Known> Dependencies { get; } = new HashSet<Known>();

        public bool IsLoading { get; private set; }
        public bool DoneLoading { get; private set; }

        private readonly Func<bool> updateAction;
        private readonly Func<bool> resetAction;

        public Dependency(Func<bool> updateAction, Func<bool> resetAction, params Known[] dependencies)
        {
            this.updateAction = updateAction;
            this.resetAction = resetAction;

            foreach (var dep in dependencies)
            {
                Dependencies.Add(dep);
            }
        }

        public void Load()
        {
            IsLoading = true;
        }

        public void Reset()
        {
            if (!DoneLoading)
            {
                IsLoading = false;
                return;
            }

            if (resetAction?.Invoke() == true)
            {
                IsLoading = false;
                DoneLoading = false;
            }
        }

        public void Update()
        {
            if (IsLoading)
            {
                DoneLoading = updateAction();
                IsLoading = !DoneLoading;
            }
        }
    }
}
