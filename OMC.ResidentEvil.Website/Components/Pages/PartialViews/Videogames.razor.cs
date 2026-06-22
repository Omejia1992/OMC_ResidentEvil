using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Classes;
using Radzen.Blazor;
using System.Diagnostics;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace OMC.ResidentEvil.Website.Components.Pages.PartialViews
{
    public partial class Videogames
    {
        RadzenDataGrid<VideogameDTO> grid = new RadzenDataGrid<VideogameDTO>();
        RadzenDataGrid<CharacterDTO> chargrid = new RadzenDataGrid<CharacterDTO>();

        List<VideogameDTO> games = new List<VideogameDTO>();
        List<CharacterDTO> characters = new List<CharacterDTO>();
        
        VideogameDTO game = new VideogameDTO();
        CharacterClass _characterClass = new CharacterClass();

        protected override void OnInitialized(){
           
             Get();
        }

        protected async Task Get()
        {
            games = VideogameClass.Get();
            await grid.Reload();
            game = new VideogameDTO();
        }

        protected async Task Add() {
          
            VideogameClass.Add(game);
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
