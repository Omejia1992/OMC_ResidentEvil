using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Helpers
{
    internal class CharacterHelper
    {
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
    }
}
