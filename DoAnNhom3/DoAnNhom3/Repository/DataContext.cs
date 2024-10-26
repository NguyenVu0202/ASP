using DoAnNhom3.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnNhom3.Repository
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public virtual DbSet<KhoaModel> Khoa { get; set; }
        public virtual DbSet<HocKyModel> HocKy { get; set; }
        public virtual DbSet<TaiLieuModel> TaiLieu { get; set; }
        public virtual DbSet<TaiKhoanModel> TaiKhoan { get; set; }
        public virtual DbSet<DangKyModel> DangKy { get; set; }
        public virtual DbSet<ChiTietDangKyModel> ChiTietDangKy { get; set; }
    }
}
