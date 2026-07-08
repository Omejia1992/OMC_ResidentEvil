using OMC.ResidentEvil.BackEnd.DTOS;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Services
{
    public class HttpService
    {
        private readonly HttpClient _http;
        public HttpService(IHttpClientFactory factory) {
            _http = factory.CreateClient("MyApi");
        }
        public async Task<List<VideogameDTO>> GetGamesAsync()
        {
            // If BaseAddress is set to "https://localhost:7226/" you only need the relative path:
            var response = await _http.GetFromJsonAsync<List<VideogameDTO>>("Videogames/games");
            ///response.EnsureSuccessStatusCode(); // throws if not 2xx
            return response;
        }

        public async Task<List<CharacterDTO>> GetCharactersAsync()
        {
            // If BaseAddress is set to "https://localhost:7226/" you only need the relative path:
            var response = await _http.GetFromJsonAsync<List<CharacterDTO>>("Videogames/characters");
            ///response.EnsureSuccessStatusCode(); // throws if not 2xx
            return response;
        }

        public async Task<List<GunDTO>> GetGunsAsync()
        {
            // If BaseAddress is set to "https://localhost:7226/" you only need the relative path:
            var response = await _http.GetFromJsonAsync<List<GunDTO>>("Videogames/guns");
            ///response.EnsureSuccessStatusCode(); // throws if not 2xx
            return response;
        }
    }
}
