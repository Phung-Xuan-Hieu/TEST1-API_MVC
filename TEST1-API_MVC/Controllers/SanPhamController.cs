using App_Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TEST1_API_MVC.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPhamController
        public async Task<ActionResult> Index()
        {
            // Để call được API thì chúng ta cần lấy được URL request
            string requestURL = "https://localhost:44370/api/Sinhviens/get-all";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requestURL); // lấy response
            // Đọc từ response chuỗi Json là kết quả của phép trả về
            string apiData = await response.Content.ReadAsStringAsync();
            // Có data rồi thì ta sẽ convert về dữ liệu mình cần để đưa sang view
            var sinhviens = JsonConvert.DeserializeObject<List<SanPham>>(apiData);
            return View(sinhviens);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            string requestURL =
                $"https://localhost:44370/api/Sinhviens/get-by-id?id={id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requestURL); // lấy response
            // Đọc từ response chuỗi Json là kết quả của phép trả về
            string apiData = await response.Content.ReadAsStringAsync();
            // Có data rồi thì ta sẽ convert về dữ liệu mình cần để đưa sang view
            var sinhviens = JsonConvert.DeserializeObject<SanPham>(apiData);
            return View(sinhviens);
        }

        // GET: SinhvienController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SinhvienController/Create
        [HttpPost]
        public async Task<ActionResult> Create(SanPham sv)
        {
            // Cách dùng obj
            string requestURL =
                $"https://localhost:44370/api/Sinhviens/post-by-obj"; // truyền bằng object
            var httpClient = new HttpClient();
            var obj = JsonConvert.SerializeObject(sv);
            var response = await httpClient.PostAsJsonAsync(requestURL, sv); // lấy response
            // Đọc từ response chuỗi Json là kết quả của phép trả về
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else return BadRequest(response);
        }
        [HttpPost]
        //public async Task<ActionResult> Create2(SanPham sv)
        //{
        //    // Cách dùng obj
        //    SanPham sv2 = sv;
        //    string requestURL =
        //        @$"https://localhost:44370/api/Sinhviens/post-by-params?Name=Kiên" +
        //        $"&Description=Tạch&Email={sv.Email}&PhoneNumber={sv.PhoneNumber}" +
        //        $"&DoB={sv.DoB}&Address=Cay&Major={sv.Major}";
        //    var httpClient = new HttpClient();
        //    var response = await httpClient.GetAsync(requestURL); // lấy response
        //    // Đọc từ response chuỗi Json là kết quả của phép trả về
        //    string apiData = await response.Content.ReadAsStringAsync();
        //    // Có data rồi thì ta sẽ convert về dữ liệu mình cần để đưa sang view
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else return BadRequest(response);
        //}
        public async Task<ActionResult> Create2()
        {
            return View();
        }

        // GET: SinhvienController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SinhvienController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SinhvienController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            string requestURL =
                $"https://localhost:44370/api/Sinhviens/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requestURL); // lấy response
            // Đọc từ response chuỗi Json là kết quả của phép trả về
            string apiData = await response.Content.ReadAsStringAsync();
            // Có data rồi thì ta sẽ convert về dữ liệu mình cần để đưa sang view
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else return BadRequest(response);

        }
    }
}
