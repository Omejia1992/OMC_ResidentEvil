using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Helpers
{
    internal class CharacterHelper
    {
        /// <summary>
        /// Sets the Character from db to a DTO Type 
        /// </summary>
        public CharacterDTO SetCharacter(Character item)
        {
            try
            {
                CharacterDTO character = new CharacterDTO
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    MiddleName = item.MiddleName,
                    LastName = item.LastName,
                    IsMain = item.IsMain,

                    Games = item.VideogameCharacters.Select(vc => new VideogameDTO
                    {
                        Id = vc.IdGameNavigation.Id,
                        Name = vc.IdGameNavigation.Name,
                        Year = vc.IdGameNavigation.Year
                    }).ToList(),

                    GamesName = StringHelper.Combiner(item.VideogameCharacters.Select(vc => vc.IdGameNavigation.Name).ToList())
                };
                return character;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new CharacterDTO();
            }
        }

        /// <summary>
        /// Sets the CharacterDTO to a Character Type
        /// </summary>
        public Character SetCharacter(CharacterDTO character)
        {
            Character lcharacter = new Character();
            try
            {
                lcharacter = new Character
                {
                    Id = character.Id,
                    FirstName = character.FirstName,
                    MiddleName = character.MiddleName,
                    LastName = character.LastName,
                    IsMain = character.IsMain
                };
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
            return lcharacter;
        }
    }
}
