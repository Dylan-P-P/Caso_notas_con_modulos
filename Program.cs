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
            string titulo = "REGISTRO DE ESTUDIANTES";
            int posicion = (Console.WindowWidth - titulo.Length) / 2;
            Console.SetCursorPosition(posicion, Console.CursorTop);
            Console.WriteLine(titulo);

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
            string titulo = "GUARDAR ARCHIVO";
            int posicion = (Console.WindowWidth - titulo.Length) / 2;
            Console.SetCursorPosition(posicion, Console.CursorTop);
            Console.WriteLine(titulo);
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
        public static void cargarRegistros()
        {
            string titulo = "CARGAR ARCHIVO";
            int posicion = (Console.WindowWidth - titulo.Length) / 2;
            Console.SetCursorPosition(posicion, Console.CursorTop);
            Console.WriteLine(titulo);
            Console.WriteLine("Cargar registros desde archivo");
            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine("No se encontró el archivo de registros.");
                return;
            }
            total_estudiantes = 0;
            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null && total_estudiantes < max_estudiantes)
                {
                    string[] partes = linea.Split(',');
                    if (partes.Length == max_cursos + 1)
                    {
                        estudiante[total_estudiantes] = partes[0];
                        for (int i = 0; i < max_cursos; i++)
                        {
                            matrizNotas[total_estudiantes, i] = Convert.ToDouble(partes[i + 1]);
                        }
                        total_estudiantes++;
                    }
                }
            }
            Console.WriteLine("Se cargaron los registros del archivo..!!");
        }
        public static void mostrarRegistros()
        {
            string titulo = "MOSTRAR REGISTRO";
            int posicion = (Console.WindowWidth - titulo.Length) / 2;
            Console.SetCursorPosition(posicion, Console.CursorTop);
            Console.WriteLine(titulo);

            Console.WriteLine(new string('=', 100));
            Console.WriteLine("\t\t\tREGISTRO GENERAL DE NOTAS POR CURSO");
            Console.WriteLine(new string('=', 100));
            if(total_estudiantes == 0)
            {
                Console.WriteLine("No hay estudiantes registrados para mostrar.");
                return;
            }
            Console.Write($"{"ESTUDIANTE",-25}|");
            for (int i = 0; i < max_cursos; i++)
            {
                Console.Write($"{nombreCursos[i],-14}|");
            }
            Console.WriteLine("PROMEDIO");
            Console.WriteLine(new string('-', 100));
            for (int i = 0; i < total_estudiantes; i++)
            {
                Console.Write($"{estudiante[i],-25}|");
                double suma = 0;
                for (int j = 0; j < max_cursos; j++)
                {
                    Console.Write($"{matrizNotas[i, j],-14}|");
                    suma += matrizNotas[i, j];
                }
                double promedio = suma / max_cursos;
                string estado = promedio >= 12 ? "APROBADO" : "DESAPROBADO";
                Console.WriteLine($"{promedio:F2}({estado})");
            }
        }
        public static void titulo()
        {
            string titulo = "REGISTRO DE NOTAS";
            int posicion = (Console.WindowWidth - titulo.Length) / 2;
            Console.SetCursorPosition(posicion, Console.CursorTop);
            Console.WriteLine(titulo);
        }
        static void Main(string[] args)
        {
            int opc = 0;
            while (opc != 5)
            {
                Console.Clear();
                titulo();
                Console.WriteLine("[1]REGISTRAR ESTUDIANTE");
                Console.WriteLine("[2]GUARDAR EN ARCHIVO");
                Console.WriteLine("[3]CARGAR REGISTROS DEL ARCHIVO");
                Console.WriteLine("[4]MOSTRAR REGISTROS");
                Console.WriteLine("[5]SALIR");
                opc = Validador.LeerEntero("Seleccionar opcion [1-5]: ");
                switch (opc)
                {
                    case 1:
                        RegistrarEstudiante();
                        break;
                    case 2:
                        guardarArchivo();
                        break;
                    case 3:
                        cargarRegistros();
                        break;
                    case 4:
                        mostrarRegistros();
                        break;
                    case 5:
                        Console.WriteLine("Muchos exitos para el nuevo semestre");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
