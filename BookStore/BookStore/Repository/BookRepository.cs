using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value :0,
                UpdatedOn = DateTime.UtcNow

            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks?.Any()==true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author=book.Author,
                        Category = book.Category,
                        Description=book.Description,
                        Id=book.Id,
                        Language=book.Language,
                        Title=book.Title,
                        TotalPages=book.TotalPages

                    });
                }
            }
            
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);

            //_context.Books.Where(x=>x.Id==id).FirstOrDefaultAsync();

            if (book != null)
            {
                var bookDetails = new BookModel()
                {

                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages


                };

                return bookDetails;
            }

            return null;
        }

        public List<BookModel> SearchBooks(string title,string author)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(author)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1 ,Title="Peer-kaml",Author="umera",Description="This is description of....",Category="Adab",Language="Urdu",TotalPages=123},
                new BookModel(){Id=2 ,Title="Talsah",Author="Mumtaz Mufti",Description="This is description of....",Category="Adab",Language="Urdu",TotalPages=323},
                new BookModel(){Id=3 ,Title="Raja kidh",Author="Bano Qudsia",Description="This is description of....",Category="Adab",Language="Urdu",TotalPages=523},
                new BookModel(){Id=4 ,Title="Jannath k Pattay",Author="Umera Ahmed",Description="This is description of....",Category="Adab",Language="Urdu",TotalPages=623},
                new BookModel(){Id=5 ,Title="Isaq ka Ann",Author="Umera Ahmed",Description="This is description of....",Category="Adab",Language="Urdu",TotalPages=823}

            };
             
        }
    }
}
