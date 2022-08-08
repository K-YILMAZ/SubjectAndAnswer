using Ninject;

namespace Business.Concrete.DependencyResolvers.Ninject
{
    public  class InstanceFactory 
    {
        private static IKernel _kernel { get; set; }

        public static T GetInstance<T>()
        {
            _kernel = new StandardKernel(new BusinessModule());
            return _kernel.Get<T>();
        }
    }
}
