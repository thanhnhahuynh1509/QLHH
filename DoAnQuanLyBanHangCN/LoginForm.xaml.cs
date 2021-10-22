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

namespace DoAnQuanLyBanHangCN
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private TaiKhoanService taiKhoanService = new TaiKhoanService();

        // Đổ dữ liệu nhập vào thành tài khoản
        private TaiKhoan PourInputValueIntoTaiKhoan()
        {
            TaiKhoan taiKhoan = new TaiKhoan();
            taiKhoan.TenTaiKhoan = txtTenTaiKhoanRegis.Text;
            taiKhoan.MatKhau = txtMatKhauRegis.Password;
            taiKhoan.HoTen = txtHoTen.Text;
            taiKhoan.SDT = txtSDT.Text;
            taiKhoan.DiaChi = txtDiaChi.Text;

            return taiKhoan;
        }

        private bool CheckInputLogin()
        {
            string tenTaiKhoan = txtTenTaiKhoanLogin.Text;
            string matKhau = txtMatKhauLogin.Password;

            if(tenTaiKhoan.Equals("") || matKhau.Equals(""))
            {
                MessageBox.Show("Tài khoản hoặc Mật khẩu không được để trống!");
                return false;
            }

            return true;
        }

        private bool CheckInputRegis()
        {
            string tenTaiKhoan = txtTenTaiKhoanRegis.Text;
            string matKhau = txtMatKhauRegis.Password;
            string hoTen = txtHoTen.Text;
            string sdt = txtSDT.Text;
            string diaChi = txtDiaChi.Text;

            if(tenTaiKhoan.Length < 8 || matKhau.Length < 8)
            {
                MessageBox.Show("Tài khoản và Mật khẩu phải có ít nhất là 8 ký tự!");
                return false;
            }
            if(hoTen.Length < 1)
            {
                MessageBox.Show("Họ tên không được để trống!");
                return false;
            }
            if(sdt.Length > 11 || sdt.Length < 8 || Regex.IsMatch(sdt, "\\D+"))
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
            Application.Current.Shutdown();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(CheckInputLogin())
            {
                TaiKhoan taiKhoan = taiKhoanService.LayTaiKhoan(txtTenTaiKhoanLogin.Text, txtMatKhauLogin.Password);
                if(taiKhoan == null)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
                    return;
                }
                if(taiKhoan.IsAdmin == false)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.MaTaiKhoan = taiKhoan.MaTaiKhoan;
                    mainWindow.Show();
                    Close();
                } else
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                    Close();
                }
                
            }
        }

        private void BtnRegis_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputRegis())
            {
                TaiKhoan taiKhoan = PourInputValueIntoTaiKhoan();
                if(taiKhoanService.TimKiemBangTen(txtTenTaiKhoanRegis.Text) != null)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại!");
                    return;
                }
                taiKhoanService.Them(taiKhoan);

                txtTenTaiKhoanLogin.Text = txtTenTaiKhoanRegis.Text;
                txtMatKhauLogin.Password = txtMatKhauRegis.Password;
                MessageBox.Show("Đăng ký thành công!");
                BtnRedirectLoginForm_Click(sender, e);
                return;
            }
        }

        private void BtnRedirectRegisterForm_Click(object sender, RoutedEventArgs e)
        {
            txtHeader.Text = "ĐĂNG KÝ";
            Login.Margin = new Thickness(2000, 0, 0, 0);
            Register.Margin = new Thickness(0, 0, 0, 0);
            
        }
       

        private void BtnRedirectLoginForm_Click(object sender, RoutedEventArgs e)
        {
            txtHeader.Text = "ĐĂNG NHẬP";
            Login.Margin = new Thickness(0, 0, 0, 0);
            Register.Margin = new Thickness(2000, 0, 0, 0);
        }
    }
}
