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


public class PropertyControllerTest
{

    IntegrationTestBuilder _builder;
    HttpClient _client = default!;

    public PropertyControllerTest()
    {
         _builder = new IntegrationTestBuilder();
        _client = _builder.CreateClient();
    }


    [Fact]
    public async Task PostPropertyImageSuccess()
    {
        var postContent = new Weelo.Application.Property.Commands.PropertyCreateCommand
        (          
            "karlar", "doe",4550995, 765, 2020, new OwnerDto { Address = "54456", Name = "454", Birthday = DateTime.Now, Photo = ""}
        );
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRGFuaWVsIiwiVXNlciI6ImRnaXJhbGRvIiwibmJmIjoxNjQwMTI3OTYwLCJleHAiOjE2NDUzMTE5NjAsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMC8iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAvIn0.TEaceaDgHqEDRiNGWl9WTO_63sqPz8IybgCMNtwNiEc");
        var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(postContent), System.Text.Encoding.UTF8 , "text/json" );
        var c = await _client.PostAsync("api/Property", content);
        c.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, c.StatusCode);
    }


    [Fact]
    public async Task PostPropertyImageError()
    {
        var putContent = new Weelo.Application.Property.Commands.PropertyUpdateCommand
        (
            Guid.Parse("FCD2C07D-2214-4904-63D1-08D9C437C77C"), "karlar", "doe", 4550995, 765, 2020, new OwnerDto { Id= Guid.Parse("C3ED7A63-EF02-4B71-994D-996480EFD155"), Address = "54456", Name = "454", Birthday = DateTime.Now, Photo = "" }
        );

        _client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRGFuaWVsIiwiVXNlciI6ImRnaXJhbGRvIiwibmJmIjoxNjQwMTI3OTYwLCJleHAiOjE2NDUzMTE5NjAsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMC8iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAvIn0.TEaceaDgHqEDRiNGWl9WTO_63sqPz8IybgCMNtwNiEc");
        var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(putContent), System.Text.Encoding.UTF8, "application/json");
        var c = await _client.PutAsync("api/Property", content);
        Assert.Equal(HttpStatusCode.InternalServerError, c.StatusCode);
    }
}