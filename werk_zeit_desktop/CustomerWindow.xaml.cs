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

        private void button_create_Click(object sender, RoutedEventArgs e)
        {
            int status=-1;
            if(checkbox_status.IsChecked==true){
                status = 1;
            }
            else{
                status = 0;
            }
            int customerID = zpo.createcustomer(Int32.Parse(textbox_custnr.Text),
                textbox_lastname.Text,
                textbox_firstname.Text,
                textbox_company.Text,
                textbox_mobil.Text,
                textbox_festnetz.Text,
                textbox_email.Text,
                status);

            int addressID = zpo.createaddress(textbox_location.Text,
                Int32.Parse(textbox_zipcode.Text),
                textbox_street.Text,
                textbox_housenumber.Text,
                Int32.Parse(textbox_postofficebox.Text));

            bool customerhasaddressID = zpo.customerhasaddress(customerID, addressID);
            MessageBox.Show("Kunde wurde erfolgreich mit folgenden Eigenschaften angelegt.\nCustomerID:" + customerID + "\nAddressID:" + addressID + "\nCustomerHasAddress:" + customerhasaddressID);

            this.Close();
        }
    }
}
