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
    /// Interaction logic for HangHoaView.xaml
    /// </summary>
    public partial class HangHoaView : UserControl
    {

        public bool isAdmin;

        public int maTaiKhoan;

        private CardView cardView = new CardView();

        private List<HangHoa> list;

        private Button currentButton;

        private Button currentButtonLoaiHang;

        private int maHangHangHoaTmp, maLoai;

        public HangHoaView()
        {
            InitializeComponent();
        }

        private void LoadHangHoa()
        {
            ContainHangHoa.Children.Clear();
            ServiceCommon<HangHoa> hangHoaService = new HangHoaService();
            list = hangHoaService.LayTatCa();
            foreach(HangHoa hh in list)
            {
                ContainHangHoa.Children.Add(cardView.CustomHangHoa(hh));
            }
        }

        public Button CustomButtonLoaiHang(string tenLoai, int maLoai, bool laLoaiHang)
        {
            Button button = new Button();

            button.FontSize = 16;
            button.Height = 50;
            button.Style = TryFindResource("ButtonLoaiHang") as Style;
            button.Content = tenLoai;
            button.Tag = maLoai;

            if (laLoaiHang)
                button.Click += BtnLoaiHang_Click;
            else
                button.Click += BtnHangHangHoa_Click;

            return button;
        }

        private void BtnLoaiHang_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int maLoaiHang = int.Parse(btn.Tag.ToString());
            maLoai = maLoaiHang;
            if (currentButtonLoaiHang != null)
            {
                currentButtonLoaiHang.Style = TryFindResource("ButtonLoaiHang") as Style;
            }
            currentButtonLoaiHang = btn;
            btn.Style = TryFindResource("ButtonLoaiHangClick") as Style;
            ContainHangHoa.Children.Clear();
            if (maHangHangHoaTmp != 0)
            {
                foreach (HangHoa hh in list)
                {
                    if (hh.MaLoai == maLoaiHang && hh.MaHangHangHoa == maHangHangHoaTmp)
                        ContainHangHoa.Children.Add(cardView.CustomHangHoa(hh));
                }
            } else
            {
                foreach (HangHoa hh in list)
                {
                    if (hh.MaLoai == maLoaiHang)
                        ContainHangHoa.Children.Add(cardView.CustomHangHoa(hh));
                }
            }
        }

        private void BtnHangHangHoa_Click(object sender, RoutedEventArgs e)
        {
            if (currentButton != null)
            {
                currentButton.Style = TryFindResource("ButtonLoaiHang") as Style;
            }
            Button btn = sender as Button;
            currentButton = btn;
            btn.Style = TryFindResource("ButtonLoaiHangClick") as Style;
            int maHangHangHoa = int.Parse(btn.Tag.ToString());
            maHangHangHoaTmp = maHangHangHoa;
            ContainHangHoa.Children.Clear();
            if (maLoai != 0)
            {
                foreach (HangHoa hh in list)
                {
                    if(hh.MaLoai == maLoai && hh.MaHangHangHoa == maHangHangHoa)
                        ContainHangHoa.Children.Add(cardView.CustomHangHoa(hh));
                }
            } else
            {
                foreach (HangHoa hh in list)
                {
                    if (hh.MaHangHangHoa == maHangHangHoa)
                        ContainHangHoa.Children.Add(cardView.CustomHangHoa(hh));
                }
            }
            
        }

        private void LoadLoaiHang()
        {
            ContainLoaiHang.Children.Clear();
            ServiceCommon<LoaiHang> loaiHangHoaService = new LoaiHangService();
            List<LoaiHang> list = loaiHangHoaService.LayTatCa();
            foreach (LoaiHang lh in list)
            {
                ContainLoaiHang.Children.Add(CustomButtonLoaiHang(lh.Ten, lh.MaLoai, true));
            }
        }

        private void LoadHangHangHoa()
        {
            ContainHangHangHoa.Children.Clear();
            ServiceCommon<HangHangHoa> hangHangHoaService = new HangHangHoaService();
            List<HangHangHoa> list = hangHangHoaService.LayTatCa();
            foreach (HangHangHoa hhh in list)
            {
                ContainHangHangHoa.Children.Add(CustomButtonLoaiHang(hhh.Ten, hhh.MaHangHangHoa, false));
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            AddHangHoaView addHangHoaView = new AddHangHoaView();
            addHangHoaView.BtnAdd.Margin = new Thickness(10, 30, 10, 0);
            addHangHoaView.BtnAdd.Visibility = Visibility.Visible;
            addHangHoaView.BtnSua.Margin = new Thickness(-10000,0,0,0);
            addHangHoaView.BtnXoa.Margin = new Thickness(-10000,0,0,0);
            addHangHoaView.ShowDialog();
            LoadHangHoa();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cardView.isAdmin = isAdmin;
            cardView.maTaiKhoan = maTaiKhoan;
            LoadHangHoa();
            LoadLoaiHang();
            LoadHangHangHoa();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            LoadHangHoa();
            if (currentButton != null)
            {
                currentButton.Style = TryFindResource("ButtonLoaiHang") as Style;
            }
            if(currentButtonLoaiHang != null)
            {
                currentButtonLoaiHang.Style = TryFindResource("ButtonLoaiHang") as Style;
            }
            maHangHangHoaTmp = 0;
            maLoai = 0;
        }
    }
}
