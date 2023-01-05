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
    /// Interaction logic for Exemptions.xaml
    /// </summary>
    public partial class Exemptions : Page
    {
        private int DlgMode = -1; //Переменная отвечающая за типи обработки данных (добавить, копировать, изменить, удалить)
        private string E_buf; //Переменная для хранения названия льготы
        private int D_buf; //Переменная для хранения даты заселения в комна

        //Отвечает за инициализацию графического интерфейса пользователя
        public Exemptions()
        {
            InitializeComponent();
            DataContext = this;
            ExemptionsGrid.ItemsSource = SourceCore.MyDataBase.Exemptions.ToList();
        }

        //Отвечает за диалоговую секцию
        public void ExemptionsDlgLoad(bool b)
        {
            if (b == true)
            {
                ExemptionsColumnChange.Width = new GridLength(330);
                ExemptionsGridSplitter.Width = new GridLength(3);
                ExemptionsGrid.IsHitTestVisible = false;
            }
            else
            {
                ExemptionsColumnChange.Width = new GridLength(0);
                ExemptionsGridSplitter.Width = new GridLength(0);
                ExemptionsGrid.IsHitTestVisible = true;
                DlgMode = -1;
            }

        }

        //Отвечает за сворачивание диалоговой секции
        private void ExemptionsRollbackButton(object sender, RoutedEventArgs e)
        {
            ExemptionsDlgLoad(false);
        }

        //Отвечает за вызов диалоговой секции о добавлении данных на базе
        private void ExemptionsAddButton(object sender, RoutedEventArgs e)
        {
            ExemptionsDlgLoad(true);
            DlgMode = 0;
            ExemptionsGrid.SelectedItem = null;
            ExemptionsLabel.Content = "Добавить льготу";
            ExemptionsCommit.Content = "Добавить";
            ExemptionsName.Text = "";
            ExemptionsDiscount.Text = "";
        }

        //Отвечает за вызов диалоговой секции о копировании данных на базе
        private void ExemptionsCopyButton(object sender, RoutedEventArgs e)
        {
            if (ExemptionsGrid.SelectedItem != null)
            {
                ExemptionsDlgLoad(true);
                DlgMode = 0;
                ExemptionsLabel.Content = "Копировать льготу";
                ExemptionsCommit.Content = "Копировать";
                E_buf = ExemptionsName.Text;
                D_buf = int.Parse(ExemptionsDiscount.Text);
                ExemptionsGrid.SelectedItem = null;
                ExemptionsName.Text = E_buf;
                ExemptionsDiscount.Text = D_buf.ToString();
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }

        //Отвечает за вызов диалоговой секции об изменении данных на базе
        private void ExemptionsEditButton(object sender, RoutedEventArgs e)
        {
            if (ExemptionsGrid.SelectedItem != null)
            {
                ExemptionsDlgLoad(true);
                ExemptionsLabel.Content = "Изменить льготу";
                ExemptionsCommit.Content = "Изменить";
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }

        //Отвечает за функцию удаления записи из базы данных
        private void ExemptionsDeleteButton(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    DataBase.Exemptions DeletingExemptions = (DataBase.Exemptions)ExemptionsGrid.SelectedItem;
                    if (ExemptionsGrid.SelectedIndex < ExemptionsGrid.Items.Count - 1)
                    {
                        ExemptionsGrid.SelectedIndex++;
                    }
                    else
                    {
                        if (ExemptionsGrid.SelectedIndex > 0)
                        {
                            ExemptionsGrid.SelectedIndex--;
                        }
                    }
                    DataBase.Exemptions SelectingExemption = (DataBase.Exemptions)ExemptionsGrid.SelectedItem;
                    ExemptionsGrid.SelectedItem = DeletingExemptions;
                    SourceCore.MyDataBase.Exemptions.Remove(DeletingExemptions);
                    SourceCore.MyDataBase.SaveChanges();
                    UpdateExemptionsGrid(SelectingExemption);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных!",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                ExemptionsGrid.Focus();
            }
        }

        //Отвечает за сохранение изменений данных в базе
        private void ExemptionsCommitButton(object sender, RoutedEventArgs e)
        {
            if ((ExemptionsName.Text != "") && (ExemptionsDiscount.Text != ""))
            {
                try
                {
                    var NewExemptions = new DataBase.Exemptions();
                    NewExemptions.E_Name = ExemptionsName.Text;
                    NewExemptions.Discount = int.Parse(ExemptionsDiscount.Text);
                    if (DlgMode == 0)
                    {
                        SourceCore.MyDataBase.Exemptions.Add(NewExemptions);
                    }
                    SourceCore.MyDataBase.SaveChanges();
                    ExemptionsGrid.IsHitTestVisible = true;
                    UpdateExemptionsGrid(NewExemptions);
                    ExemptionsDlgLoad(false);
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
        private void ExemptionsPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                Columns.Add(ExemptionsGrid.Columns[i].Header.ToString());
            }
            ExemptionsFilterComboBox.ItemsSource = Columns;
            ExemptionsFilterComboBox.SelectedIndex = 0;
            foreach (DataGridColumn Column in ExemptionsGrid.Columns)
            {
                Column.CanUserSort = false;
            }
        }

        //Отвечает за фильтрацию данных в базе
        private void ExemptionsFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            switch (ExemptionsFilterComboBox.SelectedIndex)
            {
                case 0:
                    ExemptionsGrid.ItemsSource = SourceCore.MyDataBase.Exemptions.Where(t => t.E_Name.Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    {
                        List<DataBase.Exemptions> vs = new List<DataBase.Exemptions>();
                        foreach (DataBase.Exemptions c in SourceCore.MyDataBase.Exemptions)
                        {
                            if (c.Discount.Value.ToString().Contains(textbox.Text))
                            {
                                vs.Add(c);
                            }
                        }
                        ExemptionsGrid.ItemsSource = vs;
                    }
                    break;
            }
        }

        //Отвечет за обновления компонента DataGrid
        public void UpdateExemptionsGrid(DataBase.Exemptions exemptions)
        {
            if ((exemptions == null) && (ExemptionsGrid.ItemsSource != null))
            {
                exemptions = (DataBase.Exemptions)ExemptionsGrid.SelectedItem;
            }
            ExemptionsGrid.ItemsSource = SourceCore.MyDataBase.Exemptions.ToList();
            ExemptionsGrid.SelectedItem = exemptions;
        }

    }
}
