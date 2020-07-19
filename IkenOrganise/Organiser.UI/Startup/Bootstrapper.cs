using Autofac;
using Organiser.DataAccess;
using Organiser.UI.Data;
using Organiser.UI.Interfaces;
using Organiser.UI.View;
using Organiser.UI.ViewModel;
using Prism.Events;

namespace Organiser.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<OrganiserDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<PersonDetailViewModel>().As<IPersonDetailViewModel>();

            builder.RegisterType<PersonDataService>().As<IPersonDataService>();
            builder.RegisterType<LookUpDataService>().AsImplementedInterfaces();

            return builder.Build();
        }
    }
}
