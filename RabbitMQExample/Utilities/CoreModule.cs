using RabbitMQExample.Aspects.Autofac.Caching.Microsoft;
using RabbitMQExample.Aspects.Autofac.Caching;
using System.Diagnostics;

namespace RabbitMQExample.Utilities
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>(); //Burada yine dinamik bir yapı kullanmış olduk.
            serviceCollection.AddSingleton<Stopwatch>();
        }

    }
}
