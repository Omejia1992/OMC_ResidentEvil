using Microsoft.EntityFrameworkCore;
using OMC.ResidentEvil.BackEnd.Models;
using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using OMC.ResidentEvil.BackEnd.Helpers;

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

                foreach (var item in db.Characters.Include(i => i.VideogameCharacters).ThenInclude( iv => iv.IdGameNavigation))
                {

                    //Videogame game = item.IdGameNavigation;

                    characters.Add(new CharacterDTO
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
                    });
                }
                return characters;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return new List<CharacterDTO>(); }
        }
        public static void Add(CharacterDTO character){

            try
            {
                if (character.Id > 0) { 
                    
                    AddExisting(character);
                }
                else{

                    Character lCharacter = new Character()
                    {
                        FirstName = character.FirstName,
                        MiddleName = character.MiddleName,
                        LastName = character.LastName,
                        IsMain = character.IsMain
                    };

                    db.Characters.Add(lCharacter);
                    db.SaveChanges();

                    VideogameCharacter videogameCharacter = new VideogameCharacter()
                    {
                        IdGame = character.Game.Id,
                        Idcharacter = lCharacter.Id
                    };

                    db.VideogameCharacters.Add(videogameCharacter);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }

        public static void AddExisting(CharacterDTO character)
        {
            try
            {
                VideogameCharacter videogameCharacter = new VideogameCharacter()
                {
                    IdGame = character.Game.Id,
                    Idcharacter = character.Id
                };
                
                db.VideogameCharacters.Add(videogameCharacter);
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
