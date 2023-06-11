using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MyCoins.Application.Common.Mappings.Attributes;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MyCoins.Application.Common.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            IEnumerable<Type> mappingProfilesTypeCollection = assembly.GetMappingProfilesTypeCollectionFromAssembly();
            IEnumerable<Profile> mappingProfilesObjectsCollection = mappingProfilesTypeCollection.Select(t => Activator.CreateInstance(t) as Profile)
                .Where(p => p != null);
            MapperConfiguration mapperConfiguration = new(mc =>
            {
                foreach (var mappingProfile in mappingProfilesObjectsCollection)
                {
                    mc.AddProfile(mappingProfile);
                }
            });
            // mapperConfiguration.AssertConfigurationIsValid();
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
        public static IEnumerable<Type> GetMappingProfilesTypeCollectionFromAssembly(this Assembly assembly) =>
            assembly.GetTypes().Where(t => t.Namespace == "MyCoins.Application.MappingProfiles"
                                && t.GetCustomAttribute<CompilerGeneratedAttribute>() == null
                                && t.GetCustomAttribute<NonMappedProfileAttribute>() == null);
    }
}
