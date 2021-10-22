namespace DoAnQuanLyBanHangCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HangHoa")]
    public partial class HangHoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangHoa()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        [Key]
        public int MaHangHoa { get; set; }

        [Required]
        [StringLength(200)]
        public string TenHangHoa { get; set; }

        [Column(TypeName = "image")]
        public byte[] HinhAnh { get; set; }

        public long? Gia { get; set; }

        public int MaHangHangHoa { get; set; }

        public int MaLoai { get; set; }

        public virtual HangHangHoa HangHangHoa { get; set; }

        public virtual LoaiHang LoaiHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
