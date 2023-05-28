using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using RabbitMQExample.Interceptors;
using RabbitMQExample.Services;
using RabbitMQExample.Services.Abstract;

namespace RabbitMQExample.AutofacBusiness
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
