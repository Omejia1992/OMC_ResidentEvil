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
    public class VideogameClass:IMethods<VideogameDTO>
    {
        static dbContext db = new dbContext();
        static VideogameHelper vHelper = new VideogameHelper();
        public delegate object SetVideogame(Videogame game);

        /// <summary>
        /// Gets the list of Videogames
        /// </summary>
        public static List<VideogameDTO> Get(){

            try
            {
                List<VideogameDTO> games = new List<VideogameDTO>();
                var data = db.Videogames.AsNoTracking();

                SetVideogame del = vHelper.SetVideoGame;
                foreach (var item in data)
                {
                    games.Add((VideogameDTO)del(item));
                }
                return games;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return new List<VideogameDTO>(); }

        }

        /// <summary>
        /// Get a Videogame Data depending on it's Id 
        /// </summary>
        public static VideogameDTO Get(int id) 
        {
            try
            {
                VideogameDTO game = new VideogameDTO();
                Videogame lGame = db.Videogames.AsNoTracking().Where( l => l.Id == id).FirstOrDefault();

                if (lGame != null)
                {
                    SetVideogame del = vHelper.SetVideoGame;
                    game = (VideogameDTO)del(lGame);
                }

                return game;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return new VideogameDTO(); }
        }

        /// <summary>
        /// Adds a new Videogame to the Table
        /// </summary>
        public static void Add(VideogameDTO game)
        {
            try
            {
                Videogame lGame = vHelper.SetVideoGame(game);               
                db.Add(lGame);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        /// <summary>
        /// Updates the existing Videogame Basic Data
        /// </summary>
        public static void Update(VideogameDTO game)
        {
            try
            {
                Videogame lGame = vHelper.SetVideoGame(game);
                db.Update(lGame);
                db.SaveChanges();
            }
            catch (Exception ex){ Console.WriteLine(ex.Message);}
        }

        /// <summary>
        /// Removes a Videogame from the Database
        /// </summary>
        public static void Delete(int id)
        {
            try { 
               Videogame lGame = db.Videogames.Find(id);

                if (lGame != null){
                    db.Videogames.Remove(lGame);
                    db.SaveChanges();
                }
            }
            catch(Exception ex) { Debug.WriteLine(ex.Message); }
        }
    }
}
