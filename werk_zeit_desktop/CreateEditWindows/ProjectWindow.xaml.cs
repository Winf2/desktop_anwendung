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

namespace WpfApplication3
{
    /// <summary>
    /// Interaktionslogik für NewProjektWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        public ProjectWindow()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
