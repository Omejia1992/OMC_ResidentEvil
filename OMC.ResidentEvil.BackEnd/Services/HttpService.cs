using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

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

        public async Task<List<CharacterDTO>> GetCharactersByGameAsync(int idGame)
        {
            // If BaseAddress is set to "https://localhost:7226/" you only need the relative path:
            var response = await _http.GetFromJsonAsync<List<CharacterDTO>>($"Videogames/characters/idGame={idGame}");
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

        public async Task<VideogameDTO> GetGame(int id){

            var response = await _http.GetFromJsonAsync<VideogameDTO>($"Videogames/game/{id}");
            
            return response;
        }

        public async Task AddGame(VideogameDTO game){

            try
            {
                    var json = JsonSerializer.Serialize(game);
                 var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _http.PostAsync($"Videogames/createGame", content);

                if (!response.IsSuccessStatusCode) 
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {errorBody}");
                }
                else
                {
                    Console.WriteLine("Videogame created successfully");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }            
        }

        public async Task AddCharacter(CharacterDTO character) {

            try
            {
                    var json = JsonSerializer.Serialize(character);
                 var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _http.PostAsync("Videogames/createCharacter", content);
                    
                if (!response.IsSuccessStatusCode)
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {errorBody}");
                }
                else
                {
                    Console.WriteLine("Character created successfully!");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public async Task AddGun(int idGame, string Name) {
            var response = await _http.PostAsync($"Videogames/createGun/idGame={idGame}, name={Name}", null);

        }
        public async Task Delete(int id, string key) {

            var response = await _http.DeleteAsync($"Videogames/delete{key}/id={id}");                     
        }

    }
}
