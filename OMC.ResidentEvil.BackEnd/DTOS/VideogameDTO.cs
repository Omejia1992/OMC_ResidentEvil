using OMC.ResidentEvil.BackEnd.Interfaces;

namespace OMC.ResidentEvil.BackEnd.DTOS
{
    public class VideogameDTO: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public bool HasRemake { get; set; }
    }
}
