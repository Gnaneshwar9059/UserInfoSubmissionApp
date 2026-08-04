using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQLitePCL;
using UserInfoSubmissionApp.Configuration;
using UserInfoSubmissionApp.Data;
using UserInfoSubmissionApp.Forms;
using UserInfoSubmissionApp.Repositories;
using UserInfoSubmissionApp.Services;

namespace UserInfoSubmissionApp;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Batteries.Init();

        ApplicationConfiguration.Initialize();

        using var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(configuration =>
            {
                configuration.AddJsonFile("appsettings.json", optional: false);
            })
            .ConfigureServices((context, services) =>
            {
                services.Configure<DatabaseOptions>(
                    context.Configuration.GetSection(DatabaseOptions.SectionName));

                services.AddSingleton<ISqliteConnectionFactory, SqliteConnectionFactory>();
                services.AddSingleton<DatabaseInitializer>();

                services.AddScoped<ISubmissionRepository, SubmissionRepository>();
                services.AddScoped<ISubmissionService, SubmissionService>();

                services.AddTransient<LoginForm>();
            })
            .Build();

        host.Services
            .GetRequiredService<DatabaseInitializer>()
            .Initialize();

        while (true)
        {
            using var loginForm = host.Services.GetRequiredService<LoginForm>();

            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                break;
            }

            using var mainForm = new MainForm(
                loginForm.LoggedInUser!,
                host.Services.GetRequiredService<ISubmissionService>());

            Application.Run(mainForm);

            if (!mainForm.LogoutRequested)
            {
                break;
            }
        }
    }
}