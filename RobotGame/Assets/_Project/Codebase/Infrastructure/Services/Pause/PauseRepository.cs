using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Pause
{
    public class PauseRepository : IDisposable
    {
        public List<IPausable> Pausables { get; } = new List<IPausable>();

        public void Register(IPausable pausable)
        {
            if (pausable == null)
                return;

            if (Pausables.Contains(pausable))
                return;

            Pausables.Add(pausable);
        }

        public void Unregister(IPausable pausable)
        {
            if (pausable == null)
                return;

            if (Pausables.Contains(pausable))
                Pausables.Remove(pausable);
        }

        public void Dispose()
        {
            if(Pausables == null)
                return;
            
            if(Pausables.Count <= 0)
                return;

            foreach (var pausable in Pausables.Where(pausable => pausable != null).ToList())
            {
                Unregister(pausable);
            }

            Pausables.Clear();
        }
    }
}