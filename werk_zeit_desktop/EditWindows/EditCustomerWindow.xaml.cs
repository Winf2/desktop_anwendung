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
using WpfApplication3.ServiceReference1;

namespace WpfApplication3.EditWindows
{
    /// <summary>
    /// Interaktionslogik für EditCustomerWindow.xaml
    /// </summary>
    public partial class EditCustomerWindow : Window
    {
        private String company, firstname, lastname, address, email, festnetz, mobil;
        private int customernr;
        private zeiterfassungPortTypeClient zpo = SoapConnection.zpo;

        
        public EditCustomerWindow(int customernr, String company, String firstname, String lastname, String address, String email, String festnetz, String mobil)
        {
            InitializeComponent();

            this.customernr = customernr;
            this.company = company;
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.email = email;
            this.festnetz = festnetz;
            this.mobil = mobil;

            loadContent();
        }

        private void loadContent()
        {
            this.textbox_company.Text = company;
            this.textbox_firstname.Text = firstname;
            this.textbox_lastname.Text = lastname;
            this.textBoxAddress.Text = address;
            this.textbox_email.Text = email;
            this.textbox_festnetz.Text = festnetz;
            this.textbox_mobil.Text = mobil;
        }

        private void buttonFinish_Click(object sender, RoutedEventArgs e)
        {
            zpo.updateCustomer(
                customernr, 
                textbox_lastname.Text, 
                textbox_firstname.Text, 
                textBoxAddress.Text, 
                textbox_company.Text, 
                textbox_mobil.Text, 
                textbox_festnetz.Text, 
                textbox_email.Text);
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
