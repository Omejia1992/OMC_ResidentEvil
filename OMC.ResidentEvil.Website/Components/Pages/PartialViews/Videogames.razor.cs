using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client;

using OMC.ResidentEvil.BackEnd.Classes;
using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Services;
using OMC.ResidentEvil.BackEnd.Helpers;

using Radzen.Blazor;
using System.Diagnostics;
using OMC.ResidentEvil.BackEnd.Enums;

namespace OMC.ResidentEvil.Website.Components.Pages.PartialViews
{

    public partial class Videogames
    {
        [Inject]
        private HttpService _httpService { get; set; } = default!;

        RadzenDataGrid<VideogameDTO> grid = new RadzenDataGrid<VideogameDTO>();
        RadzenDataGrid<CharacterDTO> chargrid = new RadzenDataGrid<CharacterDTO>();

        List<VideogameDTO> games = new List<VideogameDTO>();
        List<CharacterDTO> characters = new List<CharacterDTO>();

        VideogameDTO game = new VideogameDTO();
        CharacterClass _characterClass = new CharacterClass();
        bool isEditActive = false;

        protected override async Task OnInitializedAsync(){
           
             await Get();
        }

        protected async Task Get()
        {
            games = await _httpService.GetGamesAsync();

            await grid.Reload();
            game = new VideogameDTO();
        }

        protected async Task Add() {

            await _httpService.AddGame(game);
            await Get();
                       
        }

        protected async Task Edit(int id) {
          isEditActive = true;
          game = await _httpService.GetGame(id);
        }

        protected async Task Update() {
            VideogameClass.Update(game);
            isEditActive = false;           
            await Get();
        }

        protected async Task Delete(int id) {

            string key = StringHelper.GetDescription(ApiKeys.Videogames);
            await _httpService.Delete(id, key);
            await Get();            
        }
        protected async Task ViewCharacters(int id) {

           characters = await _httpService.GetCharactersByGameAsync(id);
           await chargrid.Reload();
        }
    }
}
