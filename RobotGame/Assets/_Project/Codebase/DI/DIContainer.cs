using System;
using System.Collections.Generic;

namespace DI
{
    public class DIContainer
    {
        private DIContainer parentContainer;

        private Dictionary<(Type, string), DIRegistrtaion> registrtaions = new();
        private HashSet<(Type, string)> resolutions = new();

        public DIContainer(DIContainer parentContainer = null)
        {
            this.parentContainer = parentContainer;
        }

        public void RegisterSingleton<T>(Func<T> factory)
        {
            Register((typeof(T), null), factory, true);
        }
        
        public void RegisterSingleton<T>(Func<T> factory, string tag)
        {
            Register((typeof(T), tag), factory, true);
        }

        public void RegisterTransient<T>(Func<T> factory)
        {
            Register((typeof(T), null), factory, false);
        }
        
        public void RegisterTransient<T>(Func<T> factory, string tag)
        {
            Register((typeof(T), tag), factory, false);
        }

        public void RegisterInstance<T>(T instance)
        {
            (Type, string) key = (typeof(T), null);

            if (registrtaions.ContainsKey(key))
                throw new Exception($"Duplicate key: {key}");

            registrtaions[key] = new()
            {
                IsSingleton = true,
                Instance = instance
            };
        }
        
        public void RegisterInstance<T>(T instance, string tag)
        {
            var key = (typeof(T), tag);

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
            Register((typeof(I), null), factory, true);
        }
        
        public void RegisterInterface<T, I>(Func<T> factory, string tag) where T : I
        {
            Register((typeof(I), tag), factory, true);
        }

        private void Register<T>((Type, string) key, Func<T> factory, bool isSingleton)
        {
            if (registrtaions.ContainsKey(key))
                throw new Exception($"Instance with key: {key} also has already been registered");

            registrtaions[key] = new()
            {
                IsSingleton = isSingleton,
                Factory = c => factory()
            };
        }

        public T Resolve<T>(string tag = null)
        {
            var key = (typeof(T), tag);
            
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