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
    /// Логика взаимодействия для Ships.xaml
    /// </summary>
    public partial class Ships : Page
    {
        private UP_laba_1Entities content = new UP_laba_1Entities();
        public Ships()
        {
            InitializeComponent();

            types.Visibility = Visibility.Collapsed;
            types_del.Visibility = Visibility.Collapsed;
            types_edit.Visibility = Visibility.Collapsed;
            types_ships2.Visibility = Visibility.Collapsed;
            types_ships4.Visibility = Visibility.Collapsed;

            action.Items.Add("Изменить");
            action.Items.Add("Удалить");
            action.Items.Add("Добавить");

            gridTypes.ItemsSource = content.SpaceShips.ToList();
        }

        private void types2_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);

            if (window != null)
            {
                window.Close();
            }
        }

        private void types_edit_Click(object sender, RoutedEventArgs e)
        {
            if (gridTypes.SelectedItem != null)
            {
                var selected = gridTypes.SelectedItem as SpaceShips;

                selected.NameShip = types_ships.Text;
                selected.AmountFlights = Convert.ToInt32(types_ships2.Text);
                selected.TypeShip_ID = Convert.ToInt32(types_ships4.Text);
  
                content.SaveChanges();
                gridTypes.ItemsSource = content.SpaceShips.ToList();
            }
        }

        private void types_del_Click(object sender, RoutedEventArgs e)
        {
            if (gridTypes.SelectedItem != null)
            {
                var selected = gridTypes.SelectedItem as SpaceShips;
                types_ships.Text = selected.NameShip;
                types_ships2.Text = selected.AmountFlights.ToString();
                types_ships4.Text = selected.TypeShip_ID.ToString();
                content.SpaceShips.Remove(gridTypes.SelectedItem as SpaceShips);
                content.SaveChanges();
                gridTypes.ItemsSource = content.SpaceShips.ToList();
            }
        }

        private void types_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SpaceShips ships = new SpaceShips();
                ships.NameShip = types_ships.Text;
                ships.AmountFlights = Convert.ToInt32(types_ships2.Text);
                ships.TypeShip_ID = Convert.ToInt32(types_ships4.Text);

                content.SpaceShips.Add(ships);
                content.SaveChanges();
                gridTypes.ItemsSource = content.SpaceShips.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void action_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            types_ships.Text = null;
            types_ships2.Text = null;
            types_ships4.Text = null;

            if (action.SelectedIndex == 2)
            {

                types_del.Visibility = Visibility.Collapsed;
                types_edit.Visibility = Visibility.Collapsed;
                types.Visibility = Visibility.Visible;
                types_ships.Visibility = Visibility.Visible;
                types_ships2.Visibility = Visibility.Visible;
                types_ships4.Visibility = Visibility.Visible;
                vvod_type.Text = "Введите название корабля ->";
            }

            if (action.SelectedIndex == 1)
            {
                types.Visibility = Visibility.Collapsed;
                types_edit.Visibility = Visibility.Collapsed;
                types_del.Visibility = Visibility.Visible;
                types_ships2.Visibility = Visibility.Collapsed;
                types_ships4.Visibility = Visibility.Collapsed;

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

                    types_ships.Visibility = Visibility.Visible;
                    types_ships2.Visibility = Visibility.Visible;
                    types_ships4.Visibility = Visibility.Visible;


                    if (gridTypes.SelectedItem != null)
                    {
                        var selected = gridTypes.SelectedItem as SpaceShips;
                        types_ships.Text = selected.NameShip;
                        types_ships2.Text = selected.AmountFlights.ToString();
                        types_ships4.Text = selected.TypeShip_ID.ToString();
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