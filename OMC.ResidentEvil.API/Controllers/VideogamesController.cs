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
        [Tags("Games")]
        [HttpGet("games")]
        public IEnumerable<VideogameDTO> GetGames() {

            return VideogameClass.Get();
        }

        [Tags("Games")]
        [HttpGet("game/id={idGame}")]
        public VideogameDTO GetGame(int idGame) {
            return VideogameClass.Get(idGame);
        }

        [Tags("Characters")]
        [HttpGet("characters")]
        public IEnumerable<CharacterDTO> GetCharacters() {

            return _characterClass.Get();
        }

        [Tags("Characters")]
        [HttpGet("characters/idGame={idGame}")]
        public IEnumerable<CharacterDTO> GetCharacters(int idGame)
        {
            return _characterClass.GetByVideogame(idGame);
        }

        [Tags("Characters")]
        [HttpGet("character/id={idCharacter}")]
        public CharacterDTO GetCharacter(int idCharacter)
        {
            return _characterClass.Get(idCharacter);
        }

        [Tags("Guns")]
        [HttpGet("guns")]
        public IEnumerable<GunDTO> GetGuns() {

            return GunClass.Get();
        }

        [Tags("Guns")]
        [HttpGet("gun/id={idGun}")]
        public GunDTO GetGun(int idGun) {

            return GunClass.Get(idGun);
        }

        /// Post Methods       
        [Tags("Games")]
        [HttpPost("createGame")]
        public void CreateGame([FromBody] VideogameDTO videogame) { 
            
            VideogameClass.Add(videogame);
        }

        [Tags("Characters")]
        [HttpPost("createCharacter")]
        public void CreateCharacter([FromBody] CharacterDTO characterDto)
        {
            _characterClass.Add(characterDto);
        }

        [Tags("Guns")]
        [HttpPost("createGun/idGame={idGame}, name={name}")]
        public void CreateGun(int idGame, string name)
        {
            GunDTO gun = new GunDTO { Name = name, 
                                       Game = new VideogameDTO { Id = idGame } };
            GunClass.Add(gun);        

        }

        /// Patch Methods
        [Tags("Guns")]
        [HttpPatch("updateGun")]
        public void UpdateGun([FromBody] GunDTO gunDTO) {

             GunClass.Update(gunDTO);
        }

        [Tags("Games")]
        [HttpPatch("updateGame")]
        public void UpdateGame([FromBody] VideogameDTO videogameDTO) { 

            VideogameClass.Update(videogameDTO);
        }

        [Tags("Characters")]
        [HttpPatch("updateCharacter")]
        public void UpdateCharacter([FromBody] CharacterDTO characterDTO) { 
            
            _characterClass.Update(characterDTO);

        }

        /// Delete Methods
        [Tags("Games")]
        [HttpDelete("deleteGame/id={idGame}")]
        public void DeleteGame(int idGame) { 
            
            VideogameClass.Delete(idGame);
        }

        [Tags("Characters")]
        [HttpDelete("deleteCharacter/id={idCharacter}")]
        public void DeleteCharacter(int idCharacter) { 
            
            _characterClass.Delete(idCharacter);
        }

        [Tags("Guns")]
        [HttpDelete("deleteGun/id={idGun}")]
        public void DeleteGun(int idGun) { 
            
            GunClass.Delete(idGun);
        }
    }
}
