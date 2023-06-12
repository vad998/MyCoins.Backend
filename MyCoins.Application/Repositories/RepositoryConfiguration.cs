using Microsoft.Extensions.DependencyInjection;
using MyCoins.Domain.Repositories.AbstractRepositories;
using System.Reflection;

namespace MyCoins.Application.Repositories
{
    public static class RepositoryConfiguration
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            Assembly domainAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == "MyCoins.Domain");
            Assembly applicationAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == "MyCoins.Application");

            if (applicationAssembly is not null)
            {
                var concreteImplementations = applicationAssembly.GetTypes()
                    .Where(t => t.Namespace == "MyCoins.Application.Repositories.ConcreteRepositories" && t.IsClass && !t.IsNested);

                if (domainAssembly is not null)
                {
                    var servicePairs = domainAssembly.GetTypes()
                        .Where(t => t.Namespace == "MyCoins.Domain.Repositories.EntityRepository" && t.IsInterface
                            && t.GetInterfaces().Any(i => (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseRepository<>))))
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
}
