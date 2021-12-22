using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Weelo.Application.Owner.Queries;
using Weelo.Application.Property.Queries;
using Xunit;

namespace Weelo.Api.Tests;


public class PropertyImageControllerTest
{

    IntegrationTestBuilder _builder;
    HttpClient _client = default!;

    public PropertyImageControllerTest()
    {
         _builder = new IntegrationTestBuilder();
        _client = _builder.CreateClient();
    }

    [Fact]
    public async Task PostPropertyImageError()
    {
        var postContent = new Weelo.Application.PropertyImagen.Commands.PropertyImageCreateCommand
        (
            Guid.NewGuid(), Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="), true, "file.png"
        );
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRGFuaWVsIiwiVXNlciI6ImRnaXJhbGRvIiwibmJmIjoxNjQwMTI3OTYwLCJleHAiOjE2NDUzMTE5NjAsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMC8iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAvIn0.TEaceaDgHqEDRiNGWl9WTO_63sqPz8IybgCMNtwNiEc");
        var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(postContent), System.Text.Encoding.UTF8, "text/json");
        var c = await _client.PostAsync("api/PropertyImage", content);
        Assert.Equal(HttpStatusCode.BadRequest, c.StatusCode);
    }

}