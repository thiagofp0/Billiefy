using System;
using Billify.Views;

namespace Billify.Views
{
    public class Main
    {
        public static void MainMenu()
        {
            int option; //Opção selecionada no menu.
            
            Console.WriteLine("------------------ Billiefy --------------------");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine(
                
                "1. Novo álbum \n" +
                "2. Pesquisar álbuns \n" +
                "3. Pesquisar Música \n" +
                "4. Gerar playlist \n" +
                "5. Sair"
                
            );

            option = Console.Read();
            SwitchOption(option);
        }

        public static void SwitchOption(int option)
        {
            try
            {
                switch (option)
                {
                    //Todo                        
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