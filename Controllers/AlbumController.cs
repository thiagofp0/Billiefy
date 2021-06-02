﻿using System;
using System.Collections.Generic;
using Billify.Dao;
using Billify.Models;

namespace Billify.Controllers
{
    public class AlbumController
    {
        private AlbumDao _albumDao = new AlbumDao();
        private ArtistController _artistController = new ArtistController();
        private Album _album = new Album();

        public List<Album> Index()
        {
            return _albumDao.Albums;
        }
        public int Store(Album album, string artist)
        {
            try
            {
                
                if (_artistController.VerifyArtist(artist) != 0)
                {
                    _album.ArtistId = _artistController.VerifyArtist(artist);
                }
                else
                {
                    _artistController.Store(artist);
                    _album.ArtistId = _artistController.VerifyArtist(artist);
                }
                
                int id = _albumDao.Create(album);
                return id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Album GetByTitle(string album)
        {
            try
            {
                return _albumDao.GetByTitle(album);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Album> GetByReleaseYear(int year)
        {
            try
            {
                return _albumDao.GetByReleaseYear(year);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Album> GetByArtist(int artistId)
        {
            try
            {
                return _albumDao.GetByArtist(artistId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}