using MyContactsApp.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            ReadDatabase();
            this.Contacts = new ObservableCollection<Contact>();
            UpdateView();
        }

        public void UpdateView()
        {
            if (contacts != null)
            {
                foreach (var contact in contacts)
                {
                    Contacts.Add(new Contact()
                    {
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Email = contact.Email,
                        PhoneNumber = contact.PhoneNumber
                    });
                }
            }
            contactsListView.ItemsSource = Contacts;
        }
        private void ButtonNewContact_Click(object sender, RoutedEventArgs e)
        {
            AddNewContactWindow addNewContactWindow = new AddNewContactWindow();
            addNewContactWindow.ShowDialog();

            ReadDatabase();
            UpdateView();
        }
        void ReadDatabase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.CreateDatabasePath()))
            {
                conn.CreateTable<Contact>();
                contacts = conn.Table<Contact>().ToList();
            }
        }
    }
}
