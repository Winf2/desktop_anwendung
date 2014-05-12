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


namespace WpfApplication3
{
    /// <summary>
    /// Interaktionslogik für NewCustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private zeiterfassungPortTypeClient zpo = SoapConnection.zpo;

        public CustomerWindow()
        {
            InitializeComponent();
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Neuer Kunde wird erstellt
        private void button_create_Click(object sender, RoutedEventArgs e)
        {
            int status=-1;
            if(checkbox_status.IsChecked==true){
                status = 1;
            }
            else{
                status = 0;
            }
            String address = new TextRange(richtextboxadresse.Document.ContentStart, richtextboxadresse.Document.ContentEnd).Text;

            int customerID = zpo.createcustomer(Int32.Parse(textbox_custnr.Text),
                textbox_lastname.Text,
                textbox_firstname.Text,
                textbox_company.Text,
                address,
                textbox_mobil.Text,
                textbox_festnetz.Text,
                textbox_email.Text,
                status);
            MessageBox.Show(customerID.ToString());
            this.Close();
        }
    }
}
