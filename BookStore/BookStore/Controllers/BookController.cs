using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.CodeAnalysis.Operations;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("book-details /{id}",Name ="BookDetailsRoute")]
        
        public async Task<ViewResult> GetBook(int id)
        {
             
            var data = await _bookRepository.GetBookById(id);
            
            return View(data);
        }

        public List<BookModel> SearchBooks(string BookName,string AuthorName)
        {

            return _bookRepository.SearchBooks(BookName,AuthorName); 
        }

        public ViewResult AddNewBook(bool isSucess = false,int bookId=0)
        {
            ViewBag.IsSucess = isSucess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
           int id = await _bookRepository.AddNewBook(bookModel);

            if (ModelState.IsValid)
            {

                if (id > 0)
                {
                    //return RedirectToAction("AddNewBook");
                    return RedirectToAction(nameof(AddNewBook), new { isSucess = true, bookId = id });

                }


            }

            //ViewBag.IsSucess = false;
            //ViewBag.BookId = 0;

            ModelState.AddModelError("", "this is my custom error message");

            return View();
        }
    }
}