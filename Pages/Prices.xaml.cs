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
    /// Interaction logic for Prices.xaml
    /// </summary>
    public partial class Prices : Page
    {
        private int DlgMode = -1; //Переменная отвечающая за типи обработки данных (добавить, копировать, изменить, удалить)
        private int id = -1; //Переменная для хранения id записи цены
        private string Price_buf; //Переменная для хранение цена за проживание в комнате
        private string Date_buf; //Переменная для хранение даты установления цены за проживание

        //Отвечает за инициализацию графического интерфейса пользователя
        public Prices()
        {
            InitializeComponent();
            DataContext = this;
            PricesGrid.ItemsSource = SourceCore.MyDataBase.Prices.ToList();
        }

        //Отвечает за диалоговую секцию
        public void PricesDlgLoad(bool b)
        {
            if (b == true)
            {
                PricesColumnChange.Width = new GridLength(330);
                PricesGridSplitter.Width = new GridLength(3);
                PricesGrid.IsHitTestVisible = false;

            }
            else
            {
                PricesColumnChange.Width = new GridLength(0);
                PricesGridSplitter.Width = new GridLength(0);
                PricesGrid.IsHitTestVisible = true;
                DlgMode = -1;
            }

        }

        //Отвечает за сворачивание диалоговой секции
        private void PricesRollbackButton(object sender, RoutedEventArgs e)
        {
            PricesDlgLoad(false);
        }

        //Отвечает за вызов диалоговой секции о добавлении данных на базе
        private void PricesAddButton(object sender, RoutedEventArgs e)
        {
            PricesDlgLoad(true);
            DlgMode = 0;
            PricesGrid.SelectedItem = null;
            PricesLabel.Content = "Добавить цену";
            PricesCommit.Content = "Добавить";
            PriceSum.Text = "";
            PriceDate.Text = "";
        }

        //Отвечает за вызов диалоговой секции о копировании данных на базе
        private void PricesCopyButton(object sender, RoutedEventArgs e)
        {
            if (PricesGrid.SelectedItem != null)
            {
                PricesDlgLoad(true);
                DlgMode = 0;
                PricesLabel.Content = "Копировать цену";
                PricesCommit.Content = "Копировать";
                Price_buf = PriceSum.Text;
                Date_buf = PriceDate.SelectedDate.ToString();
                PricesGrid.SelectedItem = null;
                PriceSum.Text = Price_buf;
                PriceDate.SelectedDate = Convert.ToDateTime(Date_buf);
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }

        //Отвечает за вызов диалоговой секции об изменении данных на базе
        private void PricesEditButton(object sender, RoutedEventArgs e)
        {
            if (PricesGrid.SelectedItem != null)
            {
                PricesDlgLoad(true);
                PricesLabel.Content = "Изменить цену";
                PricesCommit.Content = "Изменить";
                id = (PricesGrid.SelectedItem as DataBase.Prices).ID_Price;
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }

        //Отвечает за функцию удаления записи из базы данных
        private void PricesDeleteButton(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    DataBase.Prices DeletingPrice = (DataBase.Prices)PricesGrid.SelectedItem;
                    if (PricesGrid.SelectedIndex < PricesGrid.Items.Count - 1)
                    {
                        PricesGrid.SelectedIndex++;
                    }
                    else
                    {
                        if (PricesGrid.SelectedIndex > 0)
                        {
                            PricesGrid.SelectedIndex--;
                        }
                    }
                    DataBase.Prices SelectingPrice = (DataBase.Prices)PricesGrid.SelectedItem;
                    PricesGrid.SelectedItem = DeletingPrice;
                    SourceCore.MyDataBase.Prices.Remove(DeletingPrice);
                    SourceCore.MyDataBase.SaveChanges();
                    UpdatePricesGrid(SelectingPrice);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных!",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                PricesGrid.Focus();
            }
        }

        //Отвечает за сохранение изменений данных в базе
        private void PricesCommitButton(object sender, RoutedEventArgs e)
        {
            if ((PriceSum.Text != "") && (PriceDate.Text != ""))
            {
                try
                {
                    var NewPrices = new DataBase.Prices();
                    NewPrices.Pr_Sum = Convert.ToDecimal(PriceSum.Text.Replace(".", ","));
                    NewPrices.Pr_Date = DateTime.Parse(PriceDate.Text);
                    if (DlgMode == 0)
                    {
                        SourceCore.MyDataBase.Prices.Add(NewPrices);
                    }
                    else
                    {
                        foreach (var item in SourceCore.MyDataBase.Prices)
                        {
                            if (item.ID_Price == id)
                            {
                                item.Pr_Sum = NewPrices.Pr_Sum;
                                item.Pr_Date = NewPrices.Pr_Date;
                            }
                        }
                    }
                    SourceCore.MyDataBase.SaveChanges();
                    PricesGrid.IsHitTestVisible = true;
                    UpdatePricesGrid(NewPrices);
                    PricesDlgLoad(false);
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
        private void PricesPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                Columns.Add(PricesGrid.Columns[i].Header.ToString());
            }
            PricesFilterComboBox.ItemsSource = Columns;
            PricesFilterComboBox.SelectedIndex = 0;
            foreach (DataGridColumn Column in PricesGrid.Columns)
            {
                Column.CanUserSort = false;
            }
        }

        //Отвечает за фильтрацию данных в базе
        private void PricesFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            switch (PricesFilterComboBox.SelectedIndex)
            {
                case 0:
                    {
                        List<DataBase.Prices> vs = new List<DataBase.Prices>();
                        foreach (DataBase.Prices c in SourceCore.MyDataBase.Prices)
                        {
                            if (c.Pr_Sum.Value.ToString().Contains(textbox.Text))
                            {
                                vs.Add(c);
                            }
                        }
                        PricesGrid.ItemsSource = vs;
                    }
                    break;
                case 1:
                    {
                        List<DataBase.Prices> vs = new List<DataBase.Prices>();
                        foreach (DataBase.Prices c in SourceCore.MyDataBase.Prices)
                        {
                            if (c.Pr_Date.Value.ToShortDateString().Contains(textbox.Text))
                            {
                                vs.Add(c);
                            }
                        }
                        PricesGrid.ItemsSource = vs;
                    }
                    break;
            }
        }

        //Отвечет за обновления компонента DataGrid
        public void UpdatePricesGrid(DataBase.Prices prices)
        {
            if ((prices == null) && (PricesGrid.ItemsSource != null))
            {
                prices = (DataBase.Prices)PricesGrid.SelectedItem;
            }
            PricesGrid.ItemsSource = SourceCore.MyDataBase.Prices.ToList();
            PricesGrid.SelectedItem = prices;
        }
    }
}
