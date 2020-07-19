﻿using Organiser.UI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;
        public NavigationItemViewModel(int id, string displayMember)
        {
            Id = id;
            _displayMember = displayMember;
        }



        public int Id { get;}
        public string DisplayMember
        {
            get { return _displayMember; }
            set 
            { 
                _displayMember = value;
                OnPropertyChanged();
            }
        }

    }
}
