using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

using OMC.ResidentEvil.BackEnd.Classes;
using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Enums;
using OMC.ResidentEvil.BackEnd.Helpers;
using OMC.ResidentEvil.BackEnd.Models;
using OMC.ResidentEvil.BackEnd.Services;

using Radzen.Blazor;
using System.Diagnostics;

namespace OMC.ResidentEvil.Website.Components.Pages.PartialViews
{
    public partial class Guns
    {
        [Inject]
        private HttpService _httpService { get; set; } = default!;

        RadzenDataGrid<GunDTO> grid = new RadzenDataGrid<GunDTO>();
        List<GunDTO> guns = new List<GunDTO>();

        List<VideogameDTO> games = new List<VideogameDTO>();
        GunDTO gun = new GunDTO{ Game = new VideogameDTO()};
        bool isEditActive = false;
        protected override async Task OnInitializedAsync(){

            games = VideogameClass.Get();
            await Get();
        }

        protected async Task Get()
        {
            guns = await _httpService.GetGunsAsync();
            await grid.Reload();
        }

        protected async Task Add() {

            await _httpService.AddGun(gun.Game.Id, gun.Name);
            await Get();
            gun = new GunDTO { Game = new VideogameDTO() };
        }

        protected async Task Edit(int id)
        {
            isEditActive = true;
            gun = GunClass.Get(id);
        }

        protected async Task Update()
        {
            GunClass.Update(gun);
            gun = new GunDTO { Game = new VideogameDTO() };
            isEditActive = false;
            await Get();
        }

        protected async Task Delete(int id)
        {
            string key = StringHelper.GetDescription(ApiKeys.Guns);
           await _httpService.Delete(id, key);
           await Get();
        }
    }
}
 