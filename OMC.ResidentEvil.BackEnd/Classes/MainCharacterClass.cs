using Microsoft.EntityFrameworkCore;
using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Classes
{
    public class MainCharacterClass : CharacterClass
    {
        static dbContext db = new dbContext();       
        public List<CharacterDTO> GetMain() {

            List<CharacterDTO> characters = new List<CharacterDTO>();

            try
            {
                characters = Get();
                characters = characters.Where(c => c.IsMain == true).ToList();                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return characters;
        }
    }
}
