using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana12
{
    internal class Libreria
    {
        string[] nombres = new string[0];
        double[] precios = new double[0];
        int pos = 0;

        public void Registrar()
        {
            string nom;
            while (true)
            {
                Console.Write("\nIngrese nombre del libro: ");
                nom = Console.ReadLine();

                if (nom != "" && !ExisteNombre(nom))
                    break;
                else
                    Console.WriteLine("Nombre inválido o ya existe!");
            }

            double pre;
            while (true)
            {
                Console.Write("Ingrese precio del libro: ");
                string input = Console.ReadLine();

                if (input != "" && double.TryParse(input, out pre) && pre >= 0 && pre <= 1000)
                    break;
                else if (input == "")
                    Console.WriteLine("Precio no puede estar vacío!");
                else
                    Console.WriteLine("Precio debe ser entre 0 y 1000!");
            }

            Array.Resize(ref nombres, nombres.Length + 1);
            Array.Resize(ref precios, precios.Length + 1);

            nombres[pos] = nom;
            precios[pos] = pre;
            pos++;

            Console.WriteLine("\nLibro registrado correctamente!");
        }

        public void Mostrar()
        {
            if (nombres.Length == 0)
            {
                Console.WriteLine("\nNo hay libros registrados.");
                return;
            }

            Console.Write("\nPOS\tNOMBRE\t\tPRECIO\n");
            for (int i = 0; i < nombres.Length; i++)
            {
                Console.WriteLine($"{i}\t{nombres[i]}\t\t${precios[i]:F2}");
            }
        }

        public void Modificar()
        {
            if (nombres.Length == 0)
            {
                Console.WriteLine("\nNo hay libros para modificar.");
                return;
            }

            Console.Write("\nIngrese el nombre del libro a modificar: ");
            string mod = Console.ReadLine();

            int indice = -1;
            for (int i = 0; i < nombres.Length; i++)
            {
                if (nombres[i] == mod)
                    indice = i;
            }

            if (indice != -1)
            {
                string nuevoNom;
                while (true)
                {
                    Console.Write("Ingrese nuevo nombre (enter para mantener): ");
                    nuevoNom = Console.ReadLine();

                    if (nuevoNom == "")
                    {
                        nuevoNom = nombres[indice];
                        break;
                    }
                    else if (!ExisteNombre(nuevoNom))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nombre ya existe!");
                    }
                }

                double nuevoPre;
                while (true)
                {
                    Console.Write("Ingrese nuevo precio (enter para mantener): ");
                    string input = Console.ReadLine();

                    if (input == "")
                    {
                        nuevoPre = precios[indice];
                        break;
                    }
                    else if (double.TryParse(input, out nuevoPre) && nuevoPre >= 0 && nuevoPre <= 1000)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Precio debe ser entre 0 y 1000!");
                    }
                }

                nombres[indice] = nuevoNom;
                precios[indice] = nuevoPre;
                Console.WriteLine("\nLibro modificado correctamente.");
            }
            else
            {
                Console.WriteLine("\nNo existe, no se puede modificar");
            }
        }

        public void Eliminar()
        {
            if (nombres.Length == 0)
            {
                Console.WriteLine("\nNo hay libros para eliminar.");
                return;
            }

            Console.Write("\nIngrese el nombre del libro a eliminar: ");
            string eli = Console.ReadLine();

            int indice = -1;
            for (int i = 0; i < nombres.Length; i++)
            {
                if (nombres[i] == eli)
                    indice = i;
            }

            if (indice != -1)
            {
                for (int i = indice; i < nombres.Length - 1; i++)
                {
                    nombres[i] = nombres[i + 1];
                    precios[i] = precios[i + 1];
                }

                Array.Resize(ref nombres, nombres.Length - 1);
                Array.Resize(ref precios, precios.Length - 1);
                pos--;

                Console.WriteLine("\nLibro eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("\nNo existe, no se puede eliminar");
            }
        }

        private bool ExisteNombre(string nombre)
        {
            for (int i = 0; i < nombres.Length; i++)
            {
                if (nombres[i] == nombre)
                    return true;
            }
            return false;
        }
    }
}
