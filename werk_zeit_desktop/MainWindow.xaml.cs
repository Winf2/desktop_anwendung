using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        //SOAP-Verbindung
        private zeiterfassungPortTypeClient zpo = SoapConnection.zpo;

        //Konstruktor der Klasse: MainWindow
        public MainWindow()
        {
            //Steuerelemente laden und zeichnen
            InitializeComponent();

            //Tabellen initialisieren
            initializeTables();
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties) row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private void initializeTables()
        {
        //Archiv
            TableDataWorkingTimes[] dataTableArchivWorkingTime = zpo.loadArchivTableWorkingTimes();
            dataGridArchivZeiten.ItemsSource = dataTableArchivWorkingTime;

        //Tabelle "Working_Time" laden und dem DataGrid übergeben
            TableDataWorkingTimes[] dataTableWorkingTime = zpo.loadtableworkingtimes();
            //dataGridWorkingTime.ItemsSource = dataTableWorkingTime.ToList();
            
            //Test für die Spaltennamendarstellung
            DataTable dt = ConvertToDataTable(dataTableWorkingTime.ToList());
            String [] columnsWorkingTimes = {"ID","Datum","Anfang","Ende","Projekt","Aktivität","Arbeitszeit","Überstunden","Pausenanfang","Pausenende","Gesamtpause","Gesamtarbeitszeit","Status"};
            for(int i=0;i<columnsWorkingTimes.Length;i++){
                dt.Columns[i].ColumnName = columnsWorkingTimes[i];
            }
            dataGridWorkingTime.ItemsSource = dt.DefaultView;

        //Archiv

            TableDataProjects[] dataTableArchivProjects = zpo.loadarchivtableprojects();
            DataTable dtArchivProjects = ConvertToDataTable(dataTableArchivProjects.ToList());
            dataGridArchivProjekte.ItemsSource = dtArchivProjects.DefaultView;
            //dataGridArchivProjekte.Columns[0].Visibility = System.Windows.Visibility.Hidden;
            //dataGridArchivProjekte.ItemsSource = dataTableArchivProjects;
        //Tabelle "Projects" laden und dem DataGrid übergeben
            TableDataProjects[] dataTableProjects = zpo.loadtableprojects();
            dataGridProjects.ItemsSource = dataTableProjects;

        //Archiv
            TableDataActivities[] dataTableArchivActivities = zpo.loadarchivtableactivities();
            dataGridArchivAktivitaeten.ItemsSource = dataTableArchivActivities;
        //Tabelle "Activities" laden und dem DataGrid übergeben
            TableDataActivities[] dataTableActivities = zpo.loadtableactivities();
            dataGridActivities.ItemsSource = dataTableActivities;

        //Archiv
            TableDataCustomers[] dataTaleArchivCustomers = zpo.loadarchivtablecustomers();
            dataGridArchivKunden.ItemsSource = dataTaleArchivCustomers;
        //Tabelle "Customer" laden und dem DataGrid übergeben
            TableDataCustomers[] dataTableCustomers = zpo.loadtablecustomers();
            datagridCustomers.ItemsSource = dataTableCustomers;

        //Archiv
            TableDataEmployees[] dataTableArchivEmployees = zpo.loadarchivtableemployees();
            dataGridArchivMitarbeiter.ItemsSource = dataTableArchivEmployees;
        //Tabelle "Employees" laden und dem DataGrid übergeben
            TableDataEmployees[] dataTableEmployees = zpo.loadtableemployees(); ;
            datagridEmployees.ItemsSource = dataTableEmployees;
        }

        /*#####################EventHandler##################*/
        //Application beenden
        private void mit_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Wenn Tab "Zeiten" angeklickt wird, werden die Steuerelemente der Toolbar aktualisiert
        private void tab_overview_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;
            tool_button_new.Visibility = System.Windows.Visibility.Visible;
            tool_button_edit.Visibility = System.Windows.Visibility.Visible;
            tool_button_archiv.Visibility = System.Windows.Visibility.Visible;

            tool_button_restore.Visibility = System.Windows.Visibility.Collapsed;
        }

        //Wenn Tab "Projekte" angeklickt wird, werden die Steuerelemente der Toolbar aktualisiert
        private void tab_projects_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;
            tool_button_new.Visibility = System.Windows.Visibility.Visible;
            tool_button_edit.Visibility = System.Windows.Visibility.Visible;
            tool_button_archiv.Visibility = System.Windows.Visibility.Visible;

            tool_button_restore.Visibility = System.Windows.Visibility.Collapsed;
        }

        //Wenn Tab "Aktivitäten" angeklickt wird, werden die Steuerelemente der Toolbar aktualisiert
        private void tab_activities_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;
            tool_button_new.Visibility = System.Windows.Visibility.Visible;
            tool_button_edit.Visibility = System.Windows.Visibility.Visible;
            tool_button_archiv.Visibility = System.Windows.Visibility.Visible;

            tool_button_restore.Visibility = System.Windows.Visibility.Collapsed;
        }

        //Wenn Tab "Kunden" angeklickt wird, werden die Steuerelemente der Toolbar aktualisiert
        private void tab_customers_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;
            tool_button_new.Visibility = System.Windows.Visibility.Visible;
            tool_button_edit.Visibility = System.Windows.Visibility.Visible;
            tool_button_archiv.Visibility = System.Windows.Visibility.Visible;

            tool_button_restore.Visibility = System.Windows.Visibility.Collapsed;
        }

        //Wenn Tab "Mitarbeiter" angeklickt wird, werden die Steuerelemente der Toolbar aktualisiert
        private void tab_employee_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;
            tool_button_new.Visibility = System.Windows.Visibility.Visible;
            tool_button_edit.Visibility = System.Windows.Visibility.Visible;
            tool_button_archiv.Visibility = System.Windows.Visibility.Visible;

            tool_button_restore.Visibility = System.Windows.Visibility.Collapsed;
        }

        //Wenn Tab "Auswertung" angeklickt wird, werden die Steuerelemente der Toolbar aktualisiert
        private void tab_analysis_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;

            tool_button_new.Visibility = System.Windows.Visibility.Collapsed;
            tool_button_edit.Visibility = System.Windows.Visibility.Collapsed;
            tool_button_archiv.Visibility = System.Windows.Visibility.Collapsed;
            tool_button_restore.Visibility = System.Windows.Visibility.Collapsed;
        }

        //Wenn Tab "Archiv" angeklickt wird, werden die Steuerelemente der Toolbar aktualisiert
        private void tab_archiv_GotFocus(object sender, RoutedEventArgs e)
        {
            tool_button_export.Visibility = System.Windows.Visibility.Visible;
            tool_button_restore.Visibility = System.Windows.Visibility.Visible;

            tool_button_new.Visibility = System.Windows.Visibility.Collapsed;
            tool_button_edit.Visibility = System.Windows.Visibility.Collapsed;
            tool_button_archiv.Visibility = System.Windows.Visibility.Collapsed;
        }

        /*Wenn der Toolbar-Button "Anlegen" angeklickt wird, wird überprüft, welcher Tab ausgewählt ist
        und wird je nach Auswahl ein Anlege-Fenster geöffnet*/
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

        //EventListener auf dem Filter-Expander steuern den Button "Filtern..." in der Toolbar
        private void expander_workingTime_Expanded(object sender, RoutedEventArgs e)
        {
            tool_button_userFilter.Visibility = Visibility.Visible;
        }

        private void expander_workingTime_Collapsed(object sender, RoutedEventArgs e)
        {
            tool_button_userFilter.Visibility = Visibility.Collapsed;
        }

        private void expander_projects_Collapsed(object sender, RoutedEventArgs e)
        {
            tool_button_userFilter.Visibility = Visibility.Collapsed;
        }

        private void expander_projects_Expanded(object sender, RoutedEventArgs e)
        {
            tool_button_userFilter.Visibility = Visibility.Visible;
        }

        private void expander_activities_Expanded(object sender, RoutedEventArgs e)
        {
            tool_button_userFilter.Visibility = Visibility.Visible;
        }

        private void expander_activities_Collapsed(object sender, RoutedEventArgs e)
        {
            tool_button_userFilter.Visibility = Visibility.Collapsed;
        }

        //Wenn der Tab gewechselt wird, dann werden die Expander wieder geschlossen
        private void tab_control_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            expander_workingTime.IsExpanded = false;
            expander_projects.IsExpanded = false;
            expander_activities.IsExpanded = false;
        }


        private void tool_button_refresh_Click(object sender, RoutedEventArgs e)
        {
            initializeTables();
        }

        private void tool_button_edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
