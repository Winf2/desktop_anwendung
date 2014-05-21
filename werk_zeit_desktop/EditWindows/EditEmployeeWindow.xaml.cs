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
    /// Interaktionslogik für EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        private zeiterfassungPortTypeClient zpo = SoapConnection.zpo;
        private int employeenr;
        private String firstname, lastname, address, email, festnetz, mobil, department, role, hours;
        //Zeit fehlt noch

        public EditEmployeeWindow(int employeenr, String role, String firstname, String lastname, String address, String email, String festnetz, String mobil, String department, String hours)
        {
            InitializeComponent();
            this.employeenr = employeenr;
            this.role = role;
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.email = email;
            this.festnetz = festnetz;
            this.hours = hours;
            this.mobil = mobil;
            this.department = department;

            loadContent();
        }

        private void loadContent()
        {
            combobox_role.ItemsSource = zpo.loadauthorisations();
            combobox_role.SelectedValue = "Anwender";

            this.combobox_role.SelectedValue = role;
            this.textbox_hours.Text = hours;
            this.textbox_firstname.Text = firstname;
            this.textbox_lastname.Text = lastname;
            this.textBoxAddress.Text = address;
            this.textbox_email.Text = email;
            this.textbox_festnetz.Text = festnetz;
            this.textbox_mobil.Text = mobil;
            this.textbox_department.Text = department;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonFinish_Click(object sender, RoutedEventArgs e)
        {
            zpo.updateEmployee(
                employeenr,
                textbox_lastname.Text,
                textbox_firstname.Text,
                textBoxAddress.Text,
                textbox_email.Text,
                textbox_mobil.Text,
                textbox_festnetz.Text,
                textbox_department.Text,
                textbox_hours.Text,
                combobox_role.SelectedIndex+1);
            this.Close();
        }
    }
}
