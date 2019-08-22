using MyContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MyContactsApp
{
    /// <summary>
    /// Interaction logic for AddNewContactWindow.xaml
    /// </summary>
    public partial class AddNewContactWindow : Window
    {
        #region Fields
        SQLiteConnection sqLiteConnection;
        #endregion

        #region Constructor
        public AddNewContactWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                Email = emailTextBox.Text,
                PhoneNumber = phoneNumberTextBox.Text
            };

            using (sqLiteConnection = ConnectDatabase(App.CreateDatabasePath()))
            {
                sqLiteConnection.CreateTable<Contact>();
                sqLiteConnection.Insert(contact);
                sqLiteConnection.Dispose();
            }
               

            this.Close();
        }

        
        public SQLiteConnection ConnectDatabase(string databasePath)
        {
            return new SQLiteConnection(databasePath);
        }
        #endregion
    }
}
