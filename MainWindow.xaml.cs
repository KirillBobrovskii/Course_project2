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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_DataBase_Hostel_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int page = 0; //Переменная для хранения номера страницы

        //Отвечает за инициализацию графического интерфейса пользователя
        public MainWindow()
        {
            InitializeComponent();
        }

        //Отвечает за вывод страницы "студенты"
        private void StudentsButtonClick(object sender, RoutedEventArgs e)
        {
            HostelFrame.Navigate(new Pages.Students());
            page = 1;
        }

        //Отвечает за вывод страницы "льготы"
        private void ExemptionsButtonClick(object sender, RoutedEventArgs e)
        {
            HostelFrame.Navigate(new Pages.Exemptions());
            page = 2;
        }

        //Отвечает за вывод страницы "заселение/выселение"
        private void CheckInOutButtonClick(object sender, RoutedEventArgs e)
        {
            HostelFrame.Navigate(new Pages.CheckInOut());
            page = 3;
        }

        //Отвечает за вывод страницы "оплата"
        private void PaysButtonClick(object sender, RoutedEventArgs e)
        {
            HostelFrame.Navigate(new Pages.Pays());
            page = 4;
        }

        //Отвечает за вывод страницы "цены"
        private void PricesButtonClick(object sender, RoutedEventArgs e)
        {
            HostelFrame.Navigate(new Pages.Prices());
            page = 5;
        }

        //Отвечает за вывод страницы "комнаты"
        private void RoomsButtonClick(object sender, RoutedEventArgs e)
        {
            HostelFrame.Navigate(new Pages.Rooms());
            page = 6;
        }

        //Отвечает за вывод страницы "общежитие"
        private void HostelButtonClick(object sender, RoutedEventArgs e)
        {
            HostelFrame.Navigate(new Pages.Hostel());
            page = 7;
        }

        //Отвечает за вывод страницы "студент-комната"
        private void StudentsRoomsButtonClick(object sender, RoutedEventArgs e)
        {
            HostelFrame.Navigate(new Pages.Students_Rooms());
            page = 8;
        }

        //Отвечает за вывод страниц
        private void Pages()
        {
            switch (page)
            {
                case 1:
                    HostelFrame.Navigate(new Pages.Students());
                    break;
                case 2:
                    HostelFrame.Navigate(new Pages.Exemptions());
                    break;
                case 3:
                    HostelFrame.Navigate(new Pages.CheckInOut());
                    break;
                case 4:
                    HostelFrame.Navigate(new Pages.Pays());
                    break;
                case 5:
                    HostelFrame.Navigate(new Pages.Prices());
                    break;
                case 6:
                    HostelFrame.Navigate(new Pages.Rooms());
                    break;
                case 7:
                    HostelFrame.Navigate(new Pages.Hostel());
                    break;
                case 8:
                    HostelFrame.Navigate(new Pages.Students_Rooms());
                    break;
            }
        }

        //Отвечает за переход на предыдущую страницу
        private void NextPage(object sender, RoutedEventArgs e)
        {
            page++;
            Pages();
            if (page > 8)
            {
                page = 1;
                Pages();
            }
        }

        //Отвечает за переход на следующую страницу
        private void LastPage(object sender, RoutedEventArgs e)
        {
            page--;
            Pages();
            if (page < 1)
            {
                page = 8;
                Pages();
            }
        }

        //Отвечает за закрытие страницы
        private void CloseFrame(object sender, RoutedEventArgs e)
        {
            HostelFrame.Content = null;
            page = 0;
        }
    }
}