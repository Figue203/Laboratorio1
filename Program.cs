using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Laboratorio_1
{
    class Program
    {
        static string ruta1 = "Administradores.txt";
        static string ruta2 = "Trabajadores.txt";
        static string ruta3 = "Inventario.txt";
        static string ruta4 = "Factura.txt";
        static string ruta5 = "temporal.txt";


        static FileStream Archive;
        static StreamReader Read;
        static StreamWriter Escribir;

        static double Passadmin = 12005;
        static double PassTra = 123456789;
        static double Ad, Trab;

        static Inventario Inv = new Inventario();
        static Facturacion Fct = new Facturacion();


        static void Main(string[] args)
        {
            char op = 'n';
            int opcion = 0;
            int Num = 0;
            int nummer = 0;
            int broj = 0, ñum = 0;


            while (op != 's')
            {
                Console.WriteLine("");
                Console.WriteLine("¿Que desea realizar?\n1.-Usuario Nuevo\n2.-Usuario Existente");
                Console.Write("opcion:");
                opcion = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                if (opcion == 1)
                {
                    Console.WriteLine("¿Que usuario desea crear?\n1.-Administrador\n2.-Trabajador");
                    Console.Write("opcion:");
                    Num = int.Parse(Console.ReadLine());

                    if (Num == 1)
                    {
                        SavingUser(Completar("Nombre Completo"), Completar("Usuario"), Completar("Cargo"), Completar("Telefono"), Completar("Direccion"), Completar("Correo"), ruta1);
                        Console.WriteLine("\n" + Leerve(ruta1));
                    }
                    if (Num == 2)
                    {
                        SavingUser(Completar("Nombre Completo"), Completar("Usuario"), Completar("Cargo"), Completar("Telefono"), Completar("Direccion"), Completar("Correo"), ruta2);
                        Console.WriteLine("\n" + Leerve(ruta2));
                    }
                }

                if (opcion == 2)
                {
                    Console.WriteLine("¿Como desea entrar?\n1.-Administrador\n2.-Trabajador");
                    Console.Write("opcion:");
                    nummer = int.Parse(Console.ReadLine());

                    if (nummer == 1)
                    {
                        Console.WriteLine(SearchAdmini(Completar("Usuario ")));
                        if (Ad == Passadmin)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("¡Contraseña Correcta!");
                            Console.WriteLine("");
                            Console.WriteLine("¡Bienvenido Administrador!");
                            Console.WriteLine("");
                            Console.WriteLine("¿Que desea hacer a continuación?\n1.-Mostrar Usuarios\n2.-Mostrar Factura\n3.-Mostrar Inventario\n4.-Ingresar Usuarios nuevos");
                            Console.Write("opcion:");
                            broj = int.Parse(Console.ReadLine());

                            if (broj == 1)
                            {   
                                Console.WriteLine("");
                                Console.WriteLine("Estos son todos los trabajadores:");
                                Console.WriteLine(Leerve(ruta2));
                            }
                            else if (broj == 2)
                            {
                                Console.WriteLine("");
                                Console.WriteLine(Leerve(ruta4));
                            }
                            else if (broj == 3)
                            {
                                Console.WriteLine("");
                                Console.WriteLine(Leerve(ruta3));
                            }
                            else if (broj == 4)
                            {
                                Console.WriteLine("¿Que usuario desea crear?\n1.-Administrador\n2.-Trabajador");
                                Console.Write("opcion:");
                                ñum = int.Parse(Console.ReadLine());

                                if (ñum == 1)
                                {
                                    SavingUser(Completar("Nombre Completo"), Completar("Usuario"), Completar("Cargo"), Completar("Telefono"), Completar("Direccion"), Completar("Correo"), ruta1);
                                    Console.WriteLine("\n" + Leerve(ruta1));
                                }
                                if (ñum == 2)
                                {
                                    SavingUser(Completar("Nombre Completo"), Completar("Usuario"), Completar("Cargo"), Completar("Telefono"), Completar("Direccion"), Completar("Correo"), ruta2);
                                    Console.WriteLine("\n" + Leerve(ruta2));
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Revise si los datos ingresados son los correctos.");
                            Console.WriteLine("");
                        }
                    }
                    if (nummer == 2)
                    {
                        Console.WriteLine(SearchTrab(Completar("Usuario")));
                        if (Trab == PassTra)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("¡Contraseña Correcta!");
                            Console.WriteLine("");
                            Console.WriteLine("¡Bienvenido Trabajador!");
                            Console.WriteLine("");
                            Console.WriteLine("¿Que desea hacer a continuación?\n1.-Cargar inventario\n2.-Facturar Productos");
                            Console.Write("opcion:");
                            broj = int.Parse(Console.ReadLine());

                            if (broj == 1)
                            {
                                Console.WriteLine("");
                                Inv.Invastment();
                            }
                            else if (broj == 2)
                            {
                                Console.WriteLine("");
                                Fct.nine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Revise si los datos ingresados son los correctos.");
                            Console.WriteLine("");
                        }
                    }
                }

                op = menu();
            }
        }

        static string Completar(string data)
        {
            Console.WriteLine("Ingrese" + data + ":");
            return (Console.ReadLine());
        }
        static void SavingUser(string nombre, string usuario, string cargo, string direccion, string Telefono, string correo, string b)
        {
            Escribir = File.AppendText(b);
            Escribir.WriteLine(nombre + "-" + usuario + "-" + cargo + "-" + direccion + "-" + Telefono + "-" + correo);
            Escribir.Close();
        }

        static string Leerve(string b)
        {
            string linea = "";
            Archive = new FileStream(b, FileMode.Open, FileAccess.Read);
            Read = new StreamReader(Archive);
            linea = Read.ReadToEnd();
            Read.Close();
            return linea;
        }

        static char menu()
        {
            Console.WriteLine("Desea salir[s/n]:");
            return (char.Parse(Console.ReadLine()));
        }
        static string SearchAdmini(string Usuario)
        {
            string linea = "Usuario no encontrado, revise que su usuario no haya sido modificado o eliminado.";
            Read = File.OpenText(ruta1);
            linea = Read.ReadLine();

            while (linea != null)
            {
                string[] Ape = linea.Split('-');

                if (Ape[1] == Usuario)
                {
                    Console.WriteLine("Usuario Encontrado:" + Ape[0] + "-" + Ape[1] + "-" + Ape[2] );
                    Console.WriteLine("");
                    Console.WriteLine("Ingrese contraseña:");
                    Ad = double.Parse(Console.ReadLine());
                }
                linea = Read.ReadLine();
            }

            Read.Close();
            return linea;
        }
        static string SearchTrab(string Usuario)
        {
            string linea = "Usuario no encontrado, revise que su usuario no haya sido modificado o eliminado.";
            Read = File.OpenText(ruta2);
            linea = Read.ReadLine();

            while (linea != null)
            {
                string[] Ape = linea.Split('-');

                if (Ape[1] == Usuario)
                {
                    Console.WriteLine("Usuario Encontrado:" + Ape[0] + "-" + Ape[1] + "-" + Ape[2]);
                    Console.WriteLine("");
                    Console.WriteLine("Ingrese contraseña:");
                    Trab = double.Parse(Console.ReadLine());
                }
                linea = Read.ReadLine();
            }

            Read.Close();
            return linea;

        }
    }
}
