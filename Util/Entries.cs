using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Billiefy.Util
{
    public class Entries
    {
        public static int GetInt(string msg)
        {
            bool isParsable = false;
            int number = 0;
            while (!isParsable || number < 0)
            {
                Console.WriteLine(msg);
                isParsable = Int32.TryParse(Console.ReadLine(), out number);
                if (!isParsable || number < 0)
                {
                    Console.WriteLine("Valor digitado é inválido! Digite um número inteiro: ");
                }
            }

            return number;
        }

        public static int GetYear(string msg)
        {
            int year = 2022;
            while (year > 2021 || year <= 0)
            {
                year = GetInt(msg);
                if (year > 2021 || year <= 0)
                {
                    Console.WriteLine("O ano digitado é inválido... ");
                }
            }

            return year;
        }

        public static string GetString(string msg)
        {
            string entry = "";
            while (entry.Length == 0)
            {
                Console.WriteLine(msg);
                entry = Console.ReadLine();
                if (entry.Length == 0)
                {
                    Console.WriteLine("Coloque uma resposta válida: ");
                }
            }

            return entry;
        }

        public static double GetDouble(string msg)
        {
            bool isParsable = false;
            double number = 0;
            string entry = "";
            while (!isParsable || number <= 0)
            {
                Console.WriteLine(msg);
                entry = Console.ReadLine();
                entry.Replace(".", ",");
                
                isParsable = Double.TryParse(entry, out number);
                if (!isParsable || number <= 0)
                {
                    Console.WriteLine("Valor digitado é inválido! Digite um número positivo: ");
                }
            }

            return number;
        }
        
    }
}