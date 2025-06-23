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

    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            using var db = new Variant4Context();

            if (db.Users.Any(u => u.Login == txtLogin.Text))
            {
                MessageBox.Show("Логин уже занят");
                return;
            }

            var user = new User
            {
                Login = txtLogin.Text,
                Password = txtPassword.Password,
                Surname = txtSurname.Text,
                Name = txtName.Text,
                Phone = txtPhone.Text,
                RegistrationDate = DateOnly.FromDateTime(DateTime.Now),
                RoleId = 2
            };

            db.Users.Add(user);
            db.SaveChanges();

            MessageBox.Show("Регистрация успешна");
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
