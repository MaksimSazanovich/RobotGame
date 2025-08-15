using System;

namespace UnityOneLove.DI
{
    public class DIRegistrtaion
    {
        public Func<DIContainer, object> Factory { get; set; }
        public bool IsSingleton { get; set; }
        public object Instance { get; set; }
    }
}