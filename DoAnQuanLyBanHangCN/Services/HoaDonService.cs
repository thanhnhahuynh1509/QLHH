using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnQuanLyBanHangCN.Models;

namespace DoAnQuanLyBanHangCN.Services
{
    class HoaDonService : ServiceCommon<HoaDon>
    {

        QLBHEntity db = new QLBHEntity();

        public HoaDon TimKiemBangTen(string ten)
        {
            return null;
        }

        public List<HoaDon> TimKiemBangMaTaiKhoan(int ma)
        {
            QLBHEntity db = new QLBHEntity();
            List<HoaDon> hoaDon = db.HoaDon.Where(p => p.TaiKhoan.MaTaiKhoan == ma).ToList();
            return hoaDon;
        }

        public HoaDon TimKiemBangMa(int ma)
        {
            QLBHEntity db = new QLBHEntity();
            HoaDon hoaDon = db.HoaDon.FirstOrDefault(p => p.MaHoaDon == ma);
            return hoaDon;
        }

        public bool Them(HoaDon phanTu)
        {
            if (TimKiemBangMa(phanTu.MaHoaDon) != null)
                return false;
            QLBHEntity db = new QLBHEntity();
            db.HoaDon.Add(phanTu);
            db.SaveChanges();
            return true;
        }

        public bool Sua(HoaDon phanTu)
        {
            QLBHEntity db = new QLBHEntity();
            HoaDon hoaDon = db.HoaDon.FirstOrDefault(p => p.MaHoaDon == phanTu.MaHoaDon);
            if (hoaDon == null)
                return false;
            hoaDon.NgayLapHoaDon = phanTu.NgayLapHoaDon;
            hoaDon.TrangThai = phanTu.TrangThai;
            db.SaveChanges();
            return true;
        }


        public bool Xoa(int ma)
        {
            HoaDon hoaDon = db.HoaDon.FirstOrDefault(p => p.MaHoaDon == ma);
            if (hoaDon == null)
                return false;
            db.HoaDon.Remove(hoaDon);
            db.SaveChanges();
            return true;
        }

        public List<HoaDon> LayTatCa()
        {
            QLBHEntity db = new QLBHEntity();
            return db.HoaDon.ToList();
        }
    }
}
