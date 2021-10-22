using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnQuanLyBanHangCN.Models;

namespace DoAnQuanLyBanHangCN.Services
{
    interface ServiceCommon<T>
    {
        List<T> LayTatCa();

        T TimKiemBangTen(string ten);


        T TimKiemBangMa(int ma);


        bool Them(T phanTu);


        bool Sua(T phanTu);


        bool Xoa(int ma);
       
    }
}
