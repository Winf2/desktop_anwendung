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
    /// Interaktionslogik für NewProjektWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        private zeiterfassungPortTypeClient zpo = SoapConnection.zpo;

        public ProjectWindow()
        {
            InitializeComponent();
            comboBoxCustomer.ItemsSource = zpo.loadcustomers();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            String description = new TextRange(richTextBoxDescription.Document.ContentStart, richTextBoxDescription.Document.ContentEnd).Text;
            String value = comboBoxCustomer.SelectedValue.ToString();
            int customerID = zpo.selectedcustomer(value);
            int status;
            if (checkBoxStatus.IsChecked == true)
            {
                status = 1;
            }
            else
            {
                status = 0;
            }
            zpo.createproject(textBoxProjectName.Text, 
                description, 
                status, 
                customerID);

            this.Close();
        }
    }
}
