using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        ForRegistration forRegistration = App.getforRegistration();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        bool isValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }

        int GetDifferenceInYears(DateTime startDate, DateTime endDate)
        {
            return (endDate.Year - startDate.Year - 1) +
                (((endDate.Month > startDate.Month) ||
                ((endDate.Month == startDate.Month) && (endDate.Day >= startDate.Day))) ? 1 : 0);
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginField.Text.Length > 0)
            {
                if (EmailBox.Text.Length > 0)
                {
                    if (isValid(EmailBox.Text).Equals(true))
                    {
                        if (DatePicker.Text.Length > 0)
                        {
                            if (PasswordField.Password.Length > 6)
                            {
                                bool number = false; 

                                for (int i = 0; i < PasswordField.Password.Length; i++) 
                                { 
                                    if (PasswordField.Password[i] >= '0' && PasswordField.Password[i] <= '9') number = true; 
                                }
                                if (!number)
                                    MessageBox.Show("Добавьте хотя бы одну цифру!"); 
                                else
                                {
                                    if (ConfirmPass.Password.Length > 0)
                                    {
                                        if (PasswordField.Password == ConfirmPass.Password) 
                                        {
                                            if (GetDifferenceInYears(DatePicker.SelectedDate.Value, DateTime.Today) < 18)
                                            {
                                                MessageBox.Show("Вам еще не исполнилось 18 лет!");
                                            }
                                            else if (LoginField.Text == forRegistration.Login)
                                            {
                                                MessageBox.Show("Данный логин уже существует!");
                                            }
                                            else if (EmailBox.Text == forRegistration.Email)
                                            {
                                                MessageBox.Show("Данная почта уже существует!");
                                            }
                                            else 
                                            {
                                                App.Registration_Database_Update(LoginField.Text, EmailBox.Text, DatePicker.Text, PasswordField.Password);
                                                LoginWindow loginwin = new LoginWindow();
                                                this.Close();
                                                loginwin.Show();
                                            }
                                        }
                                        else MessageBox.Show("Пароли не совпадают!");
                                    }
                                    else MessageBox.Show("Повторите пароль!");
                                }
                            }
                            else MessageBox.Show("Пароль должен быть не менее 6 символов!");
                        }
                        else MessageBox.Show("Введите дату рождения!");
                    }
                    else MessageBox.Show("Введите корректную почту!");
                }
                else MessageBox.Show("Введите почту!");
            }
            else if (LoginField.Text.Length < 6)
            {
                MessageBox.Show("Логин должен быть не менее 6 символов!"); 
            }
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginwin = new LoginWindow();
            loginwin.Show();
            this.Close();
        }
    }
}
