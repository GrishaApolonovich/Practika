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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для registor.xaml
    /// </summary>
    public partial class registor : Window
    {
        public registor()
        {
            InitializeComponent();
        }

        private void registorBtn_Click(object sender, RoutedEventArgs e)
        {
            var email = MailBox.Text;

            var login = LoginBox.Text;

            var password = PasswordBox.Text;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exists is not null)
            {
                MessageBox.Show("Такой пользователь уже в клубе крутышей");
                return;
            }
            var user = new User { Login = login, Password = password , Email = email };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Welcome to the club, buddy");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void opo(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
