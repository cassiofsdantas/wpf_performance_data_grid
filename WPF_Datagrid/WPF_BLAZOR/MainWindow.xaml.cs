using System.Net.Http;
using System.Windows;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace WPF_BLAZOR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddMudServices();
            serviceCollection.AddScoped<HttpClient>();

            serviceCollection
                .AddBlazorise(options =>
                {
                    options.Immediate = true;
                })
            .AddBootstrapProviders()
            .AddFontAwesomeIcons();

            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}
