using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using OMC.ResidentEvil.BackEnd.Classes;
using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Enums;
using OMC.ResidentEvil.BackEnd.Models;
using Radzen.Blazor;
using System.Diagnostics;


namespace OMC.ResidentEvil.Website.Components.Pages.PartialViews
{
    public partial class Characters
    {
        CharacterType _selectedValue = 0;
        Dictionary<int, string> cOptions = new Dictionary<int, string>();

        RadzenDataGrid<CharacterDTO> grid = new RadzenDataGrid<CharacterDTO>();
        List<CharacterDTO> characters = new List<CharacterDTO>();
        List<VideogameDTO> games = new List<VideogameDTO>();
        CharacterDTO character = new CharacterDTO{Game = new VideogameDTO()};

        protected override void OnInitialized(){

            foreach (CharacterType type in Enum.GetValues(typeof(CharacterType)))
            {
                cOptions.Add((int)type, type.ToString());
            }

            games = VideogameClass.Get();
            Get();             
        }

        protected async Task selectedCharacter(ChangeEventArgs e)
        {
            _selectedValue = (CharacterType)System.Convert.ToInt32(e.Value);

            if (_selectedValue == (CharacterType.All))
            {
                Get(); 
            }
            else if (_selectedValue == CharacterType.Main) 
            {
                GetMain();
            }
            else 
            { 
                GetSecondary();
            }
        }

        protected async Task Get(){

            characters = CharacterClass.Get();
            await grid.Reload();
        }

        protected async Task GetMain() {

            characters = MainCharacterClass.GetMain();
            await grid.Reload();
        }

        protected async Task GetSecondary() {
            characters = SideCharacterClass.GetSecondary();
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
