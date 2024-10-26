namespace DoAnNhom3.Models
{
    public class TaiLieuDTO
    {
        public int KhoaId { get; set; }
        public int HocKyId { get; set; }
        public string TenTaiLieu { get; set; }
        public IFormFile? HinhTaiLieu { get; set; }
        public decimal Gia { get; set; }
    }
}
