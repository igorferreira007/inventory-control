using InventoryControl.Application.DependencyInjection;
using InventoryControl.Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryControl.Presentation;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();

        const string connectionString =
            "Host=localhost;Port=5432;Database=inventory_control;Username=postgres;Password=postgres";

        services.AddApplication();
        services.AddInfrastructure(connectionString);

        services.AddTransient<Form1>();
        services.AddTransient<MainForm>();

        using var serviceProvider = services.BuildServiceProvider();

        var mainForm = serviceProvider.GetRequiredService<MainForm>();

        System.Windows.Forms.Application.Run(mainForm);
    }
}