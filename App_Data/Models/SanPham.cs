using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class SanPham
    {
        [Key]
        [MaxLength(4)]
        public string IDSP { get; set; }
        [Required(ErrorMessage = "You must enter a Name for SanPham")]
        [MaxLength(15)]
        public string TenSanPham { get; set; }
        [Range(1000, 30000000, ErrorMessage = "Giá phải từ 1000 đến 30.000.000")]
        public int Gia { get; set; }
        public int SoLuongTonKho { get; set; }
        [Required(ErrorMessage = "Nhà sản xuất không được để trống")]
        public string NhaXuatBan { get; set; }
        public string ThuongHieu { get; set; }

    }
}
