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

namespace UP_laba2_EF
{
    /// <summary>
    /// Логика взаимодействия для ShowTables3.xaml
    /// </summary>
    public partial class ShowTables3 : Window
    {
        public ShowTables3()
        {
            InitializeComponent();
            pages3.Content = new Ships();
        }
    }
}
