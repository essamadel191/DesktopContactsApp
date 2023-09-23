using DesktopContactsApp.Classes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {


        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(
                new Contact() {Name = "Default or empty name", Phone = "Default or empty phone number"
                , Email = "Default or empty email"},setText));

        private static void setText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;
            if(control != null)
            {
                control.nameTextBlock.Text = (e.NewValue as Contact).Name;
                control.phoneTextBlock.Text = (e.NewValue as Contact).Phone;
                control.emailTextBlock.Text = (e.NewValue as Contact).Email;

            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
