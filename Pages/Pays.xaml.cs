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
    /// Interaction logic for Pays.xaml
    /// </summary>
    public partial class Pays : Page
    {
        private int DlgMode = -1; //Переменная отвечающая за типи обработки данных (добавить, копировать, изменить, удалить)
        private int id = -1; //Переменная для хранения id записи оплаты
        private string Student_buf; //Переменная для хранения имени студента
        private string Pay_buf; //Переменная для хранения суммы оплаты
        private string PayDate_buf; //Переменная для хранения даты оплаты

        //Отвечает за инициализацию графического интерфейса пользователя
        public Pays()
        {
            InitializeComponent();
            DataContext = this;
            PaysGrid.ItemsSource = SourceCore.MyDataBase.Pays.ToList();
            StudentsPay.ItemsSource = SourceCore.MyDataBase.Students.ToList();
        }

        //Отвечает за диалоговую секцию
        public void PaysDlgLoad(bool b)
        {
            if (b == true)
            {
                PaysColumnChange.Width = new GridLength(330);
                PaysGridSplitter.Width = new GridLength(3);
                PaysGrid.IsHitTestVisible = false;

            }
            else
            {
                PaysColumnChange.Width = new GridLength(0);
                PaysGridSplitter.Width = new GridLength(0);
                PaysGrid.IsHitTestVisible = true;
                DlgMode = -1;
            }

        }

        //Отвечает за сворачивание диалоговой секции
        private void PaysRollbackButton(object sender, RoutedEventArgs e)
        {
            PaysDlgLoad(false);
        }

        //Отвечает за вызов диалоговой секции о добавлении данных на базе
        private void PaysAddButton(object sender, RoutedEventArgs e)
        {
            PaysDlgLoad(true);
            DlgMode = 0;
            PaysGrid.SelectedItem = null;
            PaysLabel.Content = "Добавить оплату";
            PaysCommit.Content = "Добавить";
            StudentsPay.Text = "";
            Pay.Text = "";
            PayDate.Text = "";
        }

        //Отвечает за вызов диалоговой секции о копировании данных на базе
        private void PaysCopyButton(object sender, RoutedEventArgs e)
        {
            if (PaysGrid.SelectedItem != null)
            {
                PaysDlgLoad(true);
                DlgMode = 0;
                PaysLabel.Content = "Копировать оплату";
                PaysCommit.Content = "Копировать";
                Student_buf = StudentsPay.Text;
                Pay_buf = Pay.Text;
                PayDate_buf = PayDate.SelectedDate.ToString();
                PaysGrid.SelectedItem = null;
                StudentsPay.Text = Student_buf;
                Pay.Text = Pay_buf;
                PayDate.SelectedDate = Convert.ToDateTime(PayDate_buf);
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }

        //Отвечает за вызов диалоговой секции об изменении данных на базе
        private void PaysEditButton(object sender, RoutedEventArgs e)
        {
            if (PaysGrid.SelectedItem != null)
            {
                PaysDlgLoad(true);
                PaysLabel.Content = "Изменить оплату";
                PaysCommit.Content = "Изменить";
                id = (PaysGrid.SelectedItem as DataBase.Pays).ID_P;
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }
        }

        //Отвечает за функцию удаления записи из базы данных
        private void PaysDeleteButton(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    DataBase.Pays DeletingPays = (DataBase.Pays)PaysGrid.SelectedItem;
                    if (PaysGrid.SelectedIndex < PaysGrid.Items.Count - 1)
                    {
                        PaysGrid.SelectedIndex++;
                    }
                    else
                    {
                        if (PaysGrid.SelectedIndex > 0)
                        {
                            PaysGrid.SelectedIndex--;
                        }
                    }
                    DataBase.Pays SelectingPays = (DataBase.Pays)PaysGrid.SelectedItem;
                    PaysGrid.SelectedItem = DeletingPays;
                    SourceCore.MyDataBase.Pays.Remove(DeletingPays);
                    SourceCore.MyDataBase.SaveChanges();
                    UpdatePaysGrid(SelectingPays);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных!",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                PaysGrid.Focus();
            }
        }

        //Отвечает за сохранение изменений данных в базе
        private void PaysCommitButton(object sender, RoutedEventArgs e)
        {
            if (((DataBase.Students)StudentsPay.SelectedItem != null) && (Pay.Text != "") && (PayDate.Text != ""))
            {
                try
                {
                    var NewPays = new DataBase.Pays();
                    NewPays.Students = (DataBase.Students)StudentsPay.SelectedItem;
                    NewPays.Pay = Convert.ToDecimal(Pay.Text.Replace(".", ","));
                    NewPays.P_Date = Convert.ToDateTime(PayDate.Text);
                    if (DlgMode == 0)
                    {
                        SourceCore.MyDataBase.Pays.Add(NewPays);
                    }
                    else
                    {
                        foreach (var item in SourceCore.MyDataBase.Pays)
                        {
                            if (item.ID_P == id)
                            {
                                item.Students = NewPays.Students;
                                item.Pay = NewPays.Pay;
                                item.P_Date = NewPays.P_Date;
                            }
                        }
                    }
                    SourceCore.MyDataBase.SaveChanges();
                    PaysGrid.IsHitTestVisible = true;
                    UpdatePaysGrid(NewPays);
                    PaysDlgLoad(false);
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
        private void PaysPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                Columns.Add(PaysGrid.Columns[i].Header.ToString());
            }
            PaysFilterComboBox.ItemsSource = Columns;
            PaysFilterComboBox.SelectedIndex = 0;
            foreach (DataGridColumn Column in PaysGrid.Columns)
            {
                Column.CanUserSort = false;
            }
        }

        //Отвечает за фильтрацию данных в базе
        private void PaysFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            switch (PaysFilterComboBox.SelectedIndex)
            {
                case 0:
                    PaysGrid.ItemsSource = SourceCore.MyDataBase.Pays.Where(t => t.Students.F.Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    PaysGrid.ItemsSource = SourceCore.MyDataBase.Pays.Where(t => t.Students.I.Contains(textbox.Text)).ToList();
                    break;
                case 2:
                    PaysGrid.ItemsSource = SourceCore.MyDataBase.Pays.Where(t => t.Students.O.Contains(textbox.Text)).ToList();
                    break;
                case 3:
                    {
                        List<DataBase.Pays> vs = new List<DataBase.Pays>();
                        foreach (DataBase.Pays c in SourceCore.MyDataBase.Pays)
                        {
                            if (c.Pay.Value.ToString().Contains(textbox.Text))
                            {
                                vs.Add(c);
                            }
                        }
                        PaysGrid.ItemsSource = vs;
                    }
                    break;
                case 4:
                    {
                        List<DataBase.Pays> vs = new List<DataBase.Pays>();
                        foreach (DataBase.Pays c in SourceCore.MyDataBase.Pays)
                        {
                            if (c.P_Date.Value.ToShortDateString().Contains(textbox.Text))
                            {
                                vs.Add(c);
                            }
                        }
                        PaysGrid.ItemsSource = vs;
                    }
                    break;
            }
        }

        //Отвечет за обновления компонента DataGrid
        public void UpdatePaysGrid(DataBase.Pays pays)
        {
            if ((pays == null) && (PaysGrid.ItemsSource != null))
            {
                pays = (DataBase.Pays)PaysGrid.SelectedItem;
            }
            PaysGrid.ItemsSource = SourceCore.MyDataBase.Pays.ToList();
            PaysGrid.SelectedItem = pays;
        }
    }
}
