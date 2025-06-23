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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly Variant4Context db = new Variant4Context();

        public UserWindow()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            dgCars.ItemsSource = db.Cars.ToList();
        }

        private void TakeCar_Click(object sender, RoutedEventArgs e)
        {
            if (dgCars.SelectedItem is Car car)
            {
                car.State = "выдана";
                car.UserId = LoginWindow.CurrentUser.Id;
                db.SaveChanges();
                LoadCars();
            }
        }

        private void ReturnCar_Click(object sender, RoutedEventArgs e)
        {
            if (dgCars.SelectedItem is Car car && car.UserId == LoginWindow.CurrentUser.Id)
            {
                car.State = "в наличии";
                car.UserId = null;
                db.SaveChanges();
                LoadCars();
            }
        }

        private void MyCars_Click(object sender, RoutedEventArgs e)
        {
            var myCars = db.Cars.Where(c => c.UserId == LoginWindow.CurrentUser.Id).ToList();
            MessageBox.Show($"Ваши авто: {string.Join(", ", myCars.Select(c => c.Name))}");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }
        
    }
}
