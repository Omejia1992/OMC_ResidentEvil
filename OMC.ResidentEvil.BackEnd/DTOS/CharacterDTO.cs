using OMC.ResidentEvil.BackEnd.Interfaces;

namespace OMC.ResidentEvil.BackEnd.DTOS
{
    public class CharacterDTO: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public VideogameDTO Game { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public bool IsMain { get; set; } 
        public bool IsVillian {  get; set; }
        public bool IsSidekick {  get; set; }
        public string GamesName { get; set; } = string.Empty;
        public List<VideogameDTO> Games { get; set; }
    }
}
