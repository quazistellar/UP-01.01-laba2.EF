using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Types.xaml
    /// </summary>
    public partial class Types : Page
    {

       private UP_laba_1Entities content = new UP_laba_1Entities();
        public Types()
        {
            InitializeComponent();

            gridTypes.ItemsSource = content.ShipsTypes.ToList();

            types.Visibility = Visibility.Collapsed;
            types_del.Visibility = Visibility.Collapsed;
            types_edit.Visibility = Visibility.Collapsed;
            action.Items.Add("Изменить");
            action.Items.Add("Удалить");
            action.Items.Add("Добавить");
        }

        private void types_Click(object sender, RoutedEventArgs e)
        {
            ShipsTypes ships = new ShipsTypes();
            ships.Types_Name = types_ships.Text;
            content.ShipsTypes.Add(ships);

            content.SaveChanges();

            gridTypes.ItemsSource = content.ShipsTypes.ToList();
        }

        private void types_del_Click(object sender, RoutedEventArgs e)
        {
            if (gridTypes.SelectedItem != null)
            {
                var selected = gridTypes.SelectedItem as ShipsTypes;
                types_ships.Text = selected.Types_Name;
                content.ShipsTypes.Remove(gridTypes.SelectedItem as ShipsTypes);
                content.SaveChanges();
                gridTypes.ItemsSource = content.ShipsTypes.ToList();
            }
        }

        private void types_edit_Click(object sender, RoutedEventArgs e)
        {
            if (gridTypes.SelectedItem != null)
            {
                var selected = gridTypes.SelectedItem as ShipsTypes;
                selected.Types_Name = types_ships.Text;
            
                content.SaveChanges();
                gridTypes.ItemsSource = content.ShipsTypes.ToList();
            }
        }

        private void types2_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);

            if (window != null)
            {
                window.Close();
            }
        }

        private void action_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            types_ships.Text = null;


            if (action.SelectedIndex == 2)
            {

                types_del.Visibility = Visibility.Collapsed;
                types_edit.Visibility = Visibility.Collapsed;
                types.Visibility = Visibility.Visible;
                types_ships.Visibility = Visibility.Visible;
                vvod_type.Text = "Введите название нового типа корабля ->";
            }

            if (action.SelectedIndex == 1)
            {
                types.Visibility = Visibility.Collapsed;
                types_edit.Visibility = Visibility.Collapsed;
                types_del.Visibility = Visibility.Visible;

                vvod_type.Text = "Выберите запись для удаления\nи нажмите 'Удалить'";
                types_ships.Visibility = Visibility.Collapsed;
            }

            if (action.SelectedIndex == 0)
            {

                if (gridTypes.SelectedItem != null)

                {
                    vvod_type.Text = "Выберите запись для изменения\nи измените данные";
                    types.Visibility = Visibility.Collapsed;
                    types_del.Visibility = Visibility.Collapsed;
                    types_edit.Visibility = Visibility.Visible;

                    types_ships.Visibility = Visibility.Visible;

                    if (gridTypes.SelectedItem != null)
                    {
                        var selected = gridTypes.SelectedItem as ShipsTypes;
                        types_ships.Text = selected.Types_Name;
                    }
                }

                else
                {
                    MessageBox.Show("Для изменения записи сначала\nвыберите ее, кликнув по ней");
                }
            }
        }
    }
}
