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
    /// Interaction logic for BillView.xaml
    /// </summary>
    public partial class BillView : UserControl
    {
        public int maTaiKhoan;
        private HoaDonService hoaDonService = new HoaDonService();
        private List<HoaDon> listHoaDon;

        public BillView()
        {
            InitializeComponent();
             
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listHoaDon = hoaDonService.TimKiemBangMaTaiKhoan(maTaiKhoan);
            listBills.ItemsSource = listHoaDon;
        }

        private void BtnDatHang_Click(object sender, RoutedEventArgs e)
        {
            HoaDon hoaDon = ((Button)e.OriginalSource).DataContext as HoaDon;

            if(hoaDon.TrangThai.Equals("Đặt hàng"))
            {
                MessageBox.Show("Hóa đơn đã được đặt!");
                return;
            }
            if (hoaDon.TrangThai.Equals("Giao hàng"))
            {
                MessageBox.Show("Hóa đơn đang được giao!");
                return;
            }
            if (hoaDon.TrangThai.Equals("Đã giao hàng"))
            {
                MessageBox.Show("Hóa đơn đã được giao!");
                return;
            }
            if (hoaDon.TrangThai.Equals("Từ chối"))
            {
                MessageBox.Show("Hóa đơn đã bị từ chối do một vài lý do (hết hàng,...)!");
                return;
            }

            hoaDon.TrangThai = "Đặt hàng";
            hoaDon.NgayLapHoaDon = DateTime.Now;
            if (hoaDonService.Sua(hoaDon))
            {
                MessageBox.Show("Đặt hàng thành công!");
                UserControl_Loaded(sender, e);
                return;
            }
            MessageBox.Show("Đặt hàng thất bại!");
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            int maHoaDon = int.Parse(((Button)sender).Tag.ToString());
            HoaDon hoaDon = ((Button)e.OriginalSource).DataContext as HoaDon;
            if(hoaDon.TrangThai.Equals("Giao hàng"))
            {
                MessageBox.Show("Hóa đơn đang được giao hàng. Bạn không thể hủy hóa đơn này!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (hoaDonService.Xoa(maHoaDon))
                {
                    MessageBox.Show("Xóa thành công!");
                    UserControl_Loaded(sender, e);
                    return;
                }
                MessageBox.Show("Xóa thất bại!");
                return;
            }
        }

    }
}
