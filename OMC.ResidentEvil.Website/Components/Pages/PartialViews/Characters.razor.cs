using Microsoft.EntityFrameworkCore;
using OMC.ResidentEvil.BackEnd.Classes;
using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Models;
using System.Diagnostics;
using Radzen.Blazor;


namespace OMC.ResidentEvil.Website.Components.Pages.PartialViews
{
    public partial class Characters
    {
        RadzenDataGrid<CharacterDTO> grid = new RadzenDataGrid<CharacterDTO>();
        List<CharacterDTO> characters = new List<CharacterDTO>();

        List<VideogameDTO> games = new List<VideogameDTO>();
        CharacterDTO character = new CharacterDTO{Game = new VideogameDTO()};

        protected override void OnInitialized(){

            games = VideogameClass.Get();
            Get();             
        }

        protected async Task Get(){

            characters = CharacterClass.Get();
            await grid.Reload();
        }

        protected async Task Add() {

            CharacterClass.Add(character);
            Get();
            character = new CharacterDTO{Game = new VideogameDTO()};               
        }

        protected async Task Delete(int id) { 
            
            CharacterClass.Delete(id);
            Get();
        }    
    }
}
