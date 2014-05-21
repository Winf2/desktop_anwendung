using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaktionslogik für EditActivityWindow.xaml
    /// </summary>
    public partial class EditActivityWindow : Window
    {
        private String name;
        private String description;
        private int id;
        private zeiterfassungPortTypeClient zpo = SoapConnection.zpo;


        public EditActivityWindow(int id, String name, String description)
        {
            InitializeComponent();
            this.name = name;
            this.description = description;
            this.id = id;
            loadContent();
        }

        private void loadContent()
        {
            this.textBoxActivityName.Text = name;
            this.textBoxDescription.Text =  description;
        }

        private void buttonFinish_Click(object sender, RoutedEventArgs e)
        {
            zpo.updateActivity(id, textBoxActivityName.Text, textBoxDescription.Text);
            this.Close();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
