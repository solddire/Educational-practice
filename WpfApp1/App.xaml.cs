using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ForRegistration forRegistration = new ForRegistration();
        public static MySqlConnection mysql_connection;


        public static MySqlConnection GetConnection()
        {
            return mysql_connection;
        }


        public static ForRegistration getforRegistration()
        {
            return forRegistration;
        }



        public static bool Connect()
        {
            string Connect = "Database=" + "mydb" + ";Datasource=" + "localhost" + ";User=" + "root" + ";Password=" + "new_password";

            try
            {
                mysql_connection = new MySqlConnection(Connect);
                MySqlCommand mysql_query = mysql_connection.CreateCommand();
                mysql_connection.Open();
                mysql_query.CommandText = " SELECT * FROM table1;";
                MySqlDataReader mysql_result;
                mysql_result = mysql_query.ExecuteReader();
                while (mysql_result.Read()) // построчно считываем данные
                {
                    object id = mysql_result.GetValue(0);
                    object name = mysql_result.GetValue(1);
                    object age = mysql_result.GetValue(2);
                }
                mysql_connection.Close();
            }
            catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show("Отсутствует подключение к базе данных", "БД", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                }
                return false;
            }
            return true;
        }



        public void Registration_Database_Select()
        {

            
            string Connect = "Database=" + "mydb" + ";Datasource=" + "localhost" + ";User=" + "root" + ";Password=" + "new_password";
            try
            {
                mysql_connection = new MySqlConnection(Connect);
                MySqlCommand mysql_query = mysql_connection.CreateCommand();
                mysql_connection.Open();
                mysql_query.CommandText = " SELECT * FROM table3;";
                MySqlDataReader mysql_result;
                mysql_result = mysql_query.ExecuteReader();
                while (mysql_result.Read()) // построчно считываем данные
                {
                    string email = mysql_result.GetString(2);
                    string login = mysql_result.GetString(1);

                    forRegistration.Email = email;
                    forRegistration.Login = login;
                }
                mysql_connection.Close();
            }
            catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show("Отсутствует подключение к базе данных", "БД", MessageBoxButton.OK);
            }
        }


        public static void Registration_Database_Update(string Login,string Email,string Birthday,string Password)
        {
            string Connect = "Database=" + "mydb" + ";Datasource=" + "localhost" + ";User=" + "root" + ";Password=" + "new_password";
            try
            {
                mysql_connection = new MySqlConnection(Connect);
                MySqlCommand mysql_query = mysql_connection.CreateCommand();
                mysql_connection.Open();
                mysql_query.CommandText = String.Format(" INSERT INTO `table3`(`Login`, `Email`, `Birthday`, `Password`) VALUES ('{0}','{1}','{2}','{3}');", Login,Email,Birthday,Password);
                MySqlDataReader mysql_result;
                mysql_result = mysql_query.ExecuteReader();
                mysql_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.ToString());
            }
        }


        public static void Login_Database(string Login,string Password) 
        {
            MainWindow window = new MainWindow();
            string Connect = "Database=" + "mydb" + ";Datasource=" + "localhost" + ";User=" + "root" + ";Password=" + "new_password";
            try
            {
                mysql_connection = new MySqlConnection(Connect);
                MySqlCommand mysql_query = mysql_connection.CreateCommand();
                mysql_connection.Open();
                mysql_query.CommandText = String.Format(" SELECT * FROM `table3` WHERE Login = '{0}' AND Password = '{1}';", Login, Password);
                MySqlDataReader mysql_result;
                mysql_result = mysql_query.ExecuteReader();
                while (mysql_result.Read())
                {
                    if (Login == mysql_result.GetString(1) && Password == mysql_result.GetString(4))
                    {
                        window.Show();
                    }
                    if (Login != mysql_result.GetString(1) || Password != mysql_result.GetString(4)) 
                    {
                        MessageBox.Show("Вы ввели некорректные данные!");
                    }
                }
                mysql_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.ToString());
            }
        }



        public App()
        {
            Connect();
            Registration_Database_Select();
        }
    }
}
