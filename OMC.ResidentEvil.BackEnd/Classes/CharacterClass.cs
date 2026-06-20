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
        static CharacterHelper cHelper = new CharacterHelper();

        /// <summary>
        /// Gets the Characters Data
        /// </summary>
        public static List<CharacterDTO> Get(){

            try
            {
                List<CharacterDTO> characters = new List<CharacterDTO>();

                foreach (var item in db.Characters.Include(i => i.VideogameCharacters)
                                                  .ThenInclude( iv => iv.IdGameNavigation))
                {
                    characters.Add(cHelper.SetCharacter(item));
                }
                return characters;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return new List<CharacterDTO>(); }

        }

        /// <summary>
        /// Gets one Particular Character Data
        /// </summary>
        public static CharacterDTO Get(int id){

            CharacterDTO character = new CharacterDTO();
            try
            {
                var lcharacter = db.Characters.Include(i => i.VideogameCharacters)
                                              .ThenInclude(iv => iv.IdGameNavigation)
                                              .Where( c => c.Id == id).FirstOrDefault();

                if (lcharacter != null){
                    character = cHelper.SetCharacter(lcharacter);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return character;
        }

        /// <summary>
        /// Adds a new Character in the Database
        /// </summary>
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

        /// <summary>
        ///  Adds a new Relation between a Character and a Videogame
        /// </summary>
        public static void AddExisting(CharacterDTO character) {
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

        /// <summary>
        /// Removes the selected Character
        /// </summary>
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
