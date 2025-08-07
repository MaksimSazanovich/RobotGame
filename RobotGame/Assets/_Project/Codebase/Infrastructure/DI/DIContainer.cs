using System;
using System.Collections.Generic;

namespace Unity_one_love.RobotGame
{
    public class DIContainer
    {
        private DIContainer parentContainer;

        private Dictionary<Type, DIRegistrtaion> registrtaions = new();
        private HashSet<Type> resolutions = new();

        public DIContainer(DIContainer parentContainer = null)
        {
            this.parentContainer = parentContainer;
        }

        public void RegisterSingleton<T>(Func<T> factory)
        {
            Register(typeof(T), factory, true);
        }

        public void RegisterTransient<T>(Func<T> factory)
        {
            Register(typeof(T), factory, false);
        }

        public void RegisterInstance<T>(T instance)
        {
            var key = typeof(T);

            if (registrtaions.ContainsKey(key))
                throw new Exception($"Duplicate key: {key}");

            registrtaions[key] = new()
            {
                IsSingleton = true,
                Instance = instance
            };
        }

        public void RegisterInterface<T, I>(Func<T> factory) where T : I
        {
            Register(typeof(I), factory, true);
        }

        private void Register<T>(Type key, Func<T> factory, bool isSingleton)
        {
            if (registrtaions.ContainsKey(key))
                throw new Exception($"Instance with key: {key} also has already been registered");

            registrtaions[key] = new()
            {
                IsSingleton = isSingleton,
                Factory = c => factory()
            };
        }

        public T Resolve<T>()
        {
            var key = typeof(T);
            
            if(resolutions.Contains(key))
                throw new Exception($"Cyclic dependency for key: {key}");
            
            resolutions.Add(key);
            try
            {
                if (registrtaions.TryGetValue(key, out var registration))
                {
                
                    if (registration.IsSingleton)
                    {
                        if (registration.Instance == null && registration.Factory != null)
                        {
                            registration.Instance = (T)registration.Factory(this);
                        }
                    
                        return (T)registration.Instance;
                    }
                
                    return (T)registration.Factory(this);
                }

                if (parentContainer != null)
                {
                    return parentContainer.Resolve<T>();
                }
            }
            finally
            {
                resolutions.Remove(key);
            }
            
            throw new Exception($"instance with key: {key} has not been registered");
        }
    }
}