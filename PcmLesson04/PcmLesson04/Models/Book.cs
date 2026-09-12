using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace PcmLesson04.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        // Danh sách các cuốn sách
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                // Cuốn 1
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b1.jpg",
                    Price = 500000,
                    Sumary = "Truyện ngắn của Nam Cao",
                    TotalPage = 250
                },

                // Cuốn 2
                new Book()
                {
                    Id = 2,
                    Title = "Lão Hạc",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b3.jpg",
                    Price = 100000,
                    Sumary = "Truyện ngắn của Nam Cao",
                    TotalPage = 150
                },

                // Cuốn 3
                new Book()
                {
                    Id = 3,
                    Title = "Đường xưa mây trắng",
                    AuthorId = 2,
                    GenreId = 2,
                    Image = "/images/products/b4.jpg",
                    Price = 200000,
                    Sumary = "Tác phẩm của Thích Nhất Hạnh",
                    TotalPage = 500
                },

                // Cuốn 4
                new Book()
                {
                    Id = 4,
                    Title = "Dế Mèn Phiêu Lưu Ký",
                    AuthorId = 3,
                    GenreId = 1,
                    Image = "/images/products/b2.jpg",
                    Price = 120000,
                    Sumary = "Tác phẩm của Tô Hoài",
                    TotalPage = 200
                }
            };

            return books;
        }

        // chi tiết một cuốn sách theo id (nhớ using System.Linq)
        public Book GetBookById(int id)
        {
            Book book = this.GetBookList()
                              .FirstOrDefault(b => b.Id == id);

            return book;
        }
// SelectListItem Authors (using Microsoft.AspNetCore.Mvc.Rendering)
public List<SelectListItem> Authors { get; } = new List<SelectListItem>
{
    new SelectListItem {Value="1", Text="Nam cao"},
    new SelectListItem {Value="2", Text="Ngô Tất Tố"},
    new SelectListItem {Value="3", Text="Adamkhoom"},
    new SelectListItem {Value="4", Text="Thiền sư Thích Nhất Hạnh"}
};

        // SelectListItem Genres
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
{
    new SelectListItem{Value="1", Text="Truyện tranh"},
    new SelectListItem{Value="2", Text="Văn học đương đại"},
    new SelectListItem{Value="3", Text="Phật học phổ thông"},
    new SelectListItem{Value="4", Text="Truyện cười"}
};
    }
}