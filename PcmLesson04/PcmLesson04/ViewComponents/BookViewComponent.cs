using Microsoft.AspNetCore.Mvc;
using PcmLesson04.Models;

namespace PcmLesson04.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        protected Book book = new Book();

        public IViewComponentResult Invoke()
        {
            var books = book.GetBookList();

            return View(books);
        }
    }
}