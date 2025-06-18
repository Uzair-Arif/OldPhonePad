using Microsoft.Extensions.DependencyInjection;
using OldPhonePad.Core.Interfaces;
using OldPhonePad.Core.Services;

namespace OldPhonePad.Console;

public static class ServiceConfigurator
{
    public static ServiceProvider Configure()
    {
        var services = new ServiceCollection();

        services.AddScoped<IKeyMapProvider, OldPhoneKeyMap>();
        services.AddScoped<IOldPhoneInterpreter, OldPhoneInterpreter>();

        return services.BuildServiceProvider();
    }
}