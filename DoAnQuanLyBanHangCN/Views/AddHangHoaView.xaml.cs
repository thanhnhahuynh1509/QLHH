using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using DoAnQuanLyBanHangCN.Services;
using DoAnQuanLyBanHangCN.Models;
using System.Text.RegularExpressions;

namespace DoAnQuanLyBanHangCN.Views
{
    /// <summary>
    /// Interaction logic for AddHangHoaView.xaml
    /// </summary>
    public partial class AddHangHoaView : Window
    {
        public byte[] img;

        public int maHangHoa;

        public AddHangHoaView()
        {
            InitializeComponent();
            LoadHangHangHoa();
            LoadLoaiHang();
        }

        private void LoadHangHangHoa()
        {
            ServiceCommon<HangHangHoa> hangHangHoaService = new HangHangHoaService();
            List<HangHangHoa> list = hangHangHoaService.LayTatCa();
            cbxHangHangHoa.SelectedIndex = 0;
            cbxHangHangHoa.ItemsSource = list;
            cbxHangHangHoa.DisplayMemberPath = "Ten";
            cbxHangHangHoa.SelectedValuePath = "MaHangHangHoa";
        }

        private void LoadLoaiHang()
        {
            ServiceCommon<LoaiHang> loaiHangHoaService = new LoaiHangService();
            List<LoaiHang> list = loaiHangHoaService.LayTatCa();
            cbxLoaiHangHoa.SelectedIndex = 0;
            cbxLoaiHangHoa.ItemsSource = list;
            cbxLoaiHangHoa.DisplayMemberPath = "Ten";
            cbxLoaiHangHoa.SelectedValuePath = "MaLoai";
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private byte[] ConvertImageToBinary(string imgFileName)
        {
            byte[] result = File.ReadAllBytes(imgFileName);
            return result;
        }


        private BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        private Image CustomImage(byte[] imageByteArray)
        {

            Image img = new Image();
            img.Height = 150;
            img.MaxWidth = 150;
            img.Source = ToImage(imageByteArray);
            return img;
        }

        public void LoadImageOutside()
        {
            ContainImage.Children.Clear();
            ContainImage.Children.Add(CustomImage(img));
        }

        private void BtnOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";

            if (open.ShowDialog() == true)
            {
                img = ConvertImageToBinary(open.FileName);
                ContainImage.Children.Add(CustomImage(img));
            }
        }

        private bool CheckInput()
        {
            if(Regex.IsMatch(txtGiaHangHoa.Text, "\\D+"))
            {
                MessageBox.Show("Giá bán không hợp lệ!");
                return false;
            }
            if(txtTenHangHoa.Text.Equals(""))
            {
                MessageBox.Show("Tên hàng hóa không được để trống!");
                return false;
            }
            if(img == null)
            {
                MessageBox.Show("Vui lòng chọn hình ảnh cho hàng hóa!");
                return false;
            }
            return true;
        }

        private HangHoa PourValueInputIntoHangHoa()
        {
            HangHoa hangHoa = new HangHoa();

            hangHoa.TenHangHoa = txtTenHangHoa.Text;
            hangHoa.Gia = long.Parse(txtGiaHangHoa.Text);
            hangHoa.HinhAnh = img;
            hangHoa.MaHangHangHoa = int.Parse(cbxHangHangHoa.SelectedValue.ToString());
            hangHoa.MaLoai = int.Parse(cbxLoaiHangHoa.SelectedValue.ToString());
            return hangHoa;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckInput())
                return;
            try
            {
                ServiceCommon<HangHoa> hangHoaService = new HangHoaService();
                HangHoa hangHoa = PourValueInputIntoHangHoa();
                hangHoaService.Them(hangHoa);
                MessageBox.Show("Thêm hàng hóa thành công!");
                Close();
            } catch(Exception)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hãng hàng hóa và loại hàng!");
            }
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hóa này?", "Thông Báo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                HangHoaService hangHoaService = new HangHoaService();
                if(hangHoaService.Xoa(maHangHoa)) 
                {
                    MessageBox.Show("Xóa thành công!");
                    Close();
                    return;
                }
                MessageBox.Show("Xóa thất bại!");
                return;
            }
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckInput())
                return;
            try
            {
                ServiceCommon<HangHoa> hangHoaService = new HangHoaService();
                HangHoa hangHoa = PourValueInputIntoHangHoa();
                hangHoa.MaHangHoa = maHangHoa;
                if(hangHoaService.Sua(hangHoa))
                {
                    MessageBox.Show("Cập nhật hàng hóa thành công!");
                    Close();
                } else
                {
                    MessageBox.Show("Cập nhật hàng hóa thật bại!");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hãng hàng hóa và loại hàng!");
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
