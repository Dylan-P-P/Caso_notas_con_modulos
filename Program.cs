using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caso_notas_con_modulos
{
    internal class Program
    {
        static int max_estudiantes = 40;
        static int max_cursos = 4;
        static string[] nombreCursos = { "Matemáticas", "Programación", "Física", "Base de Datos" };
        static string[] estudiante = new string[max_estudiantes];
        static double[,] matrizNotas = new double[max_estudiantes, max_cursos];
        static int total_estudiantes = 0;
        static string rutaArchivo = "notas_curso.txt";

        public static void RegistrarEstudiante()
        {
            Console.WriteLine("REGISTRO DE ESTUDIANTES");
            if (total_estudiantes >= max_estudiantes)
            {
                Console.WriteLine("Se ha alcanzado el límite máximo de estudiantes.");
                return;
            }
            string nombre = Validador.LeerTexto("Ingresar nombre y apellidos del estudiante: ");
            estudiante[total_estudiantes] = nombre;
            Console.WriteLine("Ingresar las notas de 0 a 20");
            for (int i = 0; i < max_cursos; i++)
            {
                matrizNotas[total_estudiantes, i] = Validador.LeerDecimales($"Ingresar nota de {nombreCursos[i]}: ");
            }
            total_estudiantes++;
            Console.WriteLine("Estudiante Registrado");
        }

        public static void guardarArchivo()
        {
            Console.WriteLine("Guardar registros en archivo");
            if (total_estudiantes == 0)
            {
                Console.WriteLine("No hay estudiantes registrados para guardar.");
                return;
            }
            using (StreamWriter escritor = new StreamWriter(rutaArchivo))
            {
                for (int i = 0; i < total_estudiantes; i++)
                {
                    string linea = estudiante[i];
                    for (int j = 0; j < max_cursos; j++)
                    {
                        linea += $",{matrizNotas[i, j]}";
                        //linea += "," + matrizNotas[i, j]; ---> " hace lo mismo que la línea de arriba/anterior "
                    }
                    escritor.WriteLine(linea);
                }
            }
            Console.WriteLine("Registros guardados..!!");
        }
        static void Main(string[] args)
        {

        }
    }
}
