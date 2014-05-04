using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication3.ServiceReference1;

namespace WpfApplication3
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private zeiterfassungPortTypeClient zpo = SoapConnection.zpo;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void mit_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void tab_overview_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;
            tool_button_new.Visibility = System.Windows.Visibility.Visible;
            tool_button_edit.Visibility = System.Windows.Visibility.Visible;
            tool_button_archiv.Visibility = System.Windows.Visibility.Visible;
            tool_button_delete.Visibility = System.Windows.Visibility.Visible;
        }

        private void tab_projects_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;
            tool_button_new.Visibility = System.Windows.Visibility.Visible;
            tool_button_edit.Visibility = System.Windows.Visibility.Visible;
            tool_button_archiv.Visibility = System.Windows.Visibility.Visible;
            tool_button_delete.Visibility = System.Windows.Visibility.Visible;
        }

        private void tab_activities_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;
            tool_button_new.Visibility = System.Windows.Visibility.Visible;
            tool_button_edit.Visibility = System.Windows.Visibility.Visible;
            tool_button_archiv.Visibility = System.Windows.Visibility.Visible;
            tool_button_delete.Visibility = System.Windows.Visibility.Visible;
        }

        private void tab_customers_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;
            tool_button_new.Visibility = System.Windows.Visibility.Visible;
            tool_button_edit.Visibility = System.Windows.Visibility.Visible;
            tool_button_archiv.Visibility = System.Windows.Visibility.Visible;
            tool_button_delete.Visibility = System.Windows.Visibility.Visible;
        }

        private void tab_employee_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;
            tool_button_new.Visibility = System.Windows.Visibility.Visible;
            tool_button_edit.Visibility = System.Windows.Visibility.Visible;
            tool_button_archiv.Visibility = System.Windows.Visibility.Visible;
            tool_button_delete.Visibility = System.Windows.Visibility.Visible;
        }

        private void textblock_analysis_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;

            tool_button_new.Visibility = System.Windows.Visibility.Collapsed;
            tool_button_edit.Visibility = System.Windows.Visibility.Collapsed;
            tool_button_archiv.Visibility = System.Windows.Visibility.Collapsed;
            tool_button_delete.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void tab_analysis_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;

            tool_button_new.Visibility = System.Windows.Visibility.Collapsed;
            tool_button_edit.Visibility = System.Windows.Visibility.Collapsed;
            tool_button_archiv.Visibility = System.Windows.Visibility.Collapsed;
            tool_button_delete.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void tab_archiv_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;
            tool_button_delete.Visibility = System.Windows.Visibility.Visible;

            tool_button_new.Visibility = System.Windows.Visibility.Collapsed;
            tool_button_edit.Visibility = System.Windows.Visibility.Collapsed;
            tool_button_archiv.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void tool_button_new_Click(object sender, RoutedEventArgs e)
        {
            int tabIndex = tab_control.SelectedIndex;
            switch(tabIndex){
                case(0):
                    WorkingTimeWindow WorkingTime = new WorkingTimeWindow();
                    WorkingTime.ShowDialog();
                    break;
                case(1):
                    ProjectWindow Project = new ProjectWindow();
                    Project.ShowDialog();
                    break;
                case(2): 
                    ActivityWindow newActivity = new ActivityWindow();
                    newActivity.ShowDialog();
                    break;
                case(3): 
                    CustomerWindow newCustomer = new CustomerWindow();
                    newCustomer.ShowDialog();
                    break;
                case(4): 
                    EmployeeWindow newEmployee = new EmployeeWindow();
                    newEmployee.ShowDialog();
                    break;
                default: 
                    break;
            }
        }

        private void expander_workingTime_Expanded(object sender, RoutedEventArgs e)
        {
            tool_button_userFilter.Visibility = Visibility.Visible;
        }

        private void expander_workingTime_Collapsed(object sender, RoutedEventArgs e)
        {
            tool_button_userFilter.Visibility = Visibility.Collapsed;
        }

        private void tab_control_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            expander_workingTime.IsExpanded = false;
        }

        private void tool_button_refresh_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
