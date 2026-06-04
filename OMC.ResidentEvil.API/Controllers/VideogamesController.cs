using Microsoft.AspNetCore.Mvc;
using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Models;

namespace OMC.ResidentEvil.BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideogamesController : ControllerBase
    {
        private dbContext db = new dbContext();

        /// Get Methods        

        [HttpGet("games")]
        public IEnumerable<Videogame> GetGames() {

            return db.Videogames;
        }

        [HttpGet("characters")]
        public IEnumerable<Character> GetCharacters() {

            return db.Characters;
        }

        [HttpGet("guns")]
        public IEnumerable<Gun> GetGuns() {

            return db.Guns;
        }

        /// Post Methods

        [HttpPost("createGame")]
        public void CreateGame([FromBody] VideogameDTO videogame) { 
            
            Videogame game = new Videogame { Name = videogame.Name, 
                                             Year = videogame.Year , 
                                        HasRemake = videogame.HasRemake};
            db.Videogames.Add(game);
            db.SaveChanges();
        }

        [HttpPost("createCharacter")]
        public void CreateCharacter([FromBody] CharacterDTO characterDto)
        {
            Character character = new Character
            {
                FirstName  = characterDto.FirstName,              
                LastName   = characterDto.LastName
            };
            db.Characters.Add(character);
            db.SaveChanges();
        }

        [HttpPost("createGun/{idGame},{name}")]
        public void CreateGun(int idGame, string name)
        {
            Gun gun = new Gun { IdGame = idGame, Name = name };
            db.Guns.Add(gun);
            db.SaveChanges();
        }

        /// Put Methods
        [HttpPatch("updateGun")]
        public void UpdateGun([FromBody] GunDTO gunDTO) {

            Gun gun = db.Guns.Find(gunDTO.Id);
                gun.Name = gunDTO.Name;
           
            db.Update(gun);
            db.SaveChanges();
        }

        [HttpPatch("updateGame")]
        public void UpdateGame([FromBody] VideogameDTO videogameDTO) { 

            Videogame game = db.Videogames.Find(videogameDTO.Id);
                      game.Year = videogameDTO.Year;
                      game.Name = videogameDTO.Name;
                      game.HasRemake = videogameDTO.HasRemake;

            db.Update(game);
            db.SaveChanges();
        }

        [HttpPatch("updateCharacter")]
        public void UpdateCharacter([FromBody] CharacterDTO characterDTO) { 
            
            Character character = db.Characters.Find(characterDTO.Id);
                      character.FirstName = characterDTO.FirstName;
                      character.LastName = characterDTO.LastName;
                      character.MiddleName = characterDTO.MiddleName;

            db.Update(character);
            db.SaveChanges();
        }
    }
}
