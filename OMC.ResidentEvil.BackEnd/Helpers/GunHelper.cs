using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Helpers
{
    internal class GunHelper
    {
        /// <summary>
        /// Sets a Gun DTO Type based on a Gun Model Type
        /// </summary>
        public GunDTO SetGun(Gun item)
        {
            try
            {
                GunDTO gun = new GunDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Game = new VideogameDTO
                    {
                        Id = item.IdGameNavigation.Id,
                        Name = item.IdGameNavigation.Name,
                        Year = item.IdGameNavigation.Year
                    }
                };
                return gun;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return new GunDTO(); }
        }

        /// <summary>
        /// Sets a Gun Model Type based on a Gun DTO
        /// </summary>
        public Gun SetGun(GunDTO item)
        {
            try
            {
                Gun gun = new Gun
                {
                        Id = item.Id,
                      Name = item.Name,
                      IdGame = item.Game.Id
                };
                return gun;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return new Gun(); }
        }
    }
}
