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

        private void loadComponents()
        {
            combobox_role.ItemsSource = zpo.loadauthorisations();
            combobox_role.SelectedValue = "Anwender";
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_create_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
