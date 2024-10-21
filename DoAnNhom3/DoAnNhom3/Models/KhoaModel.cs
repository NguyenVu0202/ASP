using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnNhom3.Models
{
    public class KhoaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TenKhoa { get; set; }
        public virtual ICollection<TaiLieuModel> TaiLieu { get; set; }
    }
}
