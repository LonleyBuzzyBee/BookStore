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

    public IActionResult Details(int id)
    {
      var book = Book.GetDetails(id);
      return View(book);
    }

    public IActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public IActionResult Create(Book book)
    {
      Book.Post(book);
      return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
      Book.Delete(id);
      return RedirectToAction("Index");
    }
  }
}