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
using DoAnQuanLyBanHangCN.Views;

namespace DoAnQuanLyBanHangCN
{
    /// <summary>
    /// Interaction logic for AdminForm.xaml
    /// </summary>
    public partial class AdminForm : Window
    {

        private Button CurrentButton = null;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnLoaiHang_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentButton != null)
            {
                CurrentButton.Style = TryFindResource("ButtonTopMenu") as Style;
            }
            CurrentButton = BtnLoaiHang;
            CurrentButton.Style = TryFindResource("ButtonTopMenuClick") as Style;
            LoaiHangView loaiHangView = new LoaiHangView();
            loaiHangView.laLoaiHang = true;
            DataContext = loaiHangView;
        }

        private void BtnHangHanHoa_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentButton != null)
            {
                CurrentButton.Style = TryFindResource("ButtonTopMenu") as Style;
            }
            CurrentButton = BtnHangHanHoa;
            CurrentButton.Style = TryFindResource("ButtonTopMenuClick") as Style;
            LoaiHangView loaiHangView = new LoaiHangView();
            loaiHangView.laLoaiHang = false;
            DataContext = loaiHangView;
        }

        private void BtnHangHoa_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentButton != null)
            {
                CurrentButton.Style = TryFindResource("ButtonTopMenu") as Style;
            }
            CurrentButton = BtnHangHoa;
            HangHoaView hangHoaView = new HangHoaView();
            hangHoaView.BtnAdd.Visibility = Visibility.Visible;
            hangHoaView.isAdmin = true;
            DataContext = hangHoaView;
            BtnHangHoa.Style = TryFindResource("ButtonTopMenuClick") as Style;
        }

        private void BtnDonDatHang_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentButton != null)
            {
                CurrentButton.Style = TryFindResource("ButtonTopMenu") as Style;
            }
            CurrentButton = BtnDonDatHang;
            CurrentButton.Style = TryFindResource("ButtonTopMenuClick") as Style;
            DataContext = new BillViewManager();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BtnHangHoa_Click(sender, e);
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Bạn có chắn chắn muốn đăng xuất?", "Thông Báo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                Close();
            }
        }
    }
}
