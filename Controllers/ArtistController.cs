using System;
using System.Collections.Generic;
using Billify.Dao;
using Billify.Models;

namespace Billify.Controllers
{
    public class ArtistController
    {
        private ArtistDao _artistDao = new ArtistDao();

        public List<Artist> Index()
        {
            try
            {
                return _artistDao.Artists;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Store(Artist artist)
        {
            try
            {
                _artistDao.Create(artist);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Artist GetById(int artistId)
        {
            try
            {
                return _artistDao.GetById(artistId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public int VerifyArtist(string artist)
        {
            foreach (var value in _artistDao.Artists)
            {
                if (artist.Equals(value.Name))
                {
                    return value.Id;
                }
            }
            return 0;
        }
        
    }
}