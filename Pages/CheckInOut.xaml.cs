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

namespace Wpf_DataBase_Hostel_App.Pages
{
    /// <summary>
    /// Interaction logic for CheckInOut.xaml
    /// </summary>
    public partial class CheckInOut : Page
    {
        private int DlgMode = -1; //Переменная отвечающая за типи обработки данных (добавить, копировать, изменить, удалить)
        private int id = -1; //Переменная для хранения id записи заселения/выселения
        private string Student_buf; //Переменная для хранения имени студента
        private string In_buf; //Переменная для хранения даты заселения в комнату
        private string Out_buf; //Переменная для хранения даты выселения в комнату

        //Отвечает за инициализацию графического интерфейса пользователя
        public CheckInOut()
        {
            InitializeComponent();
            DataContext = this;
            CheckInOutGrid.ItemsSource = SourceCore.MyDataBase.CheckInOut.ToList();
            StudentsCheckInOut.ItemsSource = SourceCore.MyDataBase.Students.ToList();
        }

        //Отвечает за диалоговую секцию
        public void CheckInOutDlgLoad(bool b)
        {
            if (b == true)
            {
                CheckInOutColumnChange.Width = new GridLength(330);
                CheckInOutGridSplitter.Width = new GridLength(3);
                CheckInOutGrid.IsHitTestVisible = false;

            }
            else
            {
                CheckInOutColumnChange.Width = new GridLength(0);
                CheckInOutGridSplitter.Width = new GridLength(0);
                CheckInOutGrid.IsHitTestVisible = true;
                DlgMode = -1;
            }

        }

        //Отвечает за сворачивание диалоговой секции 
        private void CheckInOutRollbackButton(object sender, RoutedEventArgs e)
        {
            CheckInOutDlgLoad(false);
        }

        //Отвечает за вызов диалоговой секции о добавлении данных на базе
        private void CheckInOutAddButton(object sender, RoutedEventArgs e)
        {
            CheckInOutDlgLoad(true);
            DlgMode = 0;
            CheckInOutGrid.SelectedItem = null;
            CheckInOutLabel.Content = "Добавить запись";
            CheckInOutCommit.Content = "Добавить запись";
            StudentsCheckInOut.Text = "";
            CheckIn.Text = "";
            CheckOut.Text = "";
        }

