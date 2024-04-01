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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UP_laba2_EF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ships_show_Click(object sender, RoutedEventArgs e)
        {
          ShowTables3 show_3 = new ShowTables3();
          show_3.ShowDialog();
        }

        private void types_show_Click(object sender, RoutedEventArgs e)
        {
            ShowTables show1 = new ShowTables();
            show1.ShowDialog();
        }

        private void pilots_show_Click(object sender, RoutedEventArgs e)
        {
            ShowTables2 show2 = new ShowTables2();
            show2.ShowDialog();
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
