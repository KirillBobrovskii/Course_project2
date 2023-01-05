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
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Page
    {
        private int DlgMode = -1; //Переменная отвечающая за типи обработки данных (добавить, копировать, изменить, удалить)
        private string F_buf; //Переменная для хранения этажа, на котором находится комната
        private string C_buf; //Переменная для хранения количества мест в комнате

        //Отвечает за инициализацию графического интерфейса пользователя
        public Rooms()
        {
            InitializeComponent();
            DataContext = this;
            RoomsGrid.ItemsSource = SourceCore.MyDataBase.Rooms.ToList();
        }

        //Отвечает за диалоговую секцию
        public void RoomsDlgLoad(bool b)
        {
            if (b == true)
            {
                RoomsColumnChange.Width = new GridLength(330);
                RoomsGridSplitter.Width = new GridLength(3);
                RoomsGrid.IsHitTestVisible = false;

            }
            else
            {
                RoomsColumnChange.Width = new GridLength(0);
                RoomsGridSplitter.Width = new GridLength(0);
                RoomsGrid.IsHitTestVisible = true;
                DlgMode = -1;
            }

        }

        //Отвечает за сворачивание диалоговой секции
        private void RoomsRollbackButton(object sender, RoutedEventArgs e)
        {
            RoomsDlgLoad(false);
        }

        //Отвечает за вызов диалоговой секции о добавлении данных на базе
        private void RoomsAddButton(object sender, RoutedEventArgs e)
        {
            RoomsDlgLoad(true);
            DlgMode = 0;
            RoomsGrid.SelectedItem = null;
            RoomsLabel.Content = "Добавить комнату";
            RoomsCommit.Content = "Добавить";
            RoomFloor.Text = "";
            RoomsColPlace.Text = "";
        }

        //Отвечает за вызов диалоговой секции о копировании данных на базе
        private void RoomsCopyButton(object sender, RoutedEventArgs e)
        {
            if (RoomsGrid.SelectedItem != null)
            {
                RoomsDlgLoad(true);
                DlgMode = 0;
                RoomsLabel.Content = "Копировать комнату";
                RoomsCommit.Content = "Копировать";
                F_buf = RoomFloor.Text;
                C_buf = RoomsColPlace.Text;
                RoomsGrid.SelectedItem = null;
                RoomFloor.Text = F_buf;
                RoomsColPlace.Text = C_buf;
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }

        //Отвечает за вызов диалоговой секции об изменении данных на базе
        private void RoomsEditButton(object sender, RoutedEventArgs e)
        {
            if (RoomsGrid.SelectedItem != null)
            {
                RoomsDlgLoad(true);
                RoomsLabel.Content = "Изменить комнату";
                RoomsCommit.Content = "Изменить";
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }

        //Отвечает за функцию удаления записи из базы данных
        private void RoomsDeleteButton(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    DataBase.Rooms DeletingRoom = (DataBase.Rooms)RoomsGrid.SelectedItem;
                    if (RoomsGrid.SelectedIndex < RoomsGrid.Items.Count - 1)
                    {
                        RoomsGrid.SelectedIndex++;
                    }
                    else
                    {
                        if (RoomsGrid.SelectedIndex > 0)
                        {
                            RoomsGrid.SelectedIndex--;
                        }
                    }
                    DataBase.Rooms SelectingRoom = (DataBase.Rooms)RoomsGrid.SelectedItem;
                    RoomsGrid.SelectedItem = DeletingRoom;
                    SourceCore.MyDataBase.Rooms.Remove(DeletingRoom);
                    SourceCore.MyDataBase.SaveChanges();
                    UpdateRoomsGrid(SelectingRoom);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных!",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                RoomsGrid.Focus();
            }
        }

        //Отвечает за сохранение изменений данных в базе
        private void RoomsCommitButton(object sender, RoutedEventArgs e)
        {
            if ((RoomFloor.Text != "") && (RoomsColPlace.Text != ""))
            {
                try
                {
                    var NewRooms = new DataBase.Rooms();
                    NewRooms.R_Floor = int.Parse(RoomFloor.Text);
                    NewRooms.ColPlace = int.Parse(RoomsColPlace.Text);
                    if (DlgMode == 0)
                    {
                        SourceCore.MyDataBase.Rooms.Add(NewRooms);
                    }
                    SourceCore.MyDataBase.SaveChanges();
                    RoomsGrid.IsHitTestVisible = true;
                    UpdateRoomsGrid(NewRooms);
                    RoomsDlgLoad(false);
                }
                catch
                {
                    MessageBox.Show("Введены неверные данные!",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все поля данных!",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Отвечает за создание выпадающего списка для выбора типа фильтрации
        private void RoomsPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                Columns.Add(RoomsGrid.Columns[i].Header.ToString());
            }
            RoomsFilterComboBox.ItemsSource = Columns;
            RoomsFilterComboBox.SelectedIndex = 0;
            foreach (DataGridColumn Column in RoomsGrid.Columns)
            {
                Column.CanUserSort = false;
            }
        }

        //Отвечает за фильтрацию данных в базе
        private void RoomsFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            switch (RoomsFilterComboBox.SelectedIndex)
            {
                case 0:
                    RoomsGrid.ItemsSource = SourceCore.MyDataBase.Rooms.Where(t => t.ID_Room.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    RoomsGrid.ItemsSource = SourceCore.MyDataBase.Rooms.Where(t => t.R_Floor.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 2:
                    RoomsGrid.ItemsSource = SourceCore.MyDataBase.Rooms.Where(t => t.ColPlace.ToString().Contains(textbox.Text)).ToList();
                    break;
            }
        }

        //Отвечет за обновления компонента DataGrid
        public void UpdateRoomsGrid(DataBase.Rooms rooms)
        {
            if ((rooms == null) && (RoomsGrid.ItemsSource != null))
            {
                rooms = (DataBase.Rooms)RoomsGrid.SelectedItem;
            }
            RoomsGrid.ItemsSource = SourceCore.MyDataBase.Rooms.ToList();
            RoomsGrid.SelectedItem = rooms;
        }
    }
}
