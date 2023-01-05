using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : Page
    {
        private int DlgMode = -1; //Переменная отвечающая за типи обработки данных (добавить, копировать, изменить, удалить)
        private int id = -1; //Переменная для хранения id студента
        private string F_buf; //Переменная для хранения фамилии студента
        private string I_buf; //Переменная для хранения имени студента
        private string O_buf; //Переменная для хранения отчества студента
        private string BirthDay_buf; //Переменная для хранения даты рождения студента
        private string PassInfo_buf; //Переменная для хранения паспортных данных студента
        private string Exemption_buf; //Переменная для хранения информации о льготе студента

        //Отвечает за инициализацию графического интерфейса пользователя
        public Students()
        {
            InitializeComponent();
            DataContext = this;
            StudentsGrid.ItemsSource = SourceCore.MyDataBase.Students.ToList();
            StudentsExemption.ItemsSource = SourceCore.MyDataBase.Exemptions.ToList();
        }

        //Отвечает за диалоговую секцию
        private void StudentsDlgLoad(bool b)
        {
            if (b == true)
            {
                StudentsColumnChange.Width = new GridLength(330);
                StudentsGridSplitter.Width = new GridLength(3);
                StudentsGrid.IsHitTestVisible = false;

            }
            else
            {
                StudentsColumnChange.Width = new GridLength(0);
                StudentsGridSplitter.Width = new GridLength(0);
                StudentsGrid.IsHitTestVisible = true;
                DlgMode = -1;
            }

        }

        //Отвечает за сворачивание диалоговой секции
        private void StudentsRollbackButton(object sender, RoutedEventArgs e)
        {
            StudentsDlgLoad(false);
        }

        //Отвечает за вызов диалоговой секции о добавлении данных на базе
        private void StudentsAddButton(object sender, RoutedEventArgs e)
        {
            StudentsDlgLoad(true);
            DlgMode = 0;
            StudentsGrid.SelectedItem = null;
            StudentsLabel.Content = "Добавить студента";
            StudentsCommit.Content = "Добавить";
            StudentsF.Text = "";
            StudentsI.Text = "";
            StudentsO.Text = "";
            StudentsBirthDay.SelectedDate = null;
            StudentsPassInfo.Text = "";
            StudentsExemption.Text = "";
        }

        //Отвечает за вызов диалоговой секции о копировании данных на базе
        private void StudentsCopyButton(object sender, RoutedEventArgs e)
        {
            if (StudentsGrid.SelectedItem != null)
            {
                StudentsDlgLoad(true);
                DlgMode = 0;
                StudentsLabel.Content = "Копировать студента";
                StudentsCommit.Content = "Копировать";
                F_buf = StudentsF.Text;
                I_buf = StudentsI.Text;
                O_buf = StudentsO.Text;
                BirthDay_buf = StudentsBirthDay.SelectedDate.ToString();
                PassInfo_buf = StudentsPassInfo.Text;
                Exemption_buf = StudentsExemption.Text;
                StudentsGrid.SelectedItem = null;
                StudentsF.Text = F_buf;
                StudentsI.Text = I_buf;
                StudentsO.Text = O_buf;
                StudentsBirthDay.SelectedDate = Convert.ToDateTime(BirthDay_buf);
                StudentsPassInfo.Text = PassInfo_buf;
                StudentsExemption.Text = Exemption_buf;
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }

        //Отвечает за вызов диалоговой секции об изменении данных на базе
        private void StudentsEditButton(object sender, RoutedEventArgs e)
        {
            if (StudentsGrid.SelectedItem != null)
            {
                StudentsDlgLoad(true);
                StudentsLabel.Content = "Изменить студента";
                StudentsCommit.Content = "Изменить";
                id = (StudentsGrid.SelectedItem as DataBase.Students).ID_Stud;
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }

        }

        //Отвечает за функцию удаления записи из базы данных
        private void StudentsDeleteButton(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    DataBase.Students DeletingStudent = (DataBase.Students)StudentsGrid.SelectedItem;
                    if (StudentsGrid.SelectedIndex < StudentsGrid.Items.Count - 1)
                    {
                        StudentsGrid.SelectedIndex++;
                    }
                    else
                    {
                        if (StudentsGrid.SelectedIndex > 0)
                        {
                            StudentsGrid.SelectedIndex--;
                        }
                    }
                    DataBase.Students SelectingStudent = (DataBase.Students)StudentsGrid.SelectedItem;
                    StudentsGrid.SelectedItem = DeletingStudent;
                    SourceCore.MyDataBase.Students.Remove(DeletingStudent);
                    SourceCore.MyDataBase.SaveChanges();
                    UpdateStudentsGrid(SelectingStudent);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных!",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                StudentsGrid.Focus();
            }
        }

        //Отвечает за сохранение изменений данных в базе
        private void StudentsCommitButton(object sender, RoutedEventArgs e)
        {
            if ((StudentsF.Text != "") && (StudentsI.Text != "") && (StudentsO.Text != "") && (StudentsBirthDay.Text != "") && (StudentsPassInfo.Text != "") && ((DataBase.Exemptions)StudentsExemption.SelectedItem != null))
            {
                if (StudentsPassInfo.Text.Length == 10)
                {
                    var NewStudents = new DataBase.Students();
                    NewStudents.F = StudentsF.Text;
                    NewStudents.I = StudentsI.Text;
                    NewStudents.O = StudentsO.Text;
                    NewStudents.BirthDay = StudentsBirthDay.SelectedDate;
                    NewStudents.PassInfo = StudentsPassInfo.Text;
                    NewStudents.Exemptions = (DataBase.Exemptions)StudentsExemption.SelectedItem;
                    if (DlgMode == 0)
                    {
                        SourceCore.MyDataBase.Students.Add(NewStudents);
                    }
                    else
                    {
                        foreach (var item in SourceCore.MyDataBase.Students)
                        {
                            if (item.ID_Stud == id)
                            {
                                item.F = NewStudents.F;
                                item.I = NewStudents.I;
                                item.O = NewStudents.O;
                                item.BirthDay = NewStudents.BirthDay;
                                item.PassInfo = NewStudents.PassInfo;
                                item.Exemptions = NewStudents.Exemptions;
                            }
                        }
                    }
                    SourceCore.MyDataBase.SaveChanges();
                    StudentsGrid.IsHitTestVisible = true;
                    UpdateStudentsGrid(NewStudents);
                    StudentsDlgLoad(false);
                }
                else
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
        private void StudentsPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                Columns.Add(StudentsGrid.Columns[i].Header.ToString());
            }
            StudentsFilterComboBox.ItemsSource = Columns;
            StudentsFilterComboBox.SelectedIndex = 0;
            foreach (DataGridColumn Column in StudentsGrid.Columns)
            {
                Column.CanUserSort = false;
            }
        }

        //Отвечает за фильтрацию данных в базе
        private void StudentsFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            switch (StudentsFilterComboBox.SelectedIndex)
            {
                case 0:
                    StudentsGrid.ItemsSource = SourceCore.MyDataBase.Students.Where(t => t.F.Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    StudentsGrid.ItemsSource = SourceCore.MyDataBase.Students.Where(t => t.I.Contains(textbox.Text)).ToList();
                    break;
                case 2:
                    StudentsGrid.ItemsSource = SourceCore.MyDataBase.Students.Where(t => t.O.Contains(textbox.Text)).ToList();
                    break;
                case 3:
                    {
                        List<DataBase.Students> vs = new List<DataBase.Students>();
                        foreach (DataBase.Students c in SourceCore.MyDataBase.Students)
                        {
                            if (c.BirthDay.Value.ToShortDateString().Contains(textbox.Text))
                            {
                                vs.Add(c);
                            }
                        }
                        StudentsGrid.ItemsSource = vs;
                    }
                    break;
                case 4:
                    StudentsGrid.ItemsSource = SourceCore.MyDataBase.Students.Where(t => t.PassInfo.Contains(textbox.Text)).ToList();
                    break;
                case 5:
                    StudentsGrid.ItemsSource = SourceCore.MyDataBase.Students.Where(t => t.Exemptions.E_Name.Contains(textbox.Text)).ToList();
                    break;
            }
        }

        //Отвечет за обновления компонента DataGrid
        private void UpdateStudentsGrid(DataBase.Students students)
        {
            if ((students == null) && (StudentsGrid.ItemsSource != null))
            {
                students = (DataBase.Students)StudentsGrid.SelectedItem;
            }
            StudentsGrid.ItemsSource = SourceCore.MyDataBase.Students.ToList();
            StudentsGrid.SelectedItem = students;
        }
    }
}