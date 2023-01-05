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
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private DataBase.Bobrovski_4IS1_MyDataBase_HostelEntities MyDataBase;
        bool flag; //Переменная для хранения значения о статусе скрытности пароля

        //Отвечает за инициализацию графического интерфейса пользователя
        public AuthorizationWindow()
        {
            InitializeComponent();
            flag = true; 
            try
            {
                MyDataBase = new DataBase.Bobrovski_4IS1_MyDataBase_HostelEntities();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных. Проверьте настройки подключения приложения.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
            }

        }

        //Отвечает за вход в учётныую запись пользователя
        private void AuthorizationCommit_Click(object sender, RoutedEventArgs e)
        {
            DataBase.Users User = MyDataBase.Users.SingleOrDefault(U => U.UserLogin == LoginText.Text && U.UserPassword == PasswordText.Password);
            if (User != null)
            {
                MainWindow window = new MainWindow();
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверно указан логин и/или пароль!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            };
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

        //Отвечает за вызов окна регистрации
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Registration window = new Registration(MyDataBase);
            window.ShowDialog();
        }

        //Отвечает за выход из приложения
        private void AuthorizationRollBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из программы?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                Close();
            }
        }
    }
}
