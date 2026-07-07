using Microsoft.EntityFrameworkCore;
using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Helpers;
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
        delegate object SetGun(Gun gun);
        static GunHelper gHelper = new GunHelper();

        /// <summary>
        /// Gets a List of the existing Guns
        /// </summary>
        public static List<GunDTO> Get()
        {
            try
            {
                List<GunDTO> guns = new List<GunDTO>();
                SetGun del = gHelper.SetGun;

                foreach (var item in db.Guns.AsNoTracking().Include(i => i.IdGameNavigation))
                {
                    guns.Add((GunDTO)del(item));
                }
                return guns;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return new List<GunDTO>(); }
        }

        /// <summary>
        /// Gets a Particular Gun Data using it's Id
        /// </summary>
        public static GunDTO Get(int id)
        {
            try
            {
                GunDTO gun = new GunDTO();
                Gun lGun = db.Guns.AsNoTracking().Include( i => i.IdGameNavigation)
                                                 .Where( g => g.Id == id).FirstOrDefault();
                
                if (lGun != null)
                {
                    SetGun del = gHelper.SetGun;
                    gun = (GunDTO)del(lGun);
                }
                return gun;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return new GunDTO(); }
        }

        /// <summary>
        /// Adds a new Gun to the Database
        /// </summary>
        public static void Add(GunDTO gun) 
        {
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

        /// <summary>
        /// Updates the existing Gun Basic Data
        /// </summary>
        public static void Update(GunDTO gun)
        {
            try
            {
                Gun lGun = gHelper.SetGun(gun);
                db.Update(lGun);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        /// <summary>
        /// Deletes a Gun from the Database
        /// </summary>
        /// <param name="id"></param>
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
