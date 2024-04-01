using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для ShowTables2.xaml
    /// </summary>
    public partial class ShowTables2 : Window
    {
        public ShowTables2()
        {
            InitializeComponent();

            pages2.Content = new Pilots();
        }
    }
}
