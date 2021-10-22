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
using DoAnQuanLyBanHangCN.Views;
using DoAnQuanLyBanHangCN.Models;
using DoAnQuanLyBanHangCN.Services;

namespace DoAnQuanLyBanHangCN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button CurrentButton = null;

        public int MaTaiKhoan { set; get; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeColorWindows(string color, string colorCorner)
        {
            BackgroundWindow.Background = new BrushConverter().ConvertFrom(color) as Brush;
            BackgroundWindowCorner.Background = new BrushConverter().ConvertFrom(colorCorner) as Brush;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(MaTaiKhoan.ToString());

        }

        private void BtnHangHoa_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentButton != null)
            {
                CurrentButton.Style = TryFindResource("ButtonTopMenu") as Style;
            }
            ChangeColorWindows("#0bbaba", "#0bbaba");
            CurrentButton = BtnHangHoa;
            HangHoaView hangHoaView = new HangHoaView();
            hangHoaView.maTaiKhoan = MaTaiKhoan;
            hangHoaView.isAdmin = false;
            DataContext = hangHoaView;
            BtnHangHoa.Style = TryFindResource("ButtonTopMenuClick") as Style;
        }

        private void BtnDichVu_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentButton != null)
            {
                CurrentButton.Style = TryFindResource("ButtonTopMenu") as Style;
            }
            ChangeColorWindows("#597b96", "#597b96");
            CurrentButton = BtnDichVu;
            DataContext = new ServiceView();
            BtnDichVu.Style = TryFindResource("ButtonTopMenuClick") as Style;
        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentButton != null)
            {
                CurrentButton.Style = TryFindResource("ButtonTopMenu") as Style;
            }
            ChangeColorWindows("#418e94", "#418e94");
            DataContext = new AboutView();
            CurrentButton = BtnAbout;
            BtnAbout.Style = TryFindResource("ButtonTopMenuClick") as Style;
        }

        private void BtnGioHang_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentButton != null)
            {
                CurrentButton.Style = TryFindResource("ButtonTopMenu") as Style;
            }
            ChangeColorWindows("#32a2bf", "#32a2bf");
            BillView billView = new BillView();
            billView.maTaiKhoan = MaTaiKhoan;
            DataContext = billView;
            CurrentButton = BtnGioHang;
            BtnGioHang.Style = TryFindResource("ButtonTopMenuClick") as Style;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BtnHangHoa_Click(null, null);
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắn chắn muốn đăng xuất?", "Thông Báo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                Close();
            }
        }

        private void BtnUser_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoanService tkService = new TaiKhoanService();
            UserView userView = new UserView();
            userView.taiKhoan = tkService.TimKiemBangMa(MaTaiKhoan);
            userView.Show();
        }
    }
}
