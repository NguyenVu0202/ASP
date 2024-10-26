using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnNhom3.Models
{
    public class TaiKhoanModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TenTK { get; set; }
        public string HoTen { get; set;}
        public string MaSinhVien { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public virtual ICollection<DangKyModel> DangKy { get; set; }
    }
}
