using RabbitMQExample.Utilities;

namespace RabbitMQExample.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencyResolver
          (this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
