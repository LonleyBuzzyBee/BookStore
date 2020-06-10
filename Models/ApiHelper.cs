using System.Threading.Tasks;
using RestSharp;
using System;

namespace bookstore.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5006/api");
      RestRequest request = new RestRequest($"books", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5006/api");
      RestRequest request = new RestRequest($"books/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newBook)
    {
      RestClient client = new RestClient("http://localhost:5006/api");
      RestRequest request = new RestRequest($"books", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      Console.WriteLine(newBook);
      request.AddJsonBody(newBook);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task Put(int id, string newBook)
    {
      RestClient client = new RestClient("http://localhost:5006/api");
      RestRequest request = new RestRequest($"books/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newBook);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5006/api");
      RestRequest request = new RestRequest($"books/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "appliction/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}