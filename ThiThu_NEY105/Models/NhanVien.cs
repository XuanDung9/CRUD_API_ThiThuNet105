using System.ComponentModel.DataAnnotations;

namespace AppView.Models
{
    public class NhanVien
    {
        public Guid Id { get; set; }
        [StringLength(30,ErrorMessage ="Tên phải nhỏ hơn 30 kí tự ")]
        public string Ten { get; set; }
        [Range(18,50,ErrorMessage ="Tuôi phải từ 18 đến 50 tuổi ")]
        public int Tuoi { get; set; }
        public int Role { get; set; }
        [EmailAddress(ErrorMessage ="Địa chỉ Email không hợp lệ")]
        public string Email { get; set; }
        [Range(5000000,30000000,ErrorMessage ="Lương phải từ 5 đến 30 triệu ")]
        public int Luong { get; set; }
        public bool TrangThai { get; set; }
    }
}
