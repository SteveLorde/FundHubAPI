using System.Net.Http.Json;
using FundHubAPI.Data.Models;

namespace TestProject1;

public class ControllersTest
{
    private HttpClient _httpClient = new HttpClient();
    
    [Fact]
    public async void GetProjectsTest()
    {
        var response = await _httpClient.GetAsync("").Result.Content.ReadFromJsonAsync<List<Project>>();
        if (response.Count > 0)
        {
            foreach (var project in response)
            {
                Console.WriteLine(project);

            }
        }
    }
    
    
    
}