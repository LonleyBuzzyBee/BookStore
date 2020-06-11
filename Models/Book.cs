using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace bookstore.Models
{
  public class Book
  {
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Condition { get; set; }
    public bool Available { get; set; }


    public static List<Book> GetBooks()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Book> bookList = JsonConvert.DeserializeObject<List<Book>>(jsonResponse.ToString());
      return bookList;
    }
     public static List<Book> GetBooks(string page)
    { 
      var apiCallTask = ApiHelper.GetPage(page);
      var result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Book> bookList = JsonConvert.DeserializeObject<List<Book>>(jsonResponse.ToString());
      return bookList;
    }
    public static Book GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Book book = JsonConvert.DeserializeObject<Book>(jsonResponse.ToString());

      return book;
    }
    public static void Post(Book book)
    {
      string jsonBook = JsonConvert.SerializeObject(book);
      var apiCallTask = ApiHelper.Post(jsonBook);
    }

    public static void Put(Book book)
    {
      string jsonBook = JsonConvert.SerializeObject(book);
      var apiCallTask = ApiHelper.Put(book.BookId, jsonBook);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}