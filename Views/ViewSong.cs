using System;
using Billiefy.Controllers;
using Billiefy.Models;

namespace Billiefy.Views
{
    public class ViewSong
    {
        private SongController _songController = new SongController();
        public void Create(int albumId)
        {
            Song song = new Song();
            int aux;
            
            Console.WriteLine("Qual o nome da música?");
            song.Title = Console.ReadLine();
                
            Console.WriteLine("Qual a duração da música?");
            song.Duration = float.Parse(Console.ReadLine()!);
            
            Console.WriteLine(
                "Essa música é favorita? \n" +
                "1. Sim \n" +
                "2. Não"
            );
            aux = int.Parse(Console.ReadLine()!);
            song.IsFavorite = aux == 1; // Operador ternário
            song.AlbumId = albumId;
            _songController.Store(song);
        }

        public void Show(Song song)
        {
            Console.Write(song.Title + " --------------- " + song.Duration + " minutos  ");
            Console.WriteLine(song.IsFavorite ? "Favorita" : "Não-Favorita");
        }
    }
}