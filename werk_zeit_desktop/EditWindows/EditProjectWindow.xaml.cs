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
    /// Interaktionslogik für EditProjectWindow.xaml
    /// </summary>
    public partial class EditProjectWindow : Window
    {
        private String name;
        private String description;
        private int id;
        private String customername;
        private zeiterfassungPortTypeClient zpo = SoapConnection.zpo;

        public EditProjectWindow(int id, String name, String description, String customername)
        {
            InitializeComponent();
            this.name = name;
            this.description = description;
            this.customername = customername;
            this.id = id;
            loadContent();
        }

        private void loadContent()
        {
            comboBoxCustomer.ItemsSource = zpo.loadcustomers();

            this.textBoxProjectName.Text = name;
            this.comboBoxCustomer.SelectedValue = customername;
            this.textBoxDescription.Text = description;
        }

        private void buttonFinish_Click(object sender, RoutedEventArgs e)
        {
            int customer_nr = zpo.selectedcustomer(comboBoxCustomer.SelectedValue.ToString());
            zpo.updateProject(id, textBoxProjectName.Text, textBoxDescription.Text, customer_nr);
            this.Close();
        }
    }
}
