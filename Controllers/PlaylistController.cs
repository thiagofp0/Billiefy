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
                songs = this.SeparateSongs(); //songs[0] - nao favoritas | songs[1] - favoritas 
    
                int minor = Math.Min(songs[0].Count, songs[1].Count);
                
                while (aux < minor && SumDurations(playlist)+songs[0][aux].Duration+songs[1][aux].Duration <= 60)
                {
                    playlist.Add(songs[0][aux]);
                    playlist.Add(songs[1][aux]);
                    aux++;
                }

                if (SumDurations(playlist) == 0)
                {
                    if (songs[0].Count > 0 && songs[1].Count > 0)
                    {
                        playlist.Add(songs[1][0]);
                    }else if (songs[0].Count > 0)
                    {
                        aux = 0;
                        while (aux < songs[0].Count && SumDurations(playlist)+songs[0][aux].Duration<= 60)
                        {
                            playlist.Add(songs[0][aux]);
                            aux++;
                        }
                    } else if (songs[1].Count > 0)
                    {
                        aux = 0;
                        while (aux < songs[1].Count && SumDurations(playlist)+songs[1][aux].Duration<= 60)
                        {
                            playlist.Add(songs[1][aux]);
                            aux++;
                        }
                    }
                    
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

            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private List<Song> ShuffleSongs(List<Song> list)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public double SumDurations(List<Song> songs)
        {
            double sum = 0;
            try
            {
                foreach (var song in songs)
                {
                    sum += song.Duration;
                }

                return sum;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}