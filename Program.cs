using System;
using System.ComponentModel.Design;
using Billify.Views;

namespace Billify
{
    class Program
    {
        static void Main(string[] args)
        {
            Main app = new Main();
            try
            {
                app.MainMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}