        //Отвечает за вызов диалоговой секции о копировании данных на базе
        private void CheckInOutCopyButton(object sender, RoutedEventArgs e)
        {
            if (CheckInOutGrid.SelectedItem != null)
            {
                CheckInOutDlgLoad(true);
                DlgMode = 0;
                CheckInOutLabel.Content = "Копировать запись";
                CheckInOutCommit.Content = "Копировать запись";
                Student_buf = StudentsCheckInOut.Text;
                In_buf = CheckIn.SelectedDate.ToString();
                Out_buf = CheckOut.SelectedDate.ToString();
                CheckInOutGrid.SelectedItem = null;
                StudentsCheckInOut.Text = Student_buf;
                CheckIn.SelectedDate = Convert.ToDateTime(In_buf);
                CheckOut.SelectedDate = Convert.ToDateTime(Out_buf);
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }

        //Отвечает за вызов диалоговой секции об изменении данных на базе
        private void CheckInOutEditButton(object sender, RoutedEventArgs e)
        {
            if (CheckInOutGrid.SelectedItem != null)
            {
                CheckInOutDlgLoad(true);
                CheckInOutLabel.Content = "Изменить запись";
                CheckInOutCommit.Content = "Изменить запись";
                id = (CheckInOutGrid.SelectedItem as DataBase.CheckInOut).ID_Ch;
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }

        //Отвечает за функцию удаления записи из базы данных
        private void CheckInOutDeleteButton(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    DataBase.CheckInOut DeletingCheckInOut = (DataBase.CheckInOut)CheckInOutGrid.SelectedItem;
                    if (CheckInOutGrid.SelectedIndex < CheckInOutGrid.Items.Count - 1)
                    {
                        CheckInOutGrid.SelectedIndex++;
                    }
                    else
                    {
                        if (CheckInOutGrid.SelectedIndex > 0)
                        {
                            CheckInOutGrid.SelectedIndex--;
                        }
                    }
                    DataBase.CheckInOut SelectingCheckInOut = (DataBase.CheckInOut)CheckInOutGrid.SelectedItem;
                    CheckInOutGrid.SelectedItem = DeletingCheckInOut;
                    SourceCore.MyDataBase.CheckInOut.Remove(DeletingCheckInOut);
                    SourceCore.MyDataBase.SaveChanges();
                    UpdateCheckInOutGrid(SelectingCheckInOut);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных!",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                CheckInOutGrid.Focus();
            }
        }

        //Отвечает за сохранение изменений данных в базе
        private void CheckInOutCommitButton(object sender, RoutedEventArgs e)
        {
            if (((DataBase.Students)StudentsCheckInOut.SelectedItem != null) && (CheckIn.Text != "") && (CheckOut.Text != ""))
            {
                var NewCheckInOut = new DataBase.CheckInOut();
                NewCheckInOut.Students = (DataBase.Students)StudentsCheckInOut.SelectedItem;
                NewCheckInOut.Date_In = CheckIn.SelectedDate;
                NewCheckInOut.Date_Out = CheckOut.SelectedDate;
                if (DlgMode == 0)
                {
                    SourceCore.MyDataBase.CheckInOut.Add(NewCheckInOut);
                }
                else
                {
                    foreach (var item in SourceCore.MyDataBase.CheckInOut)
                    {
                        if (item.ID_Ch == id)
                        {
                            item.Students = NewCheckInOut.Students;
                            item.Date_In = NewCheckInOut.Date_In;
                            item.Date_Out = NewCheckInOut.Date_Out;
                        }
                    }
                }
                SourceCore.MyDataBase.SaveChanges();
                CheckInOutGrid.IsHitTestVisible = true;
                UpdateCheckInOutGrid(NewCheckInOut);
                CheckInOutDlgLoad(false);
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все поля данных!",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Отвечает за создание выпадающего списка для выбора типа фильтрации
        private void CheckInOutPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                Columns.Add(CheckInOutGrid.Columns[i].Header.ToString());
            }
            CheckInOutFilterComboBox.ItemsSource = Columns;
            CheckInOutFilterComboBox.SelectedIndex = 0;
            foreach (DataGridColumn Column in CheckInOutGrid.Columns)
            {
                Column.CanUserSort = false;
            }
        }

        //Отвечает за фильтрацию данных в базе
        private void CheckInOutFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            switch (CheckInOutFilterComboBox.SelectedIndex)
            {
                case 0:
                    CheckInOutGrid.ItemsSource = SourceCore.MyDataBase.CheckInOut.Where(t => t.Students.F.Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    CheckInOutGrid.ItemsSource = SourceCore.MyDataBase.CheckInOut.Where(t => t.Students.I.Contains(textbox.Text)).ToList();
                    break;
                case 2:
                    CheckInOutGrid.ItemsSource = SourceCore.MyDataBase.CheckInOut.Where(t => t.Students.O.Contains(textbox.Text)).ToList();
                    break;
                case 3:
                    {
                        List<DataBase.CheckInOut> vs = new List<DataBase.CheckInOut>();
                        foreach (DataBase.CheckInOut c in SourceCore.MyDataBase.CheckInOut)
                        {
                            if (c.Date_In.Value.ToShortDateString().Contains(textbox.Text))
                            {
                                vs.Add(c);
                            }
                        }
                        CheckInOutGrid.ItemsSource = vs;
                    }
                    break;
                case 4:
                    {
                        List<DataBase.CheckInOut> vs = new List<DataBase.CheckInOut>();
                        foreach (DataBase.CheckInOut c in SourceCore.MyDataBase.CheckInOut)
                        {
                            if (c.Date_Out.Value.ToShortDateString().Contains(textbox.Text))
                            {
                                vs.Add(c);
                            }
                        }
                        CheckInOutGrid.ItemsSource = vs;
                    }
                    break;
            }
        }

        //Отвечет за обновления компонента DataGrid
        public void UpdateCheckInOutGrid(DataBase.CheckInOut checkInOut)
        {
            if ((checkInOut == null) && (CheckInOutGrid.ItemsSource != null))
            {
                checkInOut = (DataBase.CheckInOut)CheckInOutGrid.SelectedItem;
            }
            CheckInOutGrid.ItemsSource = SourceCore.MyDataBase.CheckInOut.ToList();
            CheckInOutGrid.SelectedItem = checkInOut;
        }
    }
}
