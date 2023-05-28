using Castle.DynamicProxy;

namespace RabbitMQExample.Interceptors
{
    public class MethodInterceptionAttributeBase : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
