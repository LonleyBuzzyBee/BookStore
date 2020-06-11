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
      ViewBag.Page = 2;
      var allBooks = Book.GetBooks();
      return View(allBooks);
    }
    public IActionResult Page(string page)
    {
      Console.WriteLine($"------------{page}-----------");
      Console.WriteLine($"========>{page}<========");
      var allBooks = Book.GetBooks(page);
      ViewBag.Page = (int.Parse(page)+1).ToString(); 
      return View("Index", allBooks);
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
      Book.Put(book);
      return RedirectToAction("Index");
    }
    public IActionResult Edit()
    {
      return View();
    }
    [HttpPost]
    public IActionResult Edit(int id,Book book)
  {
      book.BookId = id;
      Book.Put(book);
      return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
      Book.Delete(id);
      return RedirectToAction("Index");
    }
  }
}