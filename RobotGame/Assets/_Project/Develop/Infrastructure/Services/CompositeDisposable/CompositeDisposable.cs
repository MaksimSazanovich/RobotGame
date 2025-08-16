using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityOneLove.Services.CompositeDisposable
{
    public class CompositeDisposable : IDisposable
    {
        public List<IDisposable> Disposables { get; } = new List<IDisposable>();

        public void Register(IDisposable disposable)
        {
            if (disposable == null)
                return;

            if (Disposables.Contains(disposable))
                return;

            Disposables.Add(disposable);
        }

        public void Unregister(IDisposable disposable)
        {
            if (disposable == null)
                return;

            if (Disposables.Contains(disposable))
            {
                disposable.Dispose();
                Disposables.Remove(disposable);
            }
        }

        public void Dispose()
        {
            if (Disposables == null)
                return;

            if (Disposables.Count <= 0)
                return;

            foreach (var disposable in Disposables.Where(disposable => disposable != null).ToList())
            {
                Unregister(disposable);
            }

            Disposables.Clear();
        }
    }
}