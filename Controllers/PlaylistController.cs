using System;
using System.Collections.Generic;
using Billiefy.Dao;
using Billiefy.Models;

namespace Billiefy.Controllers
{
    public class PlaylistController
    {
        private SongController _songController = new SongController();
        public List<Song> Create()
        {
            List<List<Song>> songs = new List<List<Song>>();
            List<Song> playlist = new List<Song>();
            int aux = 0;
            try
            {
                int songsTotalCount = _songController.Index().Count;
                songs = this.SeparateSongs();
                

                int minor = Math.Min(songs[0].Count, songs[1].Count);
                while (aux < minor)
                {
                    playlist.Add(songs[0][aux]);
                    playlist.Add(songs[1][aux]);
                    aux++;
                }

                return playlist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private List<List<Song>> SeparateSongs()
        {
            List<List<Song>> lists = new List<List<Song>>();
            List<Song> songs = _songController.Index();
            List<Song> favorites = new List<Song>();
            List<Song> others = new List<Song>();

            foreach (var song in songs)
            {
                if (song.IsFavorite)
                {
                    favorites.Add(song);
                }
                else
                {
                    others.Add(song);
                }
            }
            lists.Add(this.ShuffleSongs(others));
            lists.Add(this.ShuffleSongs(favorites));
            return lists;
        }

        private List<Song> ShuffleSongs(List<Song> list)
        {
            Random rng = new Random();
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                Song value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }

            return list;
        }
    }
}