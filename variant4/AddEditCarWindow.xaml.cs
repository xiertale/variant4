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
    /// Логика взаимодействия для AddEditCarWindow.xaml
    /// </summary>
    public partial class AddEditCarWindow : Window
    {
        private readonly Variant4Context db = new Variant4Context();

        public AddEditCarWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var car = new Car
            {
                Vin = txtVin.Text,
                Name = txtName.Text,
                Type = txtType.Text,
                State = "в наличии",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now)
            };

            db.Cars.Add(car);
            db.SaveChanges();

            this.Close();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
