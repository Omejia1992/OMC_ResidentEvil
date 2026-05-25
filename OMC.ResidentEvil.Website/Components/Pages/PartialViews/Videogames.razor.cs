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
        List<VideogameDTO> games = new List<VideogameDTO>();

        VideogameDTO game = new VideogameDTO();

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
            Get();
                       
        }

        protected async Task Delete(int id) {

            VideogameClass.Delete(id);
            Get();            
        }
    }
}
