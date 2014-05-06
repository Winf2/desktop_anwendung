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
    /// Interaktionslogik für NewEmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        private zeiterfassungPortTypeClient zpo = SoapConnection.zpo;

        public EmployeeWindow()
        {
            InitializeComponent();
            loadComponents();
        }

        //Rollen werden aus der Datenbank geladen
        //Standartwert: "Anwender"
        private void loadComponents()
        {
            combobox_role.ItemsSource = zpo.loadauthorisations();
            combobox_role.SelectedValue = "Anwender";
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Neuer Mitarbeiter wird erstellt
        //Neue Adresse wird erstellt
        private void button_create_Click(object sender, RoutedEventArgs e)
        {
            String tdrDate = DateTime.ParseExact(datepickerBirthday.SelectedDate.Value.ToString("dd.MM.yyyy"), "dd.MM.yyyy", null).ToString("yyyy-MM-dd");
            int employeeID = zpo.createemployee(
                Int16.Parse(textbox_persnr.Text), 
                textbox_lastname.Text, 
                textbox_firstname.Text,
                tdrDate,
                textbox_department.Text,
                textbox_mobil.Text, 
                textbox_festnetz.Text,
                textbox_email.Text, 
                1, 
                Int16.Parse(passwordboxPIN.Password), 
                checkBox_status.IsEnabled);
            int addressID = zpo.createaddress(textbox_location.Text, Int16.Parse(textbox_zipcode.Text), 
                textbox_street.Text, textbox_housenumber.Text, 0);
            
            bool employeeHasAddressID = zpo.employeehasaddress(employeeID, addressID);
            MessageBox.Show("Kunde wurde erfolgreich mit folgenden Eigenschaften angelegt.\nCustomerID:" + employeeID + "\nAddressID:" + addressID + "\nCustomerHasAddress:" + employeeHasAddressID);

        }
    }
}
