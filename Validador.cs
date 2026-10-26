using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caso_notas_con_modulos
{
    internal class Validador
    {
        public static int LeerEntero(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor < 1 || valor > 5)
                    {
                        Console.WriteLine("Error: El valor debe ser entre 1 y 5.");
                        continue;
                    }
                    return valor;
                }
                Console.WriteLine("Error: Ingrese un número entero válido.");
            }
        }
        public static double LeerDecimales(string mensaje)
        {
            double valor;
            while (true)
            {
                Console.Write(mensaje);
                if (double.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor < 0 || valor > 20)
                    {
                        Console.WriteLine("Error: El valor debe ser entre 0 y 20.");
                        continue;
                    }
                    return valor;
                }
                Console.WriteLine("Error: Ingrese un número decimal válido.");
            }
        }
        public static string LeerTexto(string mensaje)
        {
            Console.Write(mensaje);
            while (true)
            {
                string texto = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(texto))
                {
                    return texto;
                }
                Console.WriteLine("Error: Este campo no puede estar vacío");
            }
        }
    }
}
