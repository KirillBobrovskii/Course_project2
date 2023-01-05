using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Wpf_DataBase_Hostel_App.Pages
{
    /// <summary>
    /// Interaction logic for Students_Rooms.xaml
    /// </summary>
    public partial class Students_Rooms : Page
    {
        int flag; //Переменная отвечает за хранения типа обработки данных(заселение, выселение студента из комнаты)

        //Отвечает за инициализацию графического интерфейса пользователя
        public Students_Rooms()
        {
            InitializeComponent();
            DataContext = this;
            RoomColumn.Visibility = Visibility.Hidden;
        }

        //Отвечает за обновление DataGrid
        private void UpDateDataGrid()
        {
            StudentsDataGrid.ItemsSource = SourceCore.MyDataBase.Database.SqlQuery<Stud>("select ID_Stud, F, I, O from students where ID_Room is Null ").ToList();
            RoomsDataGrid.ItemsSource = SourceCore.MyDataBase.Database.SqlQuery<Rm>("select r.ID_Room, r.R_Floor, r.ColPlace " +
                "from Rooms r " +
                "inner join Students s on (s.ID_Room = r.ID_Room) " +
                "group by r.ID_Room, r.R_Floor, r.ColPlace " +
                "having(count(s.ID_Stud) < r.ColPlace) " +
                "union " +
                "select r.ID_Room, r.R_Floor, r.ColPlace " +
                "from Rooms r " +
                "left join Students s on (s.ID_Room = r.ID_Room) " +
                "where(s.ID_Room is Null) ").ToList();
        }
        

        //Отвечает за секцию заселения студента в комнату
        private void CheckInStudentButtonClick(object sender, RoutedEventArgs e)
        {
            CommitButton.Visibility = Visibility.Visible;
            RoomColumn.Visibility = Visibility.Hidden;
            RoomsColumn.Width = new GridLength(400);
            GridSplitter.HorizontalAlignment = HorizontalAlignment.Stretch;
            CommitButton.Content = "Заселить";
            flag = 0;
            UpDateDataGrid();
        }

        //Отвечает за секцию выселения студента из комнаты
        private void ChechOutStudentsButtonClick(object sender, RoutedEventArgs e)
        {
            CommitButton.Visibility = Visibility.Visible;
            RoomColumn.Visibility = Visibility.Visible;
            RoomsColumn.Width = new GridLength(0);
            GridSplitter.HorizontalAlignment = HorizontalAlignment.Right;
            CommitButton.Content = "Выселить";
            flag = 1;
            StudentsDataGrid.ItemsSource = SourceCore.MyDataBase.Database.SqlQuery<Stud>("select ID_Stud, F, I, O, ID_Room from students where ID_Room is not Null ").ToList();
        }

        //Отвечает за внесение изменений в данные на базе
        private void CommitButtonClick(object sender, RoutedEventArgs e)
        {
            switch (flag)
            {
                case 0:
                {
                    if ((StudentsDataGrid.SelectedItem != null) && (RoomsDataGrid.SelectedItem != null))
                        {
                        var St_ID = ((Stud)StudentsDataGrid.SelectedItem).ID_Stud;
                        var Rm_ID = ((Rm)RoomsDataGrid.SelectedItem).ID_Room;
                        SourceCore.MyDataBase.Database.ExecuteSqlCommand($"update Students set ID_Room = {Rm_ID} where(ID_Stud = {St_ID}) ");
                        UpDateDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Необходимо выбрать строку студента и строку комнаты!", "Сообщение", MessageBoxButton.OK);
                    }
                }
                break;
                case 1:
                {
                    if (StudentsDataGrid.SelectedItem != null)
                    {
                        var St_ID = ((Stud)StudentsDataGrid.SelectedItem).ID_Stud;
                        SourceCore.MyDataBase.Database.ExecuteSqlCommand($"update Students set ID_Room = Null where(ID_Stud = {St_ID}) ");
                        StudentsDataGrid.ItemsSource = SourceCore.MyDataBase.Database.SqlQuery<Stud>("select ID_Stud, F, I, O, ID_Room from students where ID_Room is not Null ").ToList();
                    }
                    else
                    {
                        MessageBox.Show("Необходимо выбрать строку студента!", "Сообщение", MessageBoxButton.OK);
                    }                
                }
                break;
            }
        }
    }
}
