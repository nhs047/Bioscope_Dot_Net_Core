using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;

namespace Bioscope.App.Helpers
{
  public class HttpService
  {
    public HttpClient Api { get; }
    public HttpService(HttpClient client, IOptions<ApiConfig> config)
    {
      client.BaseAddress = new Uri(config.Value.BaseAddress);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json")
      );
      Api = client;
    }
  }
}