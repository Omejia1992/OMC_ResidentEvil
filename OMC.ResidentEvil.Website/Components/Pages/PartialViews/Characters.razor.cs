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
        bool isEditActive = false;
        CharacterClass _characterClass = new CharacterClass();

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
               await Get(); 
            }
            else if (_selectedValue == CharacterType.Main) 
            {
               await GetMain();
            }
            else 
            { 
               await GetSecondary();
            }
        }

        /// <summary>
        /// Gets the Entire list of Characters
        /// </summary>
        protected async Task Get(){

            characters = _characterClass.Get();
            await grid.Reload();
        }

        /// <summary>
        /// Gets the Data on the Selected Character
        /// </summary>
        protected async Task Get(int id) {
            character = _characterClass.Get(id);
            character.Game = new VideogameDTO ();
            await Get();
        }

        /// <summary>
        /// Gets the List of Main Characters
        /// </summary>
        protected async Task GetMain() {

            MainCharacterClass _mainCharacterClass = new MainCharacterClass();
            characters = _mainCharacterClass.GetMain();
            await grid.Reload();
        }

        /// <summary>
        /// Gets the List of Secondary Characters
        /// </summary>
        /// <returns></returns>
        protected async Task GetSecondary() {
            SideCharacterClass _sideCharacterClass = new SideCharacterClass();
            characters = _sideCharacterClass.GetSecondary();
            await grid.Reload();
        }

        protected async Task Add() {

            _characterClass.Add(character);
            await Get();
            character = new CharacterDTO{Game = new VideogameDTO()};               
        }

        protected async Task Edit(int id) {
            isEditActive = true;
            await Get(id);
        }

        protected async Task Update() {

            _characterClass.Update(character);
            isEditActive = false;
            await Get();
            character = new CharacterDTO { Game = new VideogameDTO() };
        }

        protected async Task Delete(int id)
        {
            _characterClass.Delete(id);
            await Get();
        }
    }
}
