using System.Threading.Tasks;
using RestSharp;

namespace bookstore.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5006/api");
      RestRequest request = new RestRequest($"Books", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
          RestClient client = new RestClient("http://localhost:5006/api");
      RestRequest request = new RestRequest($"Books/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newBook)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"books", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newBook);
      var response = await client.ExecuteTaskAsync(request);
    }
  
  }
}