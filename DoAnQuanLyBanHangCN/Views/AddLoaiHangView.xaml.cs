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
    /// Interaction logic for AddLoaiHangView.xaml
    /// </summary>
    public partial class AddLoaiHangView : Window
    {
        private LoaiHangService loaiHangService = new LoaiHangService();

        private HangHangHoaService hangHangHoaService = new HangHangHoaService();

        public int maLoaiHoacMaHang;

        public bool laLoaiHang = false;
        public AddLoaiHangView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txtTenLoaiOrHang.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if(laLoaiHang)
            {
                LoaiHang lh = new LoaiHang();
                lh.Ten = txtTenLoaiOrHang.Text;
                if (loaiHangService.Them(lh))
                {
                    MessageBox.Show("Thêm mới loại hàng thành công!");
                    Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm mới loại hàng thật bại!");
                    return;
                }
            } else
            {
                HangHangHoa hhh = new HangHangHoa();
                hhh.Ten = txtTenLoaiOrHang.Text;
                if(hangHangHoaService.Them(hhh))
                {
                    MessageBox.Show("Thêm mới hãng hàng hóa thành công!");
                    Close();
                    return;
                }else
                {
                    MessageBox.Show("Thêm mới hãng hàng hóa thật bại!");
                    return;
                }
            }
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            if (txtTenLoaiOrHang.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (laLoaiHang)
            {
                LoaiHang lh = new LoaiHang();
                lh.MaLoai = maLoaiHoacMaHang;
                lh.Ten = txtTenLoaiOrHang.Text;
                if (loaiHangService.Sua(lh))
                {
                    MessageBox.Show("Cập nhật loại hàng thành công!");
                    Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật loại hàng thật bại!");
                    return;
                }
            }
            else
            {
                HangHangHoa hhh = new HangHangHoa();
                hhh.MaHangHangHoa = maLoaiHoacMaHang;
                hhh.Ten = txtTenLoaiOrHang.Text;
                
                if (hangHangHoaService.Sua(hhh))
                {
                    MessageBox.Show("Cập nhật hãng hàng hóa thành công!");
                    Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật hãng hàng hóa thật bại!");
                    return;
                }
            }
        }
    }
}
