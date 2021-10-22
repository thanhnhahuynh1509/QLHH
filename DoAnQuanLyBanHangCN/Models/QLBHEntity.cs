using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoAnQuanLyBanHangCN.Models
{
    public partial class QLBHEntity : DbContext
    {
        public QLBHEntity()
            : base("name=QLBHEnity")
        {
        }

        public virtual DbSet<HangHangHoa> HangHangHoa { get; set; }
        public virtual DbSet<HangHoa> HangHoa { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<LoaiHang> LoaiHang { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HangHangHoa>()
                .HasMany(e => e.HangHoa)
                .WithRequired(e => e.HangHangHoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiHang>()
                .HasMany(e => e.HangHoa)
                .WithRequired(e => e.LoaiHang)
                .WillCascadeOnDelete(false);
        }
    }
}
