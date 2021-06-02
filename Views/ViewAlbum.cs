using System;
using System.Collections.Generic;
using Billify.Controllers;
using Billify.Models;

namespace Billify.Views
{
    public class ViewAlbum
    {
        private AlbumController _albumController = new AlbumController();
        private SongController _songController = new SongController();
        private ArtistController _artistController = new ArtistController();
        private Album _album = new Album();
        private Song _song = new Song();
        public void Create()
        {
            //Aqui o usuário interage com o programa e informa os dados a serem salvos no objeto.
            int aux = 0;
            
            Console.WriteLine("Qual é o título do álbum?");
            _album.Title = Console.ReadLine();
            
            Console.WriteLine("Qual o ano de lançamento deste álbum?");
            _album.ReleaseYear = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Qual o nome da banda?");
            string artist = Console.ReadLine();
            
            //Pesquisa artista na lista 
            //Se existir, pega o ID, senão cria e pega o ID.

            if (_artistController.VerifyArtist(artist) != 0)
            {
                _album.ArtistId = _artistController.VerifyArtist(artist);
            }
            else
            {
                _artistController.Store(artist);
                _album.ArtistId = _artistController.VerifyArtist(artist);
            }
            
            Console.WriteLine("\n");
            Console.WriteLine("Adicionando as músicas do álbum.");
            
            do
            {
                
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
                _songController.Store(_song, _album.Id);
                
                Console.WriteLine(
                    "Pronto! Música adicionada! Adicionar outra? \n" +
                    "1. Sim \n" +
                    "2. Não \n"
                );
                aux = int.Parse(Console.ReadLine()!);

            } while (aux != 2);
            _albumController.Store(_album);
        }

        public void Search()
        {
            int option = 0;
            try
            {
                Console.WriteLine("Procurar álbum por:");
                Console.WriteLine(
                    "1. Título \n" +
                    "2. Ano de lançamento \n" +
                    "3. Banda \n"
                );
                option = int.Parse(Console.ReadLine()!);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}