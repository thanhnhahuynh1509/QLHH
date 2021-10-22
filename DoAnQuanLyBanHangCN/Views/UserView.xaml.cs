using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {

        public TaiKhoan taiKhoan;

        public UserView()
        {
            InitializeComponent();
        }

        private TaiKhoan PourInputValueIntoTaiKhoan()
        {
            TaiKhoan taiKhoan = new TaiKhoan();
            taiKhoan.TenTaiKhoan = txtTenTaiKhoan.Text;
            taiKhoan.MatKhau = txtMatKhau.Password;
            taiKhoan.HoTen = txtHoTen.Text;
            taiKhoan.SDT = txtSDT.Text;
            taiKhoan.DiaChi = txtDiaChi.Text;
            taiKhoan.IsAdmin = false;
            return taiKhoan;
        }

        private bool CheckInput()
        {
            string tenTaiKhoan = txtTenTaiKhoan.Text;
            string matKhau = txtMatKhau.Password;
            string hoTen = txtHoTen.Text;
            string sdt = txtSDT.Text;
            string diaChi = txtDiaChi.Text;

            if (tenTaiKhoan.Length < 8 || matKhau.Length < 8)
            {
                MessageBox.Show("Tài khoản và Mật khẩu phải có ít nhất là 8 ký tự!");
                return false;
            }
            if (hoTen.Length < 1)
            {
                MessageBox.Show("Họ tên không được để trống!");
                return false;
            }
            if (sdt.Length > 11 || sdt.Length < 8 || Regex.IsMatch(sdt, "\\D+"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return false;
            }
            if (diaChi.Length < 1)
            {
                MessageBox.Show("Địa chỉ không được để trống!");
                return false;
            }
            return true;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckInput())
                return;
            TaiKhoan tk = PourInputValueIntoTaiKhoan();
            TaiKhoanService tkService = new TaiKhoanService();
            if(tkService.Sua(tk))
            {
                MessageBox.Show("Cập nhật tài khoản thành công!");
                Close();
                return;
            } else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtHoTen.Text = taiKhoan.HoTen;
            txtDiaChi.Text = taiKhoan.DiaChi;
            txtSDT.Text = taiKhoan.SDT;
            txtTenTaiKhoan.Text = taiKhoan.TenTaiKhoan;
            txtMatKhau.Password = taiKhoan.MatKhau;
        }
    }
}
