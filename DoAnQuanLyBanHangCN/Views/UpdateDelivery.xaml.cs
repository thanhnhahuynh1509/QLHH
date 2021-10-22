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
using DoAnQuanLyBanHangCN.Models;
using DoAnQuanLyBanHangCN.Services;

namespace DoAnQuanLyBanHangCN.Views
{
    /// <summary>
    /// Interaction logic for UpdateDelivery.xaml
    /// </summary>
    public partial class UpdateDelivery : Window
    {
        public int maHoaDon;

        private HoaDonService hdService = new HoaDonService();

        public UpdateDelivery()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxTrangThai.Items.Add("Giao hàng");
            cbxTrangThai.Items.Add("Đã giao hàng");
        }

        private void CapNhatTrangThai(HoaDon hoaDon)
        {
            hoaDon.TrangThai = cbxTrangThai.Text;
            hdService.Sua(hoaDon);
            Close();
        }

        private void BtnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            HoaDon hd = hdService.TimKiemBangMa(maHoaDon);
            CapNhatTrangThai(hd);
        }
    }
}
