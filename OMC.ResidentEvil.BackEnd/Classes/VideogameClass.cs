using OMC.ResidentEvil.BackEnd.DTOS;
using OMC.ResidentEvil.BackEnd.Interfaces;
using OMC.ResidentEvil.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Classes
{
    public class VideogameClass:IMethods<VideogameDTO>
    {
        static dbContext db = new dbContext();
        public static List<VideogameDTO> Get(){

            try
            {
                List<VideogameDTO> games = new List<VideogameDTO>();
                var data = db.Videogames;

                foreach (var item in data)
                {
                    games.Add(new VideogameDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Year = item.Year,
                        HasRemake = item.HasRemake
                    });
                }
                return games;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return new List<VideogameDTO>(); }

        }

        public static void Add(VideogameDTO game)
        {
            try
            {
                Videogame lGame = new Videogame
                {
                    Name = game.Name,
                    Year = game.Year,
                    HasRemake = game.HasRemake
                };

                db.Add(lGame);
                db.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }

        public static void Delete(int id)
        {
            try { 
               Videogame lGame =  db.Videogames.Find(id);

                if (lGame != null){
                    db.Videogames.Remove(lGame);
                    db.SaveChanges();
                }

            }
            catch(Exception ex) { Debug.WriteLine(ex.Message); }
        }
    }
}
