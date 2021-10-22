using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnQuanLyBanHangCN.Models;

namespace DoAnQuanLyBanHangCN.Services
{
    class LoaiHangService : ServiceCommon<LoaiHang>
    {
        public LoaiHang TimKiemBangTen(string tenLoai)
        {
            QLBHEntity db = new QLBHEntity();
            LoaiHang loaiHang = db.LoaiHang.FirstOrDefault(p => p.Ten.Equals(tenLoai));
            return loaiHang;
        }

        public LoaiHang TimKiemBangMa(int maLoai)
        {
            QLBHEntity db = new QLBHEntity();
            LoaiHang loaiHang = db.LoaiHang.FirstOrDefault(p => p.MaLoai == maLoai);
            return loaiHang;
        }

        public bool Them(LoaiHang loaiHang)
        {
            if (TimKiemBangTen(loaiHang.Ten) != null)
                return false;
            QLBHEntity db = new QLBHEntity();
            db.LoaiHang.Add(loaiHang);
            db.SaveChanges();
            return true;
        }

        public bool Sua(LoaiHang loaiHang)
        {
            QLBHEntity db = new QLBHEntity();
            LoaiHang loaiHangUpdate = db.LoaiHang.FirstOrDefault(p => p.MaLoai == loaiHang.MaLoai);
            if (loaiHangUpdate == null)
                return false;
            loaiHangUpdate.Ten = loaiHang.Ten;
            db.SaveChanges();
            return true;
        }

        public bool Xoa(int maLoai)
        {
            QLBHEntity db = new QLBHEntity();
            LoaiHang loaiHang = db.LoaiHang.FirstOrDefault(p => p.MaLoai == maLoai);
            if (loaiHang == null)
                return false;
            db.LoaiHang.Remove(loaiHang);
            db.SaveChanges();
            return true;
        }

        public List<LoaiHang> LayTatCa()
        {
            QLBHEntity db = new QLBHEntity();
            return db.LoaiHang.ToList();
        }
    }
}
