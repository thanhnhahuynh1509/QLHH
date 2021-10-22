namespace DoAnQuanLyBanHangCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        [Key]
        public int MaTaiKhoan { get; set; }

        [Required]
        [StringLength(30)]
        public string TenTaiKhoan { get; set; }

        [Required]
        [StringLength(30)]
        public string MatKhau { get; set; }

        public bool? IsAdmin { get; set; }

        [Required]
        [StringLength(30)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(12)]
        public string SDT { get; set; }

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
