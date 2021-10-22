using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnQuanLyBanHangCN.Models;

namespace DoAnQuanLyBanHangCN.Services
{
    class TaiKhoanService : ServiceCommon<TaiKhoan>
    {
        
        public TaiKhoan LayTaiKhoan(string tenTaiKhoan, string matKhau)
        {
            QLBHEntity db = new QLBHEntity();
            TaiKhoan taiKhoan = db.TaiKhoan.FirstOrDefault(p => p.TenTaiKhoan.Equals(tenTaiKhoan) && p.MatKhau.Equals(matKhau));
            return taiKhoan;
        }

        public TaiKhoan TimKiemBangTen(string tenTaiKhoan)
        {
            QLBHEntity db = new QLBHEntity();
            TaiKhoan taiKhoan = db.TaiKhoan.FirstOrDefault(p => p.TenTaiKhoan.Equals(tenTaiKhoan));
            return taiKhoan;
        }

        public TaiKhoan TimKiemBangMa(int maTaiKhoan)
        {
            QLBHEntity db = new QLBHEntity();
            TaiKhoan taiKhoan = taiKhoan = db.TaiKhoan.FirstOrDefault(p => p.MaTaiKhoan == maTaiKhoan);
            return taiKhoan;
        }

        public bool Them(TaiKhoan taiKhoan)
        {
            if (TimKiemBangTen(taiKhoan.TenTaiKhoan) != null)
                return false;
            QLBHEntity db = new QLBHEntity();
            taiKhoan.IsAdmin = false;
            db.TaiKhoan.Add(taiKhoan);
            db.SaveChanges();
            return true;
        }

        public bool Sua(TaiKhoan taiKhoan)
        {
            QLBHEntity db = new QLBHEntity();
            TaiKhoan taiKhoanUpdate = db.TaiKhoan.FirstOrDefault(p => p.TenTaiKhoan.Equals(taiKhoan.TenTaiKhoan));
            if (taiKhoanUpdate == null)
                return false;
            taiKhoanUpdate.MatKhau = taiKhoan.MatKhau;
            taiKhoanUpdate.HoTen = taiKhoan.HoTen;
            taiKhoanUpdate.SDT = taiKhoan.SDT;
            taiKhoanUpdate.DiaChi = taiKhoan.DiaChi;
            db.SaveChanges();
            return true;
        }

        public bool Xoa(int maTaiKhoan)
        {
            QLBHEntity db = new QLBHEntity();
            TaiKhoan taiKhoan = db.TaiKhoan.FirstOrDefault(p => p.MaTaiKhoan == maTaiKhoan);
            if (taiKhoan == null)
                return false;
            db.TaiKhoan.Remove(taiKhoan);
            db.SaveChanges();
            return true;
        }

        public new List<TaiKhoan> LayTatCa()
        {
            throw new NotImplementedException();
        }
    }
}
