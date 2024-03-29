﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void regin_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow loginwin = new RegisterWindow();
            loginwin.Show();
            this.Close();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e) 
        {
            App.Login_Database(LoginBox.Text, PasswordField.Password);
            Close();
            MainWindow mainwin = new MainWindow();
            mainwin.Show();
        }
    }
}
