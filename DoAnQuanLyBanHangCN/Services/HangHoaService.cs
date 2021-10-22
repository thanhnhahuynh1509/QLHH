using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnQuanLyBanHangCN.Models;

namespace DoAnQuanLyBanHangCN.Services
{
    class HangHoaService : ServiceCommon<HangHoa>
    {
     
        QLBHEntity db = new QLBHEntity();

        public HangHoa TimKiemBangTen(string ten)
        {
            QLBHEntity db = new QLBHEntity();
            HangHoa hangHoa = db.HangHoa.FirstOrDefault(p => p.TenHangHoa.Equals(ten));
            return hangHoa;
        }

        public HangHoa TimKiemBangMa(int ma)
        {
            QLBHEntity db = new QLBHEntity();
            HangHoa hangHoa = db.HangHoa.FirstOrDefault(p => p.MaHangHoa == ma);
            return hangHoa;
        }

        public List<HangHoa> TimKiemBangMaHangHangHoa(int ma)
        {
            QLBHEntity db = new QLBHEntity();
            List<HangHoa> hangHoa = db.HangHoa.Where(p => p.MaHangHangHoa == ma).ToList();
            return hangHoa;
        }

        public List<HangHoa> TimKiemBangMaLoai(int ma)
        {
            QLBHEntity db = new QLBHEntity();
            List<HangHoa> hangHoa = db.HangHoa.Where(p => p.MaLoai == ma).ToList();
            return hangHoa;
        }

        public bool Them(HangHoa phanTu)
        {
            if (TimKiemBangMa(phanTu.MaHangHoa) != null)
                return false;
            QLBHEntity db = new QLBHEntity();
            db.HangHoa.Add(phanTu);
            db.SaveChanges();
            return true;
        }

        public bool Sua(HangHoa phanTu)
        {
            HangHoa hangHoaUpdate = db.HangHoa.FirstOrDefault(p => p.MaHangHoa == phanTu.MaHangHoa);
            if (hangHoaUpdate == null)
                return false;
            hangHoaUpdate.TenHangHoa = phanTu.TenHangHoa;
            hangHoaUpdate.Gia = phanTu.Gia;
            hangHoaUpdate.HinhAnh = phanTu.HinhAnh;
            hangHoaUpdate.MaHangHangHoa = phanTu.MaHangHangHoa;
            hangHoaUpdate.MaLoai = phanTu.MaLoai;
            db.SaveChanges();
            return true;
        }


        public bool Xoa(int ma)
        {
            HangHoa hangHoa = db.HangHoa.FirstOrDefault(p => p.MaHangHoa == ma);
            if (hangHoa == null)
                return false;
            db.HangHoa.Remove(hangHoa);
            db.SaveChanges();
            return true;
        }

        public List<HangHoa> LayTatCa()
        {
            QLBHEntity db = new QLBHEntity();
            return db.HangHoa.ToList();
        }
    }
}
