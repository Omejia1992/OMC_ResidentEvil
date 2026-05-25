using OMC.ResidentEvil.BackEnd.Interfaces;

namespace OMC.ResidentEvil.BackEnd.DTOS
{
    public class GunDTO: IEntity
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        public VideogameDTO Game { get; set; }
    }
}
