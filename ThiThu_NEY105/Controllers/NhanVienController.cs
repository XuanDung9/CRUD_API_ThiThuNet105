using AppData;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class NhanVienController : Controller
    {
        AppDbContext _context;
        HttpClient _client;

        public NhanVienController()
        {
            _context = new AppDbContext();
            _client = new HttpClient();
        }
        public List<NhanVien> Index()
        {
            string requestURL = $@"https://localhost:7276/api/NhanVien/nhanvien-get-all";
            var response = _client.GetStringAsync(requestURL).Result;
            List<NhanVien> nhanViens = JsonConvert.DeserializeObject<List<NhanVien>>(response);
            return nhanViens;
        }
    }
}
