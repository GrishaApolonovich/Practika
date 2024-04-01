using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void invise_Click(object sender, RoutedEventArgs e)
        {

        }

        private void voiti_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;
            var password = PasswordBox.Text;
            var context = new AppDbContext();
            var email = LoginBox.Text;
            var user = context.Users.SingleOrDefault(x => x.Login == login || x.Email == email && x.Password == password);
            


            if (user is null)
            {
                LoginBox.BorderBrush = new SolidColorBrush(Colors.Red);
                PasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Неправильное имя или пароль!");
                return;
            }



            MessageBox.Show("Вы успешно вошли в аккаунт!");
        }

        private void but_registr_Click(object sender, RoutedEventArgs e)
        {
            registor registor = new registor();
            registor.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
