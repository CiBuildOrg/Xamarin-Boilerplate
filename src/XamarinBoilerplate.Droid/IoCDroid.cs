using Autofac;
using MobileTemplate.Droid.Service;
using XamarinBoilerplate.Core.Services;

namespace MobileTemplate.Droid
{
    public static class IoCDroid
    {
        public static void RegisterDroidDependencies(this ContainerBuilder builder)
        {
            // -- Add your Android-specific injected services here.
            // builder.RegisterType<Class>().As<IInterface>().SingleInstance();
            builder.RegisterType<SampleServiceDroid>().As<ISampleService>().SingleInstance();
            builder.RegisterType<AssetServiceDroid>().As<IAssetService>().SingleInstance();
        }
    }
}
