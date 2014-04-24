﻿using System;
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

namespace WpfApplication3
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Mitarbeiter", "Provider=Microsoft.JET.OLEDB.4.0;data source=E:\\neu.accdb");
            DataSet ds = new DataSet();
            da.Fill(ds, "Student");
            dataGrid1.DataContext = ds.Tables["Student"].DefaultView;
        }
    }
}
