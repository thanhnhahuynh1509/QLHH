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
    /// Interaction logic for LoaiHangView.xaml
    /// </summary>
    public partial class LoaiHangView : UserControl
    {

        private LoaiHangService loaiHangService = new LoaiHangService();

        private List<LoaiHang> listLoai;

        private HangHangHoaService hangHangHoaService = new HangHangHoaService();

        private List<HangHangHoa> listHangHangHoa;

        public bool laLoaiHang = false;

        public LoaiHangView()
        {
            InitializeComponent();
        }

        private void LoadLoaiHangHoa()
        {
            if(laLoaiHang)
            {
                listLoai = loaiHangService.LayTatCa();
                listLoaiHang.ItemsSource = listLoai;
            } else
            {
                listHangHangHoa = hangHangHoaService.LayTatCa();
                listLoaiHang.ItemsSource = listHangHangHoa;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddLoaiHangView addLoaiHangView = new AddLoaiHangView();
            if(!laLoaiHang)
            {
                addLoaiHangView.txtHeader.Text = "THÊM HÃNG HÀNG HÓA";
                addLoaiHangView.txtTenLoai.Text = "Tên Hãng";
            }
            addLoaiHangView.laLoaiHang = laLoaiHang;
            addLoaiHangView.ShowDialog();
            LoadLoaiHangHoa();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLoaiHangHoa();
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            AddLoaiHangView addLoaiHangView = new AddLoaiHangView();
            if (!laLoaiHang)
            {
                HangHangHoa hangHangHoa = ((Button)e.OriginalSource).DataContext as HangHangHoa;
                addLoaiHangView.txtHeader.Text = "CẬP NHẬT HÃNG HÀNG HÓA";
                addLoaiHangView.txtTenLoai.Text = "Tên Hãng";
                addLoaiHangView.txtTenLoaiOrHang.Text = hangHangHoa.Ten;
                addLoaiHangView.maLoaiHoacMaHang = hangHangHoa.MaHangHangHoa;
            } else
            {
                LoaiHang hangHoa = ((Button)e.OriginalSource).DataContext as LoaiHang;
                addLoaiHangView.txtHeader.Text = "CẬP NHẬT LOẠI HÀNG";
                addLoaiHangView.txtTenLoaiOrHang.Text = hangHoa.Ten;
                addLoaiHangView.maLoaiHoacMaHang = hangHoa.MaLoai;
            }
            addLoaiHangView.laLoaiHang = laLoaiHang;
            addLoaiHangView.BtnAdd.Margin = new Thickness(-2020,20,20,20);
            addLoaiHangView.BtnSua.Margin = new Thickness(20,20,20,20);
            addLoaiHangView.ShowDialog();
            LoadLoaiHangHoa();
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if(!laLoaiHang)
            {
                HangHangHoa hangHangHoa = ((Button)e.OriginalSource).DataContext as HangHangHoa;
                if(MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông Báo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (hangHangHoaService.Xoa(hangHangHoa.MaHangHangHoa))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadLoaiHangHoa();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
                
            } else
            {
                LoaiHang hangHoa = ((Button)e.OriginalSource).DataContext as LoaiHang;
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông Báo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (loaiHangService.Xoa(hangHoa.MaLoai))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadLoaiHangHoa();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
        }

    }
}
