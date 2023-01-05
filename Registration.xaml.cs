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

namespace Wpf_DataBase_Hostel_App
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private DataBase.Bobrovski_4IS1_MyDataBase_HostelEntities Base;
        bool flag; //Переменная для хранения значения о статусе скрытности пароля

        //Отвечает за инициализацию графического интерфейса пользователя
        public Registration(DataBase.Bobrovski_4IS1_MyDataBase_HostelEntities Base)
        {
            InitializeComponent();
            flag = true;
            this.Base = Base;
        }

        //Отвечает за скрытие и показ пароля
        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                PasswordTextBox.Text = PasswordText.Password;
                PasswordText.Width = 0;
                PasswordTextBox.Width = 235;
                PasswordButton.Content = "Скрыть";
            }
            else
            {
                PasswordText.Password = PasswordTextBox.Text;
                PasswordText.Width = 235;
                PasswordTextBox.Width = 0;
                PasswordButton.Content = "Показать";
            }
            flag = !flag;
        }

        //Отвечает за перенос данных из PasswordBox в TextBox 
        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            PasswordText.Password = PasswordTextBox.Text;
        }

        //Отвечает за валидацию пароля
        private bool ValidPassword(string password)
        {
            if (password.Length >= 7)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if ((password[i] >= '0') && (password[i] <= '9'))
                    {
                        for (int j = 0; j < password.Length; j++)
                        {
                            if ((password[j] >= 'a') && (password[j] <= 'z'))
                            {
                                for (int k = 0; k < password.Length; k++)
                                {
                                    if ((password[k] == '-') || (password[k] == '_'))
                                    {
                                        return true;
                                    }
                                }
                                return false;
                            }
                        }
                        return false;
                    }
                }
                return false;
            }
            return false;
        }

        //Отвечает за вход в учётныую запись пользователя
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DataBase.Users UserLogin = SourceCore.MyDataBase.Users.SingleOrDefault(U => U.UserLogin == LoginText.Text);
            string password = PasswordText.Password;
            if (UserLogin == null)
            {
                if (ValidPassword(password) == true)
                {
                    DataBase.Users User = new DataBase.Users();
                    User.UserLogin = LoginText.Text;
                    User.UserPassword = PasswordText.Password != "" ? PasswordText.Password : PasswordTextBox.Text;
                    Base.Users.Add(User);
                    Base.SaveChanges();
                    Close();
                }
                else
                {
                    MessageBox.Show("Пароль неверный! Пароль должен содержать следующие символы a..z, - или _ и не быть менее 7 символов.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Пользователь с таким именем уже существует", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Отвечает за выход из окна регистрации
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
