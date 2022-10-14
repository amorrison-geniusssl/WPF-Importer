using ImporterData;
using ImporterUI.Data;
using ImporterUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace ImporterUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();

            services.AddTransient<DebtorsViewModel>();
            services.AddTransient<PaymentsViewModel>();

            services.AddTransient<ImporterDb>();
            services.AddTransient<IDebtorRespository, DebtorRespository>();
            services.AddTransient<IPaymentRespository, PaymentRespository>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
    