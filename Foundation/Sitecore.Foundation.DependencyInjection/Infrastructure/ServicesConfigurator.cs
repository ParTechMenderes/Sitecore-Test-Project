namespace Sitecore.Foundation.DependencyInjection.Infrastructure
{    
    using Microsoft.Extensions.DependencyInjection;
    using Sitecore.DependencyInjection;
    using Test_Website.Controllers;
    using Test_Website.Repository;

    public class RegisterDependencies : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<INavigationRepository, NavigationRepository>();
            serviceCollection.AddTransient<NavigationController>();
            serviceCollection.AddTransient<INewsRepository, NewsRepository>();
            serviceCollection.AddTransient<NewsController>();
        }
    }
}