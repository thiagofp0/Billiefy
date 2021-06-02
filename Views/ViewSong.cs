using System;
using Billify.Controllers;
using Billify.Models;

namespace Billify.Views
{
    public class ViewSong
    {
        private Song _song = new Song();
        private SongController _songController = new SongController();
        
        public void Create()
        {
            int aux = 0;
            Console.WriteLine("Qual o nome da música?");
            _song.Title = Console.ReadLine();
                
            Console.WriteLine("Qual a duração da música?");
            _song.Duration = float.Parse(Console.ReadLine()!);
                
                
            Console.WriteLine(
                "Essa música é favorita? \n" +
                "1. Sim \n" +
                "2. Não"
            );
            aux = int.Parse(Console.ReadLine()!);

            if (aux == 1)
            {
                _song.IsFavorite = true;
            }
            _song.IsFavorite = false;
                
            //_album.Songs.Add(_song); Substituir por criar a música passando id do álbum
            _songController.Store(_song);
        }
        public void Show(Song song)
        {
            Console.Write(song.Title + " --------------- " + song.Duration + "  ");
            if (song.IsFavorite)
            {
                Console.Write("❤");
            }
            else
            {
                Console.Write("🤍");
            }
        }
    }
}