using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class HomeController:Controller
    {
        [ViewData]
        public string  CustomProperty { get; set; }
        
        [ViewData]
        public string  Title { get; set; }

        [ViewData]
        public BookModel Book { get; set; }
        public ViewResult Index()
        {
            CustomProperty = "Custom value";
            Title = "Home page from controller ";

            Book = new BookModel() { Id = 1, Title = "Asp.Net core" };

            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
