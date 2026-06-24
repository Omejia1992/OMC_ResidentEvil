using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Helpers
{
    internal class VideogameHelper
    {
        /// <summary>
        /// Sets a VideogameDTO Type based on a Videogame Model Type
        /// </summary>
        public VideogameDTO SetVideoGame(Videogame item)
        {
            try
            {
                VideogameDTO game = new VideogameDTO { 
                             Id=item.Id,
                             Name=item.Name,
                             Year=item.Year,
                             HasRemake=item.HasRemake,
                };
                return game;
            }
            catch (Exception ex){ Console.WriteLine(ex.Message); return new VideogameDTO(); }
        }

        /// <summary>
        /// Sets a Videogame Model Type based on a Videogame DTO
        /// </summary>
        public Videogame SetVideoGame(VideogameDTO item)
        {
            try
            {
                Videogame game = new Videogame
                {
                    Id = item.Id,
                    Name = item.Name,
                    Year = item.Year,
                    HasRemake = item.HasRemake
                };
                return game;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message);return new Videogame(); }
        }
    }
}
