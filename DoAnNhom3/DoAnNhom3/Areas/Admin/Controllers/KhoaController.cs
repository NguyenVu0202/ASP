using DoAnNhom3.Repository;
using Microsoft.AspNetCore.Mvc;
using DoAnNhom3.Models;
using Newtonsoft.Json.Linq;

namespace DoAnNhom3.Areas.Admin.Controllers
{
	[Area("admin")]
    [Route("admin")]
    public class KhoaController : Controller
	{
		private readonly DataContext _dataContext;
		private readonly ILogger<KhoaController> _logger;
		public KhoaController(ILogger<KhoaController> logger, DataContext dataContext)
		{
			_logger = logger;
			_dataContext = dataContext;
		}

		[Route("QuanLyKhoa")]
		public IActionResult Index()
		{
			var khoa = _dataContext.Khoa.ToList();
			return View(khoa);
		}

        [Route("ThemKhoa")]
		[HttpGet]
		public IActionResult ThemKhoa()
		{
			return View();
		}

        [Route("ThemKhoa")]
        [HttpPost]
        public IActionResult ThemKhoa(KhoaModel khoa)
        {
            _dataContext.Khoa.Add(khoa);
			_dataContext.SaveChanges();
            return RedirectToAction("QuanLyKhoa", "Admin");
        }

        [Route("SuaKhoa")]
        [HttpGet]
        public IActionResult SuaKhoa(int id)
        {
            var khoa = _dataContext.Khoa.Find(id);
            return View(khoa);
        }

        [Route("SuaKhoa")]
        [HttpPost]
        public IActionResult SuaKhoa(KhoaModel khoa)
        {
            _dataContext.Khoa.Update(khoa);
            _dataContext.SaveChanges();
            return RedirectToAction("QuanLyKhoa", "Admin");
        }

        [Route("XoaKhoa")]
        [HttpGet]
        public IActionResult XoaKhoa(int id)
        {
            TempData["Message"] = "";
            var tailieu = _dataContext.TaiLieu.Where(x => x.KhoaId == id);
            if (tailieu.Count() > 0)
            {
                TempData["Message"] = "Không xóa được khoa này";
                return RedirectToAction("QuanLyKhoa", "Admin");
            }
            _dataContext.Remove(_dataContext.Khoa.Find(id));
            _dataContext.SaveChanges();
            TempData["Message"] = "Khoa đã được xóa";
            return RedirectToAction("QuanLyKhoa", "Admin");
        }
    }
}
