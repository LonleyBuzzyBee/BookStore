using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookstore.Models;

namespace bookstore.Controllers
{
  public class BooksController : Controller
  {
    public IActionResult Index()
    {
      var allBooks = Book.GetBooks();
      return View(allBooks);
    }

   
  }
}