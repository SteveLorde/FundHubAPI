using System.Net.Http.Json;
using FundHubAPI.Data.Models;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace FundHubAPI.Test;

public class ControllersTest
{
    
    private HttpClient _httpClient = new HttpClient();
    private ITestOutputHelper _outputHelper = new TestOutputHelper();
    
    [Fact]
    public async void GetProjectsTest()
    {
        var response = await _httpClient.GetAsync("http://localhost:5116/Projects/GetProjects").Result.Content.ReadFromJsonAsync<List<Project>>();
    }
    
    [Theory]
    [InlineData("")]
    public async void GetProjectTest(string projectid)
    {
        var response = await _httpClient.GetAsync("http://localhost:5116/Projects/GetProject/${projectid}").Result.Content.ReadFromJsonAsync<Project>();
        _outputHelper.WriteLine("response: ", response);

    }
    
    
    
}