using DoAnNhom3.Models;
using DoAnNhom3.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAnNhom3.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class TaiLieuController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DataContext _dataContext;
        private readonly ILogger<TaiLieuController> _logger;
        public TaiLieuController(ILogger<TaiLieuController> logger, DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("QuanLyTaiLieu")]
        public IActionResult Index()
        {
            var tailieu = _dataContext.TaiLieu.Include("HocKy").Include("Khoa").ToList();
            return View(tailieu);
        }

		[Route("ThemTaiLieu")]
		[HttpGet]
		public IActionResult ThemTaiLieu()
		{
			ViewBag.HocKyId = new SelectList(_dataContext.HocKy.ToList(), "Id", "TenHK");
			ViewBag.KhoaId = new SelectList(_dataContext.Khoa.ToList(), "Id", "TenKhoa");
			return View();
		}

        [Route("ThemTaiLieu")]
        [HttpPost]
        public IActionResult ThemTaiLieu(TaiLieuDTO tailieu)
        {
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(tailieu.HinhTaiLieu!.FileName);
            string imageFullPath = Path.Combine(_webHostEnvironment.WebRootPath, "LayoutAdmin/img/tailieu/" + newFileName);
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                tailieu.HinhTaiLieu.CopyTo(stream);
            }
            TaiLieuModel tl = new TaiLieuModel()
            {
                TenTaiLieu = tailieu.TenTaiLieu,
                Gia = tailieu.Gia,
                HinhTaiLieu = newFileName,
                HocKyId = tailieu.HocKyId,
                KhoaId = tailieu.KhoaId
            };
            _dataContext.TaiLieu.Add(tl);
            _dataContext.SaveChanges();
            return RedirectToAction("QuanLyTaiLieu", "Admin");
        }

        [Route("SuaTaiLieu")]
        [HttpGet]
        public IActionResult SuaTaiLieu(int id)
        {
            ViewBag.HocKyId = new SelectList(_dataContext.HocKy.ToList(), "Id", "TenHK");
            ViewBag.KhoaId = new SelectList(_dataContext.Khoa.ToList(), "Id", "TenKhoa");
            var tailieu = _dataContext.TaiLieu.Where(x => x.Id == id).FirstOrDefault();

            var tl = new TaiLieuDTO
            {
                TenTaiLieu = tailieu.TenTaiLieu,
                Gia = tailieu.Gia,
                HocKyId = tailieu.HocKyId,
                KhoaId = tailieu.KhoaId
            };
            ViewBag.TaiLieuID = tailieu.Id;
            ViewBag.HinhTaiLieu = tailieu.HinhTaiLieu;
            return View(tl);
        }

        [Route("SuaTaiLieu")]
        [HttpPost]
        public IActionResult SuaTaiLieu(int id, TaiLieuDTO tailieu)
        {
            var tl = _dataContext.TaiLieu.Where(x => x.Id == id).FirstOrDefault();

            if (tailieu.HinhTaiLieu != null)
            {
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(tailieu.HinhTaiLieu!.FileName);
                string imageFullPath = Path.Combine(_webHostEnvironment.WebRootPath, "LayoutAdmin/img/tailieu/" + newFileName);

                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    tailieu.HinhTaiLieu.CopyTo(stream);
                }
                string oldImageFullPath = Path.Combine(_webHostEnvironment.WebRootPath, "LayoutAdmin/img/tailieu/" + tl.HinhTaiLieu);
                if (System.IO.File.Exists(oldImageFullPath))
                {
                    System.IO.File.Delete(oldImageFullPath);
                }

                tl.TenTaiLieu = tailieu.TenTaiLieu;
                tl.Gia = tailieu.Gia;
                tl.HinhTaiLieu = newFileName;
                tl.HocKyId = tailieu.HocKyId;
                tl.KhoaId = tailieu.KhoaId;
                _dataContext.TaiLieu.Update(tl);
            }
            else
            {
                tl.TenTaiLieu = tailieu.TenTaiLieu;
                tl.Gia = tailieu.Gia;
                tl.HinhTaiLieu = tl.HinhTaiLieu;
                tl.HocKyId = tailieu.HocKyId;
                tl.KhoaId = tailieu.KhoaId;
                _dataContext.TaiLieu.Update(tl);
            }

            _dataContext.SaveChanges();
            return RedirectToAction("QuanLyTaiLieu", "Admin");
        }

        [Route("XoaTaiLieu")]
        [HttpGet]
        public IActionResult XoaTaiLieu(int id)
        {
            TempData["Message"] = "";
            var tailieu = _dataContext.TaiLieu.Find(id);
          
                string imageFullPath = Path.Combine(_webHostEnvironment.WebRootPath,
                    "LayoutAdmin/img/tailieu/" + tailieu.HinhTaiLieu);

                if (System.IO.File.Exists(imageFullPath))
                {
                    System.IO.File.Delete(imageFullPath);
                }

            _dataContext.TaiLieu.Remove(tailieu);
                _dataContext.SaveChanges();
                TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("QuanLyTaiLieu", "Admin");
        }
    }
}
