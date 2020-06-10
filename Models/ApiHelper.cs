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
  }
}