using Microsoft.EntityFrameworkCore;
using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Interfaces;
using OMC.ResidentEvil.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Classes
{
    public class GunClass: IMethods<GunDTO>
    {
        static dbContext db = new dbContext();
        public static List<GunDTO> Get()
        {
            try
            {
                List<GunDTO> guns = new List<GunDTO>();

                foreach (var item in db.Guns.Include(i => i.IdGameNavigation))
                {
                    guns.Add(new GunDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Game = new VideogameDTO
                        {
                            Id = item.IdGameNavigation.Id,
                            Name = item.IdGameNavigation.Name,
                            Year = item.IdGameNavigation.Year
                        }
                    });
                }
                return guns;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return new List<GunDTO>(); }
        }
        public static void Add(GunDTO gun) {

            try
            {
                db.Guns.Add(new Gun
                {
                    IdGame = gun.Game.Id,
                    Name = gun.Name
                });
                db.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        
        }
        public static void Delete(int id) {

            try
            {
                Gun gun = db.Guns.Find(id);

                if (gun != null)
                {
                    db.Remove(gun);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }
    }
}
