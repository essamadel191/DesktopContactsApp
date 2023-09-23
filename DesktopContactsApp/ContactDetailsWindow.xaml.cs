using DesktopContactsApp.Classes;
using SQLite;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact selectedContact;
        public ContactDetailsWindow(Contact selectedContact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.selectedContact = selectedContact;
            nameTextBox.Text = this.selectedContact.Name;
            emailTextBox.Text = this.selectedContact.Email;
            phoneTextBox.Text = this.selectedContact.Phone;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            selectedContact.Name = nameTextBox.Text;
            selectedContact.Phone = phoneTextBox.Text;
            selectedContact.Email = emailTextBox.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                conn.Update(selectedContact);
            }

            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                conn.Delete(selectedContact);
            }

            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            selectedContact = new Contact();
            Close();
        }
    }
}
