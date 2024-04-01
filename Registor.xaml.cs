using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
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

            var proverPassword = PasswordPBox.Text;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);

            if(email.Length == 0)
            {
                MailBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Напишите свою почту");
                return;
            }
            else if (!Regex.IsMatch(email, @"[@]"))
            {
                MailBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Почта должна содержать специальный знаки - @ и .");
                return;
            }
            else if (!Regex.IsMatch(email, @"[.]"))
            {
                MailBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Почта должна содержать специальный знаки - @ и .");
                return;
            }

            if (login.Length == 0)
            {
                LoginBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Напишите свой логин");
                return;
            }


            if(password.Length == 0)
            {
                PasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Напишите свой пароль");
                return;
            }
            else if (password.Length < 3)
            {
                PasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Пароль должен быть длинее 3х символов ");
                return;
            }
            else if(!Regex.IsMatch(password, @"[@#$]"))
            {
                PasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Пароль должен содержать хоть один специальный символ");
                return;
            }

            if (proverPassword.Length == 0)
            {
                PasswordPBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Напишите повторно пароль");
                return;
            }

            if (proverPassword != password)
            {
                PasswordPBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Пароль не сходиться");
                return;
            }


            
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
