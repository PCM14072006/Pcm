using Microsoft.AspNetCore.Mvc;
using PcmLesson04.Models;

namespace PcmLesson04.Controllers
{
    public class BookController1 : Controller
    {
        //khởi tạo lớp book
        protected Book book = new Book();
        public IActionResult Index()
        {
            // danh sách genres convert SelectListItem để hiển thị trên combobox
            ViewBag.authors = book.Authors; // truyền dữ liệu SelectListItem qua view
            ViewBag.genres = book.Genres;   // truyền dữ liệu SelectListItem qua view
            var books = book.GetBookList();
            return View(books); // truyền dữ liệu qua viw dưới dạng tham số
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.authors = book.Authors; // truyền dữ liệu SelectListItem qua view
            ViewBag.genres = book.Genres;   // truyền dữ liệu SelectListItem qua view
            Book model = new Book();
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.authors = book.Authors; // truyền dữ liệu SelectListItem qua view
            ViewBag.genres = book.Genres;   // truyền dữ liệu SelectListItem qua view
            Book model = book.GetBookById(id); // lấy dữ liệu một cuốn sách theo id
            return View(model);
        }
    }
}
    