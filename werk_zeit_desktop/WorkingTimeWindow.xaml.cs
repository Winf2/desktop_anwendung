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
    /// Interaktionslogik für WorkingTimeWindow.xaml
    /// </summary>
    public partial class WorkingTimeWindow : Window
    {
        public WorkingTimeWindow()
        {
            InitializeComponent();
            fillComboBoxes();
        }

        private void fillComboBoxes()
        {
            zeiterfassungPortTypeClient zpo = new zeiterfassungPortTypeClient();
            String[] arrayProjects = null;
            String[] arrayActivity = null;
            arrayProjects = zpo.loadprojects();
            arrayActivity = zpo.loadactivities();
            combobox_project.ItemsSource = arrayProjects;
            combobox_activity.ItemsSource = arrayActivity;
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_create_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButtonChanged(int number)
        {
            switch (number)
            {
                case 1:
                    label_workingTimeTerm.Visibility = Visibility.Collapsed;
                    label_pauseTerm.Visibility = Visibility.Collapsed;
                    textbox_workingTimeTerm.Visibility = Visibility.Collapsed;
                    textbox_pauseTerm.Visibility = Visibility.Collapsed;

                    label_workingTimeFrom.Visibility = Visibility.Visible;
                    label_workingTimeTill.Visibility = Visibility.Visible;
                    label_pauseFrom.Visibility = Visibility.Visible;
                    label_pauseTill.Visibility = Visibility.Visible;
                    textbox_workingTimeFrom.Visibility = Visibility.Visible;
                    textbox_workingTimeTill.Visibility = Visibility.Visible;
                    textbox_pauseFrom.Visibility = Visibility.Visible;
                    textbox_pauseTill.Visibility = Visibility.Visible;

                    break;
                case 2:
                    label_workingTimeTerm.Visibility = Visibility.Visible;
                    label_pauseTerm.Visibility = Visibility.Visible;
                    textbox_workingTimeTerm.Visibility = Visibility.Visible;
                    textbox_pauseTerm.Visibility = Visibility.Visible;

                    label_workingTimeFrom.Visibility = Visibility.Collapsed;
                    label_workingTimeTill.Visibility = Visibility.Collapsed;
                    label_pauseFrom.Visibility = Visibility.Collapsed;
                    label_pauseTill.Visibility = Visibility.Collapsed;
                    textbox_workingTimeFrom.Visibility = Visibility.Collapsed;
                    textbox_workingTimeTill.Visibility = Visibility.Collapsed;
                    textbox_pauseFrom.Visibility = Visibility.Collapsed;
                    textbox_pauseTill.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void radiobutton_time_Click(object sender, RoutedEventArgs e)
        {
            RadioButtonChanged(1);
            radiobutton_term.IsChecked = false;
        }

        private void radiobutton_term_Click(object sender, RoutedEventArgs e)
        {
            RadioButtonChanged(2);
            radiobutton_time.IsChecked = false;
        }
    }
}
