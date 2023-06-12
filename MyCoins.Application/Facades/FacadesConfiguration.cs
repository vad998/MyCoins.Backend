using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MyCoins.Application.Facades
{
    public static class ConfigureFacadesExtensionClass
    {
        public static void ConfigureFacades(this IServiceCollection services)
        {
            Assembly applicationAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == "MyCoins.Application");
            if (applicationAssembly is not null)
            {
                var concreteImplementations = applicationAssembly.GetTypes()
                    .Where(t => t.Namespace == "MyCoins.Application.Facades.ConcreteFacades" && t.IsClass && !t.IsNested);

                var servicePairs = applicationAssembly.GetTypes()
                    .Where(t => t.Namespace == "MyCoins.Application.Facades.InterfaceFacades" && t.IsInterface)
                    .Select(serviceInterface => (
                        Service: serviceInterface,
                        Implementation: concreteImplementations.FirstOrDefault(ci => ci.GetInterfaces().Any(i => i == serviceInterface))));

                foreach (var (Service, Implementation) in servicePairs)
                {
                    services.AddTransient(Service, Implementation);
                }
            }
        }
    }
}