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
    /// Логика взаимодействия для Pilots.xaml
    /// </summary>
    public partial class Pilots : Page
    {
        private UP_laba_1Entities content = new UP_laba_1Entities();

        public Pilots()
        {
            InitializeComponent();


            types.Visibility = Visibility.Collapsed;
            types_del.Visibility = Visibility.Collapsed;
            types_edit.Visibility = Visibility.Collapsed;
            types_ships2.Visibility = Visibility.Collapsed;
            types_ships3.Visibility = Visibility.Collapsed;
            types_ships4.Visibility = Visibility.Collapsed;

            action.Items.Add("Изменить");
            action.Items.Add("Удалить");
            action.Items.Add("Добавить");

            gridTypes.ItemsSource = content.PilotsOfShip.ToList();
        }

        private void action_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (action.SelectedIndex == 2)
            {

                types_del.Visibility = Visibility.Collapsed;
                types_edit.Visibility = Visibility.Collapsed;
                types.Visibility = Visibility.Visible;
                types_ships.Visibility = Visibility.Visible;
                types_ships2.Visibility = Visibility.Visible;
                types_ships3.Visibility = Visibility.Visible;
                types_ships4.Visibility = Visibility.Visible;
                vvod_type.Text = "Введите имя нового пилота ->";
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

                    types_ships.Visibility = Visibility.Visible;
                    types_ships2.Visibility = Visibility.Visible;
                    types_ships3.Visibility = Visibility.Visible;
                    types_ships4.Visibility = Visibility.Visible;


                    if (gridTypes.SelectedItem != null)
                    {
                        var selected = gridTypes.SelectedItem as PilotsOfShip;
                        types_ships.Text = selected.NamePilot;
                        types_ships2.Text = selected.SurnamePilot;
                        types_ships3.Text = selected.AgePilot.ToString();
                        types_ships4.Text = selected.SpaceShip_ID.ToString();
                     
                    }
                }
                else
                {
                    MessageBox.Show("Для изменения записи сначала\nвыберите ее, кликнув по ней");
                }
            }
        
        }

        private void types_edit_Click(object sender, RoutedEventArgs e)
        {
            if (gridTypes.SelectedItem != null)
            {
                var selected = gridTypes.SelectedItem as PilotsOfShip;

                selected.NamePilot = types_ships.Text;
                selected.SurnamePilot = types_ships2.Text;
                selected.AgePilot = Convert.ToInt32(types_ships3.Text);
                selected.SpaceShip_ID = Convert.ToInt32(types_ships4.Text);

                content.SaveChanges();
                gridTypes.ItemsSource = content.PilotsOfShip.ToList();
            }
        }

        private void types_Click(object sender, RoutedEventArgs e)
        {
            PilotsOfShip pilots = new PilotsOfShip();
            pilots.NamePilot = types_ships.Text;
            pilots.SurnamePilot = types_ships2.Text;
            pilots.AgePilot = Convert.ToInt32(types_ships3.Text);
            pilots.SpaceShip_ID = Convert.ToInt32(types_ships4.Text);
            content.PilotsOfShip.Add(pilots);
            content.SaveChanges();
            gridTypes.ItemsSource = content.PilotsOfShip.ToList();
        }

        private void types_del_Click(object sender, RoutedEventArgs e)
        {
            if (gridTypes.SelectedItem != null)
            {
                var selected = gridTypes.SelectedItem as PilotsOfShip;
                types_ships.Text = selected.NamePilot;
                types_ships2.Text = selected.SurnamePilot;
                types_ships3.Text = selected.AgePilot.ToString();
                types_ships4.Text = selected.SpaceShip_ID.ToString();
                content.PilotsOfShip.Remove(gridTypes.SelectedItem as PilotsOfShip);
                content.SaveChanges();
                gridTypes.ItemsSource = content.PilotsOfShip.ToList();
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
    }
}
