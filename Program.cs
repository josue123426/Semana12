using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libreria lib = new Libreria();

            while (true)
            {
                Console.WriteLine("\n=== LIBRERÍA ===");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Mostrar libros");
                Console.WriteLine("3. Modificar libro");
                Console.WriteLine("4. Eliminar libro");
                Console.WriteLine("5. Salir");
                Console.Write("Opción: ");

                string op = Console.ReadLine();

                switch (op)
                {
                    case "1": lib.Registrar(); break;
                    case "2": lib.Mostrar(); break;
                    case "3": lib.Modificar(); break;
                    case "4": lib.Eliminar(); break;
                    case "5": return;
                    default: Console.WriteLine("Opción inválida!"); break;
                }
            }
        }
    }
}
