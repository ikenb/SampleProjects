using Organiser.Model;
using Organiser.UI.Event;
using Organiser.UI.Helper;
using Organiser.UI.Interfaces;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Organiser.UI.ViewModel
{
    public class PersonDetailViewModel : ViewModelBase, IPersonDetailViewModel
    {
        private IPersonDataService _personDataService;
        private IEventAggregator _eventAggregator;
        private Person _person;

        public PersonDetailViewModel(IPersonDataService personDataService, IEventAggregator eventAggregator)
        {
            _personDataService = personDataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenPersonDetailViewEvent>().Subscribe(OnOpenDetailView);

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

      

        private async void OnSaveExecute()
        {
            await _personDataService.SaveAsync(Person);

            _eventAggregator.GetEvent<AfterPersonSavedEvent>().Publish(
                new AfterPersonSavedEventArgs
                {
                    Id = Person.Id,
                    DisplayMember = $"{Person.FirstName} { Person.LastName}"

                });
        }
        private bool OnSaveCanExecute()
        {
            return true; //TODO: Validate Person
        }

        private async void OnOpenDetailView(int personId)
        {
            await LoadAsync(personId);
        }

        public async Task LoadAsync(int personId)
        {
            Person = await _personDataService.GetPersonByIdAsync(personId);
        }



        public Person Person
        {
            get { return _person; }
            private set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get;}

    }
}
