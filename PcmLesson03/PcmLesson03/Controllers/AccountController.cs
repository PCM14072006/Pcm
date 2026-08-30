using Microsoft.AspNetCore.Mvc;
using PcmLesson03.Models;
using System.Linq;

namespace PcmLesson03.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,
                    Name = "Công Minh",
                    Email = "Minh@gmail.com",
                    Phone = "04426342622",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/01.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2006, 07, 14)
                },

                new Account()
                {
                    Id = 2,
                    Name = "Công Anh",
                    Email = "Anh@gmail.com",
                    Phone = "033336874",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/02.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2002, 07, 12)
                },

                new Account()
                {
                    Id = 3,
                    Name = "Văn Đông",
                    Email = "Dong@gmail.com",
                    Phone = "0657348364",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/03.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2002, 03, 07)
                }
            };

            ViewBag.Accounts = accounts;

            return View();
        }


        // Định nghĩa URL và Name cho Action
        [Route("ho-so-cua-toi", Name = "profile")]
        public IActionResult Profile(int id)
        {
            // Danh sách Account giống trên Action Index
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,
                    Name = "Công Minh",
                    Email = "Minh@gmail.com",
                    Phone = "04426342622",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/01.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2006, 07, 14)
                },

                new Account()
                {
                    Id = 2,
                    Name = "Công Anh",
                    Email = "Anh@gmail.com",
                    Phone = "033336874",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/02.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2002, 07, 12)
                },

                new Account()
                {
                    Id = 3,
                    Name = "Văn Đông",
                    Email = "Dong@gmail.com",
                    Phone = "0657348364",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/03.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2002, 03, 07)
                }
            };

            // Tìm Account theo id
            Account account = accounts.FirstOrDefault(ac => ac.Id == id);

            // Gửi Account sang View
            ViewBag.account = account;

            return View();
        }
    }
}