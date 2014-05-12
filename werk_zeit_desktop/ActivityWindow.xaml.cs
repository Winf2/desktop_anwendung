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
    /// Interaktionslogik für NewActivityWindow.xaml
    /// </summary>
    public partial class ActivityWindow : Window
    {
        private zeiterfassungPortTypeClient zpo = SoapConnection.zpo;

        public ActivityWindow()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            String description = new TextRange(richTextBoxDescription.Document.ContentStart, richTextBoxDescription.Document.ContentEnd).Text;
            int status;
            if (checkBoxStatus.IsChecked == true)
            {
                status = 1;
            }
            else
            {
                status = 0;
            }
            zpo.createactivity(textBoxActivityName.Text,
                description,
                status);

            this.Close();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
