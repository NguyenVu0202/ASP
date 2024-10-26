using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnNhom3.Models
{
    public class DangKyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TaiKhoanId { get; set; }
        public DateTime NgayDK { get; set; }
        public virtual TaiKhoanModel TaiKhoan { get; set;}
    }
}
