using DoAnNhom3.Models;
using DoAnNhom3.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DoAnNhom3.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class HocKyController : Controller
    {
		private readonly DataContext _dataContext;
		private readonly ILogger<HocKyController> _logger;
		public HocKyController(ILogger<HocKyController> logger, DataContext dataContext)
		{
			_logger = logger;
			_dataContext = dataContext;
		}

		[Route("QuanLyHocKy")]
		public IActionResult Index()
        {
			var hocky = _dataContext.HocKy.ToList();
            return View(hocky);
        }

        [Route("ThemHocKy")]
        [HttpGet]
        public IActionResult ThemHocKy()
        {
            return View();
        }

        [Route("ThemHocKy")]
        [HttpPost]
        public IActionResult ThemHocKy(HocKyModel hocky)
        {
            _dataContext.HocKy.Add(hocky);
            _dataContext.SaveChanges();
            return RedirectToAction("QuanLyHocKy", "Admin");
        }

        [Route("SuaHocKy")]
        [HttpGet]
        public IActionResult SuaHocKy(int id)
        {
            var hocky = _dataContext.HocKy.Find(id);
            return View(hocky);
        }

        [Route("SuaHocKy")]
        [HttpPost]
        public IActionResult SuaHocKy(HocKyModel hocky)
        {
            _dataContext.HocKy.Update(hocky);
            _dataContext.SaveChanges();
            return RedirectToAction("QuanLyHocKy", "Admin");
        }

        [Route("XoaHocKy")]
        [HttpGet]
        public IActionResult XoaHocKy(int id)
        {
            TempData["Message"] = "";
            var tailieu = _dataContext.TaiLieu.Where(x => x.HocKyId == id);
            if (tailieu.Count() > 0)
            {
                TempData["Message"] = "Không xóa được học kỳ này";
                return RedirectToAction("QuanLyHocKy", "Admin");
            }
            _dataContext.Remove(_dataContext.HocKy.Find(id));
            _dataContext.SaveChanges();
            TempData["Message"] = "Học kỳ đã được xóa";
            return RedirectToAction("QuanLyHocKy", "Admin");
        }
    }
}
