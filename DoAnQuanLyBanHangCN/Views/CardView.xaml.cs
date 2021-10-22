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
    /// Interaction logic for CardView.xaml
    /// </summary>
    public partial class CardView : UserControl
    {

        public bool isAdmin = false;

        public int maTaiKhoan;

        private HangHoaService hangHoaService = new HangHoaService();

        public CardView()
        {
            InitializeComponent();
        }

        // Border [ StackPanel [ Image, TextBlock, StackPanel [ Button, Button ] ] ]


        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        private Image CustomImage(byte[] imageByteArray)
        {

            Image img = new Image();
            img.Height = 200;
            img.Width = 200;
            img.Margin = new Thickness(0, 10, 0, 0);
            img.Source = ToImage(imageByteArray);
            return img;
        }

        private TextBlock CustomTextBlock(string tenHangHoa)
        {
            TextBlock txt = new TextBlock();
            txt.Text = tenHangHoa;
            txt.Foreground = new BrushConverter().ConvertFrom("#333") as Brush;
            txt.TextAlignment = TextAlignment.Center;
            txt.Margin = new Thickness(0, 10, 0, 0);
            txt.FontSize = 16;
            return txt;
        }

        private Button CustomButtonPrice(long? giaHangHoa)
        {
            Button btn = new Button();
            btn.Width = 80;
            btn.Height = 40;
            btn.Content = giaHangHoa + " $";
            btn.Style = TryFindResource("ButtonToolExitTopMenu") as Style;
            btn.Background = new BrushConverter().ConvertFrom("#E63E6D") as Brush;
            btn.Foreground = new BrushConverter().ConvertFrom("#fff") as Brush;
            btn.FontWeight = FontWeights.Medium;
            btn.Margin = new Thickness(0, 0, 15, 0);
            btn.FontSize = 14;
            return btn;
        }

        private Button CustomButtonAddCart(int maHangHoa)
        {
            Button btn = new Button();
            btn.Width = 130;
            btn.Height = 40;
            btn.Content = "Thêm vào giỏ hàng";
            btn.Click += BtnThemVaoGioHang_Click;
            btn.Style = TryFindResource("ButtonToolExitTopMenu") as Style;
            btn.Background = new BrushConverter().ConvertFrom("#D5EEBB") as Brush;
            btn.Foreground = new BrushConverter().ConvertFrom("#333") as Brush;
            btn.FontWeight = FontWeights.Medium;
            btn.FontSize = 14;
            btn.Tag = maHangHoa;
            return btn;
        }

        private Button CustomButtonUpdateProduct(int maHangHoa)
        {
            Button btn = new Button();
            btn.Width = 130;
            btn.Height = 40;
            btn.Content = "Cập nhật";
            btn.Click += BtnUpdateProduct_Click;
            btn.Style = TryFindResource("ButtonToolExitTopMenu") as Style;
            btn.Background = new BrushConverter().ConvertFrom("#f0ea78") as Brush;
            btn.Foreground = new BrushConverter().ConvertFrom("#333") as Brush;
            btn.FontWeight = FontWeights.Medium;
            btn.FontSize = 14;
            btn.Tag = maHangHoa;
            return btn;
        }

        private StackPanel CustomStackPanelContainButton(HangHoa hangHoa)
        {
            StackPanel stack = new StackPanel();

            stack.Orientation = Orientation.Horizontal;
            stack.HorizontalAlignment = HorizontalAlignment.Center;
            stack.Margin = new Thickness(0, 10, 0, 0);
            stack.Children.Add(CustomButtonPrice(hangHoa.Gia));
            if(!isAdmin)
            {
                stack.Children.Add(CustomButtonAddCart(hangHoa.MaHangHoa));
            } else
            {
                stack.Children.Add(CustomButtonUpdateProduct(hangHoa.MaHangHoa));
            }
            return stack;
        }

        private StackPanel CustomStackPanelContainAll(HangHoa hangHoa)
        {
            StackPanel stack = new StackPanel();
            stack.Width = 250;
            stack.Height = 300;
            stack.Children.Add(CustomImage(hangHoa.HinhAnh));
            stack.Children.Add(CustomTextBlock(hangHoa.TenHangHoa));
            stack.Children.Add(CustomStackPanelContainButton(hangHoa));
            return stack;
        }

        public Border CustomHangHoa(HangHoa hangHoa)
        {
            Border card = new Border();
            card.CornerRadius = new CornerRadius(15);
            card.Background = new BrushConverter().ConvertFrom("#fff") as Brush;
            card.Margin = new Thickness(0, 0, 10, 10);
            card.Child = CustomStackPanelContainAll(hangHoa);
            return card;
        }
        // END hàng hóa

        private void BtnThemVaoGioHang_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int maHangHoa = int.Parse(btn.Tag.ToString());
            HoaDonService hoaDonService = new HoaDonService();
            HoaDon hoaDon = new HoaDon();
            hoaDon.MaTaiKhoan = maTaiKhoan;
            hoaDon.MaHangHoa = maHangHoa;
            hoaDon.TrangThai = "Chưa đặt hàng";
            hoaDon.NgayLapHoaDon = DateTime.Now;
            if(hoaDonService.Them(hoaDon))
            {
                MessageBox.Show("Thêm vào giỏ hàng thành công!");
                return;
            }
            MessageBox.Show("Thêm vào giỏ hàng thất bại!");
        }

        private void BtnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int maHangHoa = int.Parse(btn.Tag.ToString());
            HangHoa hangHoa = hangHoaService.TimKiemBangMa(maHangHoa);
            if(hangHoa != null)
            {
                AddHangHoaView addHangHoaView = new AddHangHoaView();
                addHangHoaView.txtHeader.Text = "CẬP NHẬT HÀNG HÓA";
                addHangHoaView.maHangHoa = maHangHoa;
                addHangHoaView.txtTenHangHoa.Text = hangHoa.TenHangHoa;
                addHangHoaView.txtGiaHangHoa.Text = hangHoa.Gia.ToString();
                addHangHoaView.img = hangHoa.HinhAnh;
                addHangHoaView.LoadImageOutside();
                addHangHoaView.cbxHangHangHoa.SelectedValue = hangHoa.MaHangHangHoa;
                addHangHoaView.cbxLoaiHangHoa.SelectedValue = hangHoa.MaLoai;
                addHangHoaView.ShowDialog();
            }
        }

        
    }
}
