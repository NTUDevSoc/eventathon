using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DevSoc.Eventathon.IntegrationTests;

public class EventathonServiceFixture : IAsyncDisposable
{
    private WebApplicationFactory<Program> _webApplication;

    public EventathonServiceFixture()
    {
        _webApplication = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                // mock out services here
            });
    }

    public HttpClient CreateClient() => _webApplication.CreateClient();

    public ValueTask DisposeAsync() => ValueTask.CompletedTask;
}