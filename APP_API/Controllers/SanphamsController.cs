using App_Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APP_API.Controllers
{
    public class SanphamsController : Controller
    {
        public AppDbContext context = new AppDbContext();
        // GET: SanphamsController
        [HttpGet("get-all")]
        public IEnumerable<SanPham> Getall()
        {
            return context.sanPhams.ToList();
        }

        // GET: SanphamsController/Details/5
        [HttpGet("get-by-MASP")]
        public SanPham GetbyId(string MASP)
        {
            return context.sanPhams.Find(MASP);
        }

        // POST: SanphamsController/Create
        [HttpPost("post-by-obj")]
        public bool PostByObj([FromBody] SanPham sanPham)
        {
            try
            {
                context.sanPhams.Add(sanPham);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // GET: SanphamsController/Edit/5
        [HttpPost("post-by-Pramas")]
        public bool PostByPramas(string Masp , string tenSanPham , int gia , int soluongkho , string nhaxuatban , string thuonghieu)
        {
            SanPham sanPham = new SanPham
            {
                IDSP= Masp ,
                TenSanPham= tenSanPham ,
                Gia= gia ,
                SoLuongTonKho = soluongkho ,
                NhaXuatBan = nhaxuatban ,
                ThuongHieu= thuonghieu ,
            };
            try
            {
                context.sanPhams.Add(sanPham);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // POST: SanphamsController/Edit/5
        [HttpPut("put-by-obj")]
        public bool PutByObj([FromBody] SanPham sanPham, string masp)
        {
            SanPham sp = context.sanPhams.FirstOrDefault(p => p.IDSP == masp);
            try
            {
                sp.Gia = sanPham.Gia;
                sp.SoLuongTonKho = sanPham.SoLuongTonKho;
                sp.NhaXuatBan = sanPham.NhaXuatBan;
                sp.ThuongHieu = sanPham.ThuongHieu;
                context.sanPhams.Update(sp);
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        [HttpGet("{id}")]
        public bool Delete(string MaSp)
        {
            try
            {
                SanPham sv = context.sanPhams.Find(MaSp);
                context.sanPhams.Remove(sv);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // GET: SanphamsController/Delete/5
        [HttpGet]
        [Route("tinh tien")]
        public int TinhTien(double price, double coupon, double voucher)
        {
            var a = price * (1 - coupon / 100) - voucher;
            return (int)a;
        }
    }
}
