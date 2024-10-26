using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnNhom3.Models
{
    public class TaiLieuModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int KhoaId { get; set; }
        public int HocKyId { get; set; }
        public string TenTaiLieu { get; set; }
        public string HinhTaiLieu { get; set; }
        public decimal Gia { get; set; }
        public virtual KhoaModel Khoa { get; set; }
        public virtual HocKyModel HocKy { get; set; }
    }
}
