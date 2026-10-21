using Microsoft.AspNetCore.Mvc;
using PcmTh01.Models;

namespace PcmTh01.ViewComponents
{
    public class LeftMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Dữ liệu menu (tạm thời tạo cứng, sau có thể lấy từ database)
            var items = new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Dashboard", Link = "/" },
                new MenuItem { Id = 2, Name = "Sinh viên", Link = "/Student" }
            };

            return View(items);
        }
    }
}