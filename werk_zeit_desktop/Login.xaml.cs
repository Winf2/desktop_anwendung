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
using System.Data;
using System.Data.SqlClient;

namespace WpfApplication3
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPassword.Password == "********")
            {
                textBoxPassword.Password = "";
            }
        }

        private void textBoxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPassword.Password == "")
            {
                textBoxPassword.Password = "********";
            }
            
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxUsername.Text == "Benutzername")
            {
                textBoxUsername.Text = "";
            }
        }

        private void textBoxUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxUsername.Text == "") 
            {
                textBoxUsername.Text = "Benutzername";
            }
            
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            //Benutzername und Passwort überprüfen
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.ShowDialog();
            this.Show();
        }


    }
}
