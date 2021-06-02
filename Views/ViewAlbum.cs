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
        private ViewSong _viewSong = new ViewSong();
        private Album _album = new Album();
        private List<Album> _albums = new List<Album>();
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
            
            _album.Id  = _albumController.Store(_album, artist);
            
            Console.WriteLine("\n");
            Console.WriteLine("Adicionando as músicas do álbum.");
            
            do
            {
                
                _viewSong.Create();
                
                Console.WriteLine(
                    "Pronto! Música adicionada! Adicionar outra? \n" +
                    "1. Sim \n" +
                    "2. Não \n"
                );
                aux = int.Parse(Console.ReadLine()!);

            } while (aux != 2);
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

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Qual é o título do álbum?");
                        _album.Title = Console.ReadLine();
                        _album = _albumController.GetByTitle(_album.Title);
                        break;
                    case 2:
                        Console.WriteLine("Qual o ano de lançamento?");
                        _album.ReleaseYear = int.Parse(Console.ReadLine()!);
                        _albums = _albumController.GetByReleaseYear(_album.ReleaseYear);
                        break;
                    case 3:
                        Console.WriteLine("Qual o nome da banda?");
                        _album.ArtistId = _artistController.VerifyArtist(Console.ReadLine());
                        _albums = _albumController.GetByArtist(_album.ArtistId);
                        break;
                    default:
                        Console.WriteLine("Oops! Opção Inválida!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Show(Album album)
        {
            try
            {
                Console.WriteLine("Aqui está o seu Álbum!");
                Console.WriteLine("Nome do álbum: " + _album.Title);
                Console.WriteLine("Ano de lançamento: " + _album.ReleaseYear);
                Console.WriteLine("Banda: " + _artistController.GetById(_album.ArtistId));

                foreach (var value in _songController.GetByAlbumId(_album.ArtistId))
                {
                    _viewSong.Show(value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void ShowResults(List<Album> albums)
        {
            try
            {
                foreach (var value in albums)
                {
                    Show(value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}