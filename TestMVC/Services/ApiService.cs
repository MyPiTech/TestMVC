using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using TestMVC.Attributes;
using TestMVC.Dtos;

namespace TestMVC.Services
{
    public sealed class ApiService<R> where R : class
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ApiService<R>> _logger;
        private readonly string _apiClientBase;
        private readonly HttpClient _client;

        public ApiService(HttpClient httpClient, IWebHostEnvironment environment, ILogger<ApiService<R>> logger)
        {
            _client = httpClient;
            _environment = environment;
            _logger = logger;
            _apiClientBase = _environment.IsDevelopment() ? "https://localhost:7013/" : "https://swcoretestapi.azurewebsites.net/";
            _client.BaseAddress = new Uri(_apiClientBase);
        }

        public async Task<R[]?> GetAll(CancellationToken token = default)
        { 
            return await GetAll(null, token);
        }
            public async Task<R[]?> GetAll(Func<R>? newR = null, CancellationToken token = default)
        {
            try
            {
                var apiRoute = GetRoute(typeof(R), newR);

                R[]? response = await _client.GetFromJsonAsync<R[]>(apiRoute, new JsonSerializerOptions(JsonSerializerDefaults.Web), token);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting something fun to say: {Error}", ex);
            }
            return null;
        }

        public async Task<R?> GetOne(Func<R> newR, CancellationToken token = default)
        {
            try
            {
                var apiRoute = GetRoute(typeof(R), newR, true);

                R? response = await _client.GetFromJsonAsync<R>(apiRoute, new JsonSerializerOptions(JsonSerializerDefaults.Web), token);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
        private static string GetRoute(Type t, Func<R>? newR, bool appendDefault = false)
        {
            if (Attribute.GetCustomAttribute(t, typeof(ApiRouteAttribute)) is not ApiRouteAttribute apiRoute) 
                throw new Exception("Route not found.");

            var route = apiRoute.Route;

            if (newR != null) {
                var returnDto = newR();
                var props = t.GetProperties().Where(p => Attribute.IsDefined(p, typeof(ApiIdAttribute)));
                foreach (var prop in props)
                {
                    var idAttribute = prop.GetCustomAttribute<ApiIdAttribute>();
                    if (idAttribute != null)
                    {
                        var value = prop.GetValue(returnDto);
                        if (idAttribute.IsDefault && appendDefault)
                        {
                            route = $"{route}/{value}";
                        }
                        else 
                        {
                            var pattern = $@"{{{idAttribute.IdName}}}";
                            route = route.Replace(pattern, value?.ToString() ?? string.Empty);
                        }
                    }
                }
            }

            return route;
        }
    }
}
