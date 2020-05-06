using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace Laboratorio_1
{
    class Inventario
    {
        static string ruta3 = "Inventario.txt";
        static string ruta5 = "temporal.txt";

        static string linea;
        static FileStream Archive;
        static StreamReader Read;
        static StreamWriter Escribir;

        public void Invastment()
        {
            int opcion = 0;
            double h = 0;
            char mine = 'n';

            while (mine != 's')
            {
                Console.WriteLine("1.-Guardar registo\n2.-Actualizar registro");
                Console.Write("opcion:");
                opcion = int.Parse(Console.ReadLine());
                
                if(opcion == 1)
                {
                    Console.WriteLine("----------------------------------------INVENTARIO----------------------------------------");
                    Console.WriteLine("");
                    SavingUser(Completar("Detalles del producto"), Completar("Cantidad"), Completar("Precio"),ruta3);
                }
                else if(opcion == 2)
                {
                        string cadena, producto, nuevaca;
                        bool encontrado;
                        encontrado = false;
                        string[] campos = new string[3];
                        char[] separador = { '-' };
                        Read = File.OpenText(ruta3);
                        Escribir = File.CreateText(ruta5);
                        Console.WriteLine("Ingresa el nombre del producto:");
                        producto = Console.ReadLine();
                        cadena = Read.ReadLine();
                        while (cadena != null)
                        {
                            campos = cadena.Split(separador);
                            if (campos[0].Trim().Equals(producto))
                            {
                            encontrado = true;
                            Console.WriteLine("****************");
                            Console.WriteLine("");
                            Console.WriteLine("*Se encontro el registro*");
                            Console.WriteLine("");
                            Console.WriteLine("Producto:"+campos[0].Trim());
                            Console.WriteLine("cantidad:" + campos[1].Trim());
                            Console.WriteLine("Precio:" + campos[2].Trim());
                            Console.WriteLine("");
                            Console.WriteLine("****************");

                            Console.WriteLine("Ingrese existencia:");
                            nuevaca = Console.ReadLine();
                            Escribir.WriteLine(campos[0] + "-"+ nuevaca+"-" +campos[2]);
                            Console.WriteLine("Resgistro actualizado");
                           
                            }
                            else
                            {
                                Escribir.WriteLine(cadena);
                            }
                            cadena = Read.ReadLine();
                        }

                        if (encontrado == false)
                        {
                            Console.WriteLine("El producto no se encuentra");
                        }
                        Read.Close();
                        Escribir.Close();
                    File.Delete(ruta3);
                    File.Move(ruta5, ruta3);
                    
                }
                
                opcion = 0;
                Console.WriteLine("Desea salir[s/n]:");
                mine = char.Parse(Console.ReadLine());
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
        public void titulo()
        {
            Escribir = File.AppendText(ruta3);
            Escribir.WriteLine("----------------------------------------INVENTARIO----------------------------------------");
            Escribir.Close();
        }
        static string Completar(string data)
        {
            Console.WriteLine("Ingrese" + data + ":");
            return (Console.ReadLine());
        }

        static void SavingUser(string producto, string cantidad, string Precio,string b)
        {
            Escribir = File.AppendText(b);
            Escribir.WriteLine(producto+ "-" +  "-" + cantidad+ "-" + Precio);
            Escribir.Close();
        }
    }
}

