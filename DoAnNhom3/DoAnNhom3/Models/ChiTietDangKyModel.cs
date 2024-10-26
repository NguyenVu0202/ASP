using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnNhom3.Models
{
    public class ChiTietDangKyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DangKyID { get; set; }
        public int TaiLieuID { get; set; }
        public int SoLuong { get; set; }
        public virtual TaiLieuModel TaiLieu { get; set;}
        public virtual DangKyModel DangKy { get; set; }
    }
}
