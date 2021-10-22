namespace DoAnQuanLyBanHangCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }

        public DateTime? NgayLapHoaDon { get; set; }

        [StringLength(30)]
        public string TrangThai { get; set; }

        public int MaHangHoa { get; set; }

        public int MaTaiKhoan { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
