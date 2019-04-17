using CoopSoftNetCore.Context;
using CoopSoftNetCore.Core.Implementations;
using CoopSoftNetCore.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace CoopSoftNetCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureService(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<Home>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        private void ConfigureService(IServiceCollection services)
        {
            services.AddOptions();
            services.AddDbContext<DbContextCS>(option => option.UseSqlServer(Configuration.GetConnectionString("CSCS")));
            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));
            services.AddScoped<ISampleService,SampleService>();


            services.AddTransient(typeof(Login));
            services.AddTransient(typeof(Home));
        }
    }
}
