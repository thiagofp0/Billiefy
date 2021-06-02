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
        private Artist _artist = new Artist();

        public void Create()
        {
            //Aqui o usuário interage com o programa e informa os dados a serem salvos no objeto.
            int aux;

            Console.WriteLine("Qual é o título do álbum?");
            _album.Title = Console.ReadLine();
            
            Console.WriteLine("Qual o ano de lançamento deste álbum?");
            _album.ReleaseYear = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Qual o nome da banda?");
            _artist.Name = Console.ReadLine();
            
            //Pesquisa artista na lista 
            //Se existir, pega o ID, senão cria e pega o ID.
            
            _albumController.Store(_album, _artist);
            _album = _albumController.GetByTitle(_album.Title);
            
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
            int option;
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
                        Show(_album);
                        break;
                    case 2:
                        Console.WriteLine("Qual o ano de lançamento?");
                        _album.ReleaseYear = int.Parse(Console.ReadLine()!);
                        _albums = _albumController.GetByReleaseYear(_album.ReleaseYear);
                        ShowResults(_albums);
                        break;
                    case 3:
                        Console.WriteLine("Qual o nome da banda?");
                        _album.ArtistId = _artistController.VerifyArtist(Console.ReadLine());
                        _albums = _albumController.GetByArtist(_album.ArtistId);
                        ShowResults(_albums);
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
                Console.WriteLine("Nome do álbum: " + album.Title);
                Console.WriteLine("Ano de lançamento: " + album.ReleaseYear);
                Console.WriteLine("Banda: " + _artistController.GetById(album.ArtistId).Name);

                foreach (var value in _songController.GetByAlbumId(album.Id))
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