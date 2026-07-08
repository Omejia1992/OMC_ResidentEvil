using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client;
using OMC.ResidentEvil.BackEnd.Classes;
using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Services;
using Radzen.Blazor;
using System.Diagnostics;

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
          
            VideogameClass.Add(game);
            await Get();
                       
        }

        protected async Task Edit(int id) {
          isEditActive = true;
          game = VideogameClass.Get(id);
        }

        protected async Task Update() {
            VideogameClass.Update(game);
            isEditActive = false;           
            await Get();
        }

        protected async Task Delete(int id) {

            VideogameClass.Delete(id);
            await Get();            
        }
        protected async Task ViewCharacters(int id) {

            characters = _characterClass.GetByVideogame(id);
           await chargrid.Reload();
        }
    }
}
