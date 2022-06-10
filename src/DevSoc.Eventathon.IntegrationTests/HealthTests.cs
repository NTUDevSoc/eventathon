using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DevSoc.Eventathon.IntegrationTests;

public class HealthTests : IClassFixture<EventathonServiceFixture>
{
    private readonly HttpClient _client;

    public HealthTests(EventathonServiceFixture fixture)
    {
        _client = fixture.CreateClient();
    }
    
    [Fact]
    public async Task WhenTheServiceIsLive_ThenTheHealthEndpointReturnsHealthy()
    {
        var result = await _client.GetAsync("/api/health");
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }
}