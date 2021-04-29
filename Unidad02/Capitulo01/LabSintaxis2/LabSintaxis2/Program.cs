using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis2
{
    class Program
    {
        static void Main(string[] args)
        {
            String inputTexto;
            Console.WriteLine("Ingrese un texo: ");
            inputTexto = Console.ReadLine();

            if (String.IsNullOrEmpty(inputTexto))
            { Program.Close("Debe ingresar un texto"); }
            ConsoleKeyInfo op;
            do
            {
                Console.WriteLine("1. Uppercase \n2. Lowecase \n3. Length\n ");
                op = Console.ReadKey();
                switch (op.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine(inputTexto.ToUpper() + "\n ");
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine(inputTexto.ToLower() + "\n ");
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine(inputTexto.Length + "\n ");
                        break;
                    default: 
                        Program.Close("No selecciono una opcion");
                        break;
                }
            } while (op.Key != ConsoleKey.Escape);

            Console.ReadLine();
        }
        static void Close(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
