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
    /// Interaction logic for Hostel.xaml
    /// </summary>
    public partial class Hostel : Page
    {
        //Отвечает за инициализацию графического интерфейса пользователя
        public Hostel()
        {
            InitializeComponent();
            DataContext = this;
            SourceCore.MyDataBase = new DataBase.Bobrovski_4IS1_MyDataBase_HostelEntities();
            RoomsDataGrid.ItemsSource = SourceCore.MyDataBase.Rooms.ToList();
        }
    }
}
