using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Classes
{
    public class SideCharacterClass : CharacterClass
    {
       static dbContext dbContext = new dbContext();

        public List<CharacterDTO> GetSecondary()
        {
            List<CharacterDTO> characters = new List<CharacterDTO>();

            try
            {
                characters = Get();
                characters = characters.Where(c => c.IsMain == false).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return characters;
        }

    }
}
