using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnQuanLyBanHangCN.Models;

namespace DoAnQuanLyBanHangCN.Services
{
    class HangHangHoaService : ServiceCommon<HangHangHoa>
    {
        public HangHangHoa TimKiemBangTen(string tenHHH)
        {
            QLBHEntity db = new QLBHEntity();
            HangHangHoa hhh = db.HangHangHoa.FirstOrDefault(p => p.Ten.Equals(tenHHH));
            return hhh;
        }

        public HangHangHoa TimKiemBangMa(int maHHH)
        {
            QLBHEntity db = new QLBHEntity();
            HangHangHoa hhh = db.HangHangHoa.FirstOrDefault(p => p.MaHangHangHoa == maHHH);
            return hhh;
        }

        public bool Them(HangHangHoa hangHangHoa)
        {
            if (TimKiemBangTen(hangHangHoa.Ten) != null)
                return false;
            QLBHEntity db = new QLBHEntity();
            db.HangHangHoa.Add(hangHangHoa);
            db.SaveChanges();
            return true;
        }

        public bool Sua(HangHangHoa hangHangHoa)
        {
            QLBHEntity db = new QLBHEntity();
            HangHangHoa hangHangHoaUpdate = db.HangHangHoa.FirstOrDefault(p => p.MaHangHangHoa == hangHangHoa.MaHangHangHoa);
            if (hangHangHoaUpdate == null)
                return false;
            hangHangHoaUpdate.Ten = hangHangHoa.Ten;
            db.SaveChanges();
            return true;
        }

        public bool Xoa(int maHangHangHoa)
        {
            QLBHEntity db = new QLBHEntity();
            HangHangHoa hangHangHoa = db.HangHangHoa.FirstOrDefault(p => p.MaHangHangHoa == maHangHangHoa);
            if (hangHangHoa == null)
                return false;
            db.HangHangHoa.Remove(hangHangHoa);
            db.SaveChanges();
            return true;
        }

        public List<HangHangHoa> LayTatCa()
        {
            QLBHEntity db = new QLBHEntity();
            return db.HangHangHoa.ToList();
        }
    }
}
