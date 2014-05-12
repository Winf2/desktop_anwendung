using System;
using System.Collections;
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

            //Filterlisten initialisieren
            initializeLists();
        }

        private void initializeLists()
        {
        //Alle Datensätze (Aktivitätenname, Projektname, Mitarbeiternachname & Firmenname aus der Tabelle laden
            String[] activities = zpo.loadactivities();
            String[] projects = zpo.loadprojects();
            String[] employees = zpo.loademployees();
            String[] customers = zpo.loadcustomers();
        //Filter-Listboxen für den Tab "Zeiten" füllen
            listboxTimeActivities.ItemsSource = activities;
            listboxTimeProjects.ItemsSource = projects;
            listboxTimeEmployees.ItemsSource = employees;
            listboxTimeCustomers.ItemsSource = customers;
        //Filter-Listboxen für den Tab "Projekte" füllen
            listboxProjectsCustomers.ItemsSource = customers;
            listboxProjectsEmployees.ItemsSource = employees;
        //Filter-Listboxen für den Tab "Aktivitäten" füllen
            listboxActivitiesEmployees.ItemsSource = employees;
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
            //Test für die Spaltennamendarstellung
            /*String [] columnsWorkingTimes = {"ID","Datum","Anfang","Ende","Projekt","Aktivität","Arbeitszeit","Überstunden","Pausenanfang","Pausenende","Gesamtpause","Gesamtarbeitszeit","Status"};
            for(int i=0;i<columnsWorkingTimes.Length;i++){
                dtWorkingTime.Columns[i].ColumnName = columnsWorkingTimes[i];
            }
            */

        //Archiv
            try
            {
                TableDataWorkingTimes[] dataTableArchivWorkingTime = zpo.loadArchivTableWorkingTimes();
                DataTable dtArchivWorkingTime = ConvertToDataTable(dataTableArchivWorkingTime.ToList());
                dataGridArchivZeiten.ItemsSource = dtArchivWorkingTime.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        //Tabelle "Working_Time" laden und dem DataGrid übergeben
            TableDataWorkingTimes[] dataTableWorkingTime = zpo.loadtableworkingtimes();
            DataTable dtWorkingTime = ConvertToDataTable(dataTableWorkingTime.ToList());
            dataGridWorkingTime.ItemsSource = dtWorkingTime.DefaultView;

        //Archiv
            TableDataProjects[] dataTableArchivProjects = zpo.loadarchivtableprojects();
            DataTable dtArchivProjects = ConvertToDataTable(dataTableArchivProjects.ToList());
            dataGridArchivProjekte.ItemsSource = dtArchivProjects.DefaultView;
        //Tabelle "Projects" laden und dem DataGrid übergeben
            TableDataProjects[] dataTableProjects = zpo.loadtableprojects();
            DataTable dtProjects = ConvertToDataTable(dataTableProjects.ToList());
            dataGridProjects.ItemsSource = dtProjects.DefaultView;

        //Archiv
            TableDataActivities[] dataTableArchivActivities = zpo.loadarchivtableactivities();
            DataTable dtArchivActivities = ConvertToDataTable(dataTableArchivActivities.ToList());
            dataGridArchivAktivitaeten.ItemsSource = dtArchivActivities.DefaultView;
        //Tabelle "Activities" laden und dem DataGrid übergeben
            TableDataActivities[] dataTableActivities = zpo.loadtableactivities();
            DataTable dtActivities = ConvertToDataTable(dataTableActivities.ToList());
            dataGridActivities.ItemsSource = dtActivities.DefaultView;

        //Archiv
            TableDataCustomers[] dataTaleArchivCustomers = zpo.loadarchivtablecustomers();
            DataTable dtArchivCustomers = ConvertToDataTable(dataTaleArchivCustomers.ToList());
            dataGridArchivKunden.ItemsSource = dtArchivCustomers.DefaultView;
        //Tabelle "Customer" laden und dem DataGrid übergeben
            TableDataCustomers[] dataTableCustomers = zpo.loadtablecustomers();
            DataTable dtCustomers = ConvertToDataTable(dataTableCustomers.ToList());
            datagridCustomers.ItemsSource = dtCustomers.DefaultView;

        //Archiv
            TableDataEmployees[] dataTableArchivEmployees = zpo.loadarchivtableemployees();
            DataTable dtArchivEmployees = ConvertToDataTable(dataTableArchivEmployees.ToList());
            dataGridArchivMitarbeiter.ItemsSource = dtArchivEmployees.DefaultView;
        //Tabelle "Employees" laden und dem DataGrid übergeben
            TableDataEmployees[] dataTableEmployees = zpo.loadtableemployees(); ;
            DataTable dtEmployees = ConvertToDataTable(dataTableEmployees.ToList());
            datagridEmployees.ItemsSource = dtEmployees.DefaultView;
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
            //expander_workingTime.IsExpanded = false;
            //expander_projects.IsExpanded = false;
            //expander_activities.IsExpanded = false;
        }


        private void tool_button_refresh_Click(object sender, RoutedEventArgs e)
        {
            initializeTables();
        }

        private void tool_button_edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tool_button_archiv_Click(object sender, RoutedEventArgs e)
        {
            int tabIndex = tab_control.SelectedIndex;
            switch (tabIndex)
            {
                case (0):
                    if (dataGridWorkingTime.SelectedIndex != -1) 
                    {
                        DataRowView rowWT = (DataRowView) dataGridWorkingTime.SelectedItems[0];
                        String idWT = rowWT.Row[0].ToString();
                        zpo.archiveWorkingTime(idWT);
                    }
                    break;
                case (1):
                    if (dataGridProjects.SelectedIndex != -1)
                    {
                        DataRowView rowP = (DataRowView) dataGridProjects.SelectedItems[0];
                        String idP = rowP.Row[0].ToString();
                        zpo.archiveProjects(idP);
                    }
                    break;
                case (2):
                    if (dataGridActivities.SelectedIndex != -1)
                    {
                        DataRowView rowA = (DataRowView)dataGridActivities.SelectedItems[0];
                        String idA = rowA.Row[0].ToString();
                        zpo.archiveActivities(idA);
                    }
                    break;
                case (3):
                    if (datagridCustomers.SelectedIndex != -1)
                    {
                        DataRowView rowC = (DataRowView)datagridCustomers.SelectedItems[0];
                        String idC = rowC.Row[0].ToString();
                        zpo.archiveCustomers(idC);
                    }
                    break;
                case (4):
                    if (datagridEmployees.SelectedIndex != -1)
                    {
                        DataRowView rowE = (DataRowView)datagridEmployees.SelectedItems[0];
                        String idE = rowE.Row[0].ToString();
                        zpo.archiveEmployees(idE);
                    }                    
                    break;
                default:
                    break;
            }
            initializeTables();
        }

        private void tool_button_restore_Click(object sender, RoutedEventArgs e)
        {
            int tabIndex = tabcontrolarchiv.SelectedIndex;
            switch (tabIndex)
            {
                case (0):
                    if (dataGridArchivZeiten.SelectedIndex != -1)
                    {
                        DataRowView rowWT = (DataRowView)dataGridArchivZeiten.SelectedItems[0];
                        String idWT = rowWT.Row[0].ToString();
                        zpo.restoreWorkingTime(idWT);
                    }
                    break;
                case (1):
                    if (dataGridArchivProjekte.SelectedIndex != -1)
                    {
                        DataRowView rowP = (DataRowView)dataGridArchivProjekte.SelectedItems[0];
                        String idP = rowP.Row[0].ToString();
                        zpo.restoreProjects(idP);
                    }
                    break;
                case (2):
                    if (dataGridArchivAktivitaeten.SelectedIndex != -1)
                    {
                        DataRowView rowA = (DataRowView)dataGridArchivAktivitaeten.SelectedItems[0];
                        String idA = rowA.Row[0].ToString();
                        zpo.restoreActivities(idA);
                    }
                    break;
                case (3):
                    if (dataGridArchivKunden.SelectedIndex != -1)
                    {
                        DataRowView rowC = (DataRowView)dataGridArchivKunden.SelectedItems[0];
                        String idC = rowC.Row[0].ToString();
                        zpo.restoreCustomers(idC);
                    }
                    break;
                case (4):
                    if (dataGridArchivMitarbeiter.SelectedIndex != -1)
                    {
                        DataRowView rowE = (DataRowView)dataGridArchivMitarbeiter.SelectedItems[0];
                        String idE = rowE.Row[0].ToString();
                        zpo.restoreEmployees(idE);
                    }
                    break;
                default:
                    break;
            }
            initializeTables();
        }
    }
}
