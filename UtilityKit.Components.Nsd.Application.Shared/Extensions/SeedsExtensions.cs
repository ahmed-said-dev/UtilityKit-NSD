using UtilityKit.Components.Nsd.Application.Shared.Interfaces;
using System.Reflection;
namespace UtilityKit.Components.Nsd.Application.Shared.Extensions;

public static class SeedsExtensions
{

    public static void Seed(this IServiceProvider services, Assembly assembly)
    {
        var seeds = assembly.ExportedTypes.Where(x =>
          typeof(ISeed).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(
            Activator.CreateInstance).Cast<ISeed>().ToList();

        seeds.ForEach(installer => installer.Seed(services));
    }
}
