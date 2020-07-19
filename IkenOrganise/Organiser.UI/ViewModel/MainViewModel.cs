using Organiser.Model;
using Organiser.UI.Helper;
using Organiser.UI.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Organiser.UI.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        //private INavigationViewModel _navigationViewModel;

        public MainViewModel(INavigationViewModel navigationViewModel,
                            IPersonDetailViewModel personDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            PersonDetailViewModel = personDetailViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        public INavigationViewModel NavigationViewModel { get; }
        public IPersonDetailViewModel PersonDetailViewModel { get; }



    }
}
