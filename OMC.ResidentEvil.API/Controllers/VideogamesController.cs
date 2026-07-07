using Microsoft.AspNetCore.Mvc;
using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Models;
using OMC.ResidentEvil.BackEnd.Classes;

namespace OMC.ResidentEvil.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideogamesController : ControllerBase
    {
        private dbContext db = new dbContext();
                CharacterClass _characterClass = new CharacterClass();

        /// Get Methods        

        [HttpGet("games")]
        public IEnumerable<VideogameDTO> GetGames() {

            return VideogameClass.Get();
        }

        [HttpGet("characters")]
        public IEnumerable<CharacterDTO> GetCharacters() {

            return _characterClass.Get();
        }

        [HttpGet("guns")]
        public IEnumerable<GunDTO> GetGuns() {

            return GunClass.Get();
        }

        /// Post Methods

        [HttpPost("createGame")]
        public void CreateGame([FromBody] VideogameDTO videogame) { 
            
            VideogameClass.Add(videogame);
        }

        [HttpPost("createCharacter")]
        public void CreateCharacter([FromBody] CharacterDTO characterDto)
        {
            _characterClass.Add(characterDto);
        }

        [HttpPost("createGun/{idGame},{name}")]
        public void CreateGun(int idGame, string name)
        {
            GunDTO gun = new GunDTO { Name = name, 
                                       Game = new VideogameDTO { Id = idGame } };
            GunClass.Add(gun);        

        }

        /// Patch Methods
        [HttpPatch("updateGun")]
        public void UpdateGun([FromBody] GunDTO gunDTO) {

             GunClass.Update(gunDTO);
        }

        [HttpPatch("updateGame")]
        public void UpdateGame([FromBody] VideogameDTO videogameDTO) { 

            VideogameClass.Update(videogameDTO);
        }

        [HttpPatch("updateCharacter")]
        public void UpdateCharacter([FromBody] CharacterDTO characterDTO) { 
            
            _characterClass.Update(characterDTO);

        }

        /// Delete Methods
        [HttpDelete("deleteGame/{idGame}")]
        public void DeleteGame(int idGame) { 
            
            VideogameClass.Delete(idGame);
        }

        [HttpDelete("deleteCharacter/{idCharacter}")]
        public void DeleteCharacter(int idCharacter) { 
            
            _characterClass.Delete(idCharacter);
        }

        [HttpDelete("deleteGun/{idGun}")]
        public void DeleteGun(int idGun) { 
            
            GunClass.Delete(idGun);
        }
    }
}
