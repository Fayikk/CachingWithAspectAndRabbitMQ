using Castle.DynamicProxy;
using RabbitMQExample.Aspects.Autofac.Caching;
using RabbitMQExample.Interceptors;
using RabbitMQExample.Utilities;

namespace RabbitMQExample.CrossCuttingConcerns
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
