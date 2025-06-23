using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly Variant4Context db = new Variant4Context();

        public AdminWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgCars.ItemsSource = db.Cars.ToList();
            dgUsers.ItemsSource = db.Users.Include(u => u.Role).ToList();
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            new AddEditCarWindow().ShowDialog();
            LoadData();
        }

        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            if (dgCars.SelectedItem is Car car)
            {
                db.Cars.Remove(car);
                db.SaveChanges();
                LoadData();
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }
    }
}
