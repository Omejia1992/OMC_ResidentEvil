using Microsoft.EntityFrameworkCore;
using OMC.ResidentEvil.BackEnd.Models;
using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace OMC.ResidentEvil.BackEnd.Classes
{
    public class CharacterClass: IMethods<CharacterDTO>
    {
        static dbContext db = new dbContext();
        public static List<CharacterDTO> Get()
        {
            try
            {
                List<CharacterDTO> characters = new List<CharacterDTO>();

                foreach (var item in db.Characters.Include(i => i.IdGameNavigation))
                {

                    Videogame game = item.IdGameNavigation;

                    characters.Add(new CharacterDTO
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        MiddleName = item.MiddleName,
                        LastName = item.LastName,
                        Game = new VideogameDTO
                        {
                            Id = item.IdGameNavigation.Id,
                            Name = item.IdGameNavigation.Name,
                            Year = item.IdGameNavigation.Year
                        }
                    });
                }
                return characters;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return new List<CharacterDTO>(); }
        }
        public static void Add(CharacterDTO character){

            try
            {
                Character lCharacter = new Character()
                {
                    FirstName = character.FirstName,
                    MiddleName = character.MiddleName,
                    LastName = character.LastName,
                    IdGame = character.Game.Id
                };
                db.Characters.Add(lCharacter);
                db.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }
        public static void Delete(int id) {

            try
            {
                Character character = db.Characters.Find(id);

                if(character != null)
                {
                    db.Characters.Remove(character);
                    db.SaveChanges();
                }

            }
            catch(Exception ex) { Debug.WriteLine(ex.Message); }
        }
    }
}
