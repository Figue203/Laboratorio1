using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.IO;

namespace Laboratorio_1
{
    class Facturacion
    {
        static string ruta4 = "Factura.txt";
     

        static double res = 0;
        static double h;
        static double v = 0;
        static double t = 0;

        static string linea;
        static FileStream Archive;
        static StreamReader Read;
        static StreamWriter Escribir;
        public void nine()
        {
            char mine = 'n';
           
            while (mine != 's')
            {
                Console.WriteLine("----------------------------------------Factura----------------------------------------");
                titulo();
                Console.WriteLine("");
                Console.WriteLine("");
                Correlativo(Completar("Correlativo"));
                NombreCliente(Completar("Nombre del Cliente"));
                NitCliente(Completar("Nit del cliente"));
                Fecha(Completar("Fecha en que fue efectuada la compra"));
                int opcion = 0;
                Market(Completar("Detalle del producto"));
                res = (Val(v));
                double to = (Can(h));
                double Operacion = res * to;
                Sub(Operacion);
                t = t + Operacion;
                Console.Write("El Sub-Total es:" + Operacion);
                Console.WriteLine("");
                opcion = 0;
                Console.WriteLine("Desea salir[s/n]:");
                mine = char.Parse(Console.ReadLine());
                Console.WriteLine("");
            }
            Total(t);
            Console.Write("El Total es:" + t);
            Console.WriteLine("");
        }
        static string Completar(string data)
        {
            Console.WriteLine("Ingrese" + data + ":");
            return (Console.ReadLine());
        }
        public double Val(double data)
        {
            Console.WriteLine("Ingrese Valor del producto" + data + ":");
            return double.Parse(Console.ReadLine());
        }

        public double Can(double data)
        {
            Console.WriteLine("Ingrese Cantidad del producto" + data + ":");
            return double.Parse(Console.ReadLine());
        }
        public void Market(string Producto)
        {
            Escribir = File.AppendText(ruta4);
            Escribir.WriteLine("Detalle del producto:" + Producto);
            Escribir.Close();
        }
        public void titulo()
        {
            Escribir = File.AppendText(ruta4);
            Escribir.WriteLine("----------------------------------------Factura----------------------------------------" );
            Escribir.Close();
        }
        public void Correlativo(string Correlativo)
        {
            Escribir = File.AppendText(ruta4);
            Escribir.WriteLine("Correlativo de la factura:" + Correlativo);
            Escribir.Close();
        }
        public void NombreCliente(string Nombre)
        {
            Escribir = File.AppendText(ruta4);
            Escribir.WriteLine("Nombre del cliente:" + Nombre);
            Escribir.Close();
        }
        public void NitCliente(string Nit)
        {
            Escribir = File.AppendText(ruta4);
            Escribir.WriteLine("Nit del cliente:" + Nit);
            Escribir.Close();
        }
        public void Fecha(string Fecha)
        {
            Escribir = File.AppendText(ruta4);
            Escribir.WriteLine("Fecha en que fue efectuada la compra:" + Fecha);
            Escribir.Close();
        }

        public void Sub(double Subtotal)
        {
            Escribir = File.AppendText(ruta4);
            Escribir.WriteLine("El sub-total es:" + Subtotal);
            Escribir.Close();
        }
        public void Total(double total)
        {
            Escribir = File.AppendText(ruta4);
            Escribir.WriteLine("El total es:" + total);
            Escribir.Close();
        }


    }
}
