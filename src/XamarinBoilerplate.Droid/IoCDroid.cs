using Autofac;
using XamarinBoilerplate.Droid.Service;
using XamarinBoilerplate.Core.Services;

namespace XamarinBoilerplate.Droid
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
