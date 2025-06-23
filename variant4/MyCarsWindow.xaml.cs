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
using variant4.Models;

namespace variant4
{
    /// <summary>
    /// Логика взаимодействия для MyCarsWindow.xaml
    /// </summary>
    public partial class MyCarsWindow : Window
    {
        private readonly Variant4Context _context = new Variant4Context();
        private readonly User _currentUser;

        public MyCarsWindow(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            LoadMyCars();
        }

        private void LoadMyCars()
        {
            var myCars = _context.Cars
                .Where(c => c.UserId == _currentUser.Id && c.State == "выдана")
                .ToList();

            dgMyCars.ItemsSource = myCars;
        }

        private void ReturnCar_Click(object sender, RoutedEventArgs e)
        {
            if (dgMyCars.SelectedItem is Car selectedCar)
            {
                selectedCar.State = "в наличии";
                selectedCar.UserId = null;

                _context.SaveChanges();
                LoadMyCars();
                MessageBox.Show("Автомобиль успешно возвращен", "Успех",
                              MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите автомобиль для возврата", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
