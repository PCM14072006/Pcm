using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PcmTh01.Models;

namespace PcmTh01.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> listStudents = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Nguyen Van Dong",
                Email = "nguyenvandong@example.com",
                Password = "123456",
                Branch = Branch.IT,
                Gender = Gender.Male,
                IsRegular = true,
                Address = "123 Main St",
                DateOfBorth = new DateTime(2000, 1, 1)
            },
            new Student
            {
                Id = 2,
                Name = "Tran Thi Lan",
                Email = "tranthilan@example.com",
                Password = "123456",
                Branch = Branch.IT,
                Gender = Gender.Female,
                IsRegular = true,
                Address = "456 Oak Ave",
                DateOfBorth = new DateTime(2000, 5, 15)
            },
            new Student
            {
                Id = 3,
                Name = "Le Van An",
                Email = "levanan@example.com",
                Password = "123456",
                Branch = Branch.IT,
                Gender = Gender.Male,
                IsRegular = true,
                Address = "789 Pine Rd",
                DateOfBorth = new DateTime(2000, 10, 10)
            },
            new Student
            {
                Id = 4,
                Name = "Pham Thi Mai",
                Email = "phamthimai@example.com",
                Password = "123456",
                Branch = Branch.IT,
                Gender = Gender.Female,
                IsRegular = true,
                Address = "101 Maple Dr",
                DateOfBorth = new DateTime(2000, 8, 20)
            }
        };

        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadFormData();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student s, IFormFile? imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

                string extension = Path.GetExtension(imageFile.FileName)
                    .ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError(
                        "Image",
                        "Chỉ chấp nhận ảnh JPG, JPEG hoặc PNG."
                    );
                }
                else if (imageFile.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError(
                        "Image",
                        "Ảnh không được vượt quá 2 MB."
                    );
                }
                else
                {
                    string folder = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "images"
                    );

                    Directory.CreateDirectory(folder);

                    string fileName = Guid.NewGuid().ToString("N") + extension;
                    string filePath = Path.Combine(folder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    s.Image = fileName;
                }
            }

            if (!ModelState.IsValid)
            {
                LoadFormData();
                return View(s);
            }

            s.Id = listStudents.Count == 0
                ? 1
                : listStudents.Max(x => x.Id) + 1;

            listStudents.Add(s);

            return RedirectToAction("Index");
        }

        private void LoadFormData()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender))
                .Cast<Gender>()
                .ToList();

            ViewBag.AllBranches = new List<SelectListItem>
            {
                new SelectListItem { Text = "IT", Value = "IT" },
                new SelectListItem { Text = "BE", Value = "BE" },
                new SelectListItem { Text = "CE", Value = "CE" },
                new SelectListItem { Text = "EE", Value = "EE" }
            };
        }
    }
}