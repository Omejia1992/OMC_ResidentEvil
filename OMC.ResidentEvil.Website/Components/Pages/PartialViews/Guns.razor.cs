using Microsoft.EntityFrameworkCore;
using OMC.ResidentEvil.BackEnd.Classes;
using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Models;
using Radzen.Blazor;
using System.Diagnostics;

namespace OMC.ResidentEvil.Website.Components.Pages.PartialViews
{
    public partial class Guns
    {
        RadzenDataGrid<GunDTO> grid = new RadzenDataGrid<GunDTO>();
        List<GunDTO> guns = new List<GunDTO>();

        List<VideogameDTO> games = new List<VideogameDTO>();
        GunDTO gun = new GunDTO{ Game = new VideogameDTO()};
       
        protected override void OnInitialized(){

            games = VideogameClass.Get();
            Get();
        }

        protected async Task Get()
        {
            guns = GunClass.Get();
            await grid.Reload();
        }

        protected async Task Add() {

            GunClass.Add(gun);
            Get();
            gun = new GunDTO { Game = new VideogameDTO() };
        }

        protected async Task Delete(int id)
        {
            GunClass.Delete(id);
            Get();
        }
    }
}
 