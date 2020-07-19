using Organiser.Model;
using Organiser.UI.Event;
using Organiser.UI.Helper;
using Organiser.UI.Interfaces;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Organiser.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private ILookUpDataService _lookUpDataService;
        private IEventAggregator _eventAggregator;
        private NavigationItemViewModel _selectedPerson;

        public NavigationViewModel(ILookUpDataService lookUpDataService, IEventAggregator eventAggregator)
        {
            _lookUpDataService = lookUpDataService;
            _eventAggregator = eventAggregator;

            People = new ObservableCollection<NavigationItemViewModel> ();

            _eventAggregator.GetEvent<AfterPersonSavedEvent>().Subscribe(AfterPersonSaved);
        }

        private void AfterPersonSaved(AfterPersonSavedEventArgs personDetails)
        {
            var lookUpItem = People.Single(p => p.Id == personDetails.Id);

            lookUpItem.DisplayMember = personDetails.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var lookup = await _lookUpDataService.GetPersonLookUpAsync();

            People.Clear();
            foreach (var item in lookup)
            {
                //People.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
        }

        public ObservableCollection<NavigationItemViewModel> People { get; }

        public NavigationItemViewModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();

                if(_selectedPerson != null)
                {
                    _eventAggregator.GetEvent<OpenPersonDetailViewEvent>().Publish(_selectedPerson.Id);
                }
            }
        }


    }
}
