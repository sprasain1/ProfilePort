﻿using ProfilePort.Adapters.Interfaces;
using ProfilePort.Data;
using ProfilePort.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfilePort.Adapters.DataAdapters
{
    public class Favorites:IFavorite
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        List<DataModel.Favorite> IFavorite.GetFavorite(string DashboardId)
        {
            return db.Favorites.Where(m => m.DashboardId == DashboardId).ToList();
        }

        DataModel.Favorite IFavorite.GetFavorite(int id)
        {
            return db.Favorites.Where(m => m.FavoriteId == id).FirstOrDefault();
        }

        DataModel.Favorite IFavorite.PostNewFavorite(string DashboardId, DataModel.Favorite newFavorite)
        {
            Favorite Favorite = new Favorite();
            Favorite.Name = newFavorite.Name;
            Favorite.Description = newFavorite.Description;
            Favorite.DashboardId = DashboardId;
            db.Favorites.Add(Favorite);
            db.SaveChanges();
            return newFavorite;
        }

        DataModel.Favorite IFavorite.PutFavorite(int id, DataModel.Favorite newFavorite)
        {
            Favorite Favorite = new Favorite();
            Favorite = db.Favorites.Where(p => p.FavoriteId == id).FirstOrDefault();
            Favorite.Name = newFavorite.Name;
            Favorite.Description = newFavorite.Description;
           
            db.SaveChanges();
            return newFavorite;
        }

        DataModel.Favorite IFavorite.DeleteFavorite(int id)
        {
            Favorite Favorite = new Favorite();
            Favorite = db.Favorites.Where(p => p.FavoriteId == id).FirstOrDefault();
            db.Favorites.Remove(Favorite);
            db.SaveChanges();
            return Favorite;
        }
    }
}