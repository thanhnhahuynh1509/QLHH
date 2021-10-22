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
using DoAnQuanLyBanHangCN.Models;
using DoAnQuanLyBanHangCN.Services;

namespace DoAnQuanLyBanHangCN.Views
{
    /// <summary>
    /// Interaction logic for BillViewManager.xaml
    /// </summary>
    public partial class BillViewManager : UserControl
    {
        private HoaDonService hoaDonService = new HoaDonService();

        public BillViewManager()
        {
            InitializeComponent();
        }

        private void LoadHoaDon()
        {
            List<HoaDon> list = hoaDonService.LayTatCa().Where(p => !p.TrangThai.Equals("Chưa đặt hàng")).ToList();

            listBills.ItemsSource = list;
        }

        private void BtnTuChoi_Click(object sender, RoutedEventArgs e)
        {
            HoaDon hd = ((Button)e.OriginalSource).DataContext as HoaDon;
            hd.TrangThai = "Từ chối";
            hoaDonService.Sua(hd);
            LoadHoaDon();
        }

        private void BtnGiaoHang_Click(object sender, RoutedEventArgs e)
        {
            HoaDon hd = ((Button)e.OriginalSource).DataContext as HoaDon;
            UpdateDelivery updateDelivery = new UpdateDelivery();
            updateDelivery.Width = 400;
            updateDelivery.Height = 300;
            updateDelivery.maHoaDon = hd.MaHoaDon;
            updateDelivery.ShowDialog();
            LoadHoaDon();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadHoaDon();
        }
    }
}
