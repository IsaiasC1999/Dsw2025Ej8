using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CuentaBancaria[] cuenta = { new CajaAhorro("12123", 100000.2M, ["cristian"]) {TasaDeInteres = 0.05M },
                new CajaAhorro("0031", 5000M, ["Matias"]){TasaDeInteres = 0.6M},
                new CuentaCorriente("0122",30000,["Isaias"]){LimiteDeDescubierto = 300M},
                new CuentaCorriente("007",233.3M,["Isaias","Matias","Cristian"]){LimiteDeDescubierto = 200}
            };
            Diisplay(cuenta);

        }

        public static void Diisplay(CuentaBancaria[] cuenta)
        {
            foreach (var cuentaBancaria in cuenta)
            {
                MostrarTituloCuenta(cuentaBancaria);

                RealizarOperacion("Realizar depósito de 1000", () => cuentaBancaria.Depositar(1000M), cuentaBancaria);

                if(cuentaBancaria.GetType() == typeof(CuentaCorriente))
                {
                    CuentaCorriente cuentaCorriente = (CuentaCorriente) cuentaBancaria;
                    RealizarOperacion("Retirar mitad del limite", () => cuentaBancaria.Retirar(cuentaCorriente.LimiteDeDescubierto / 2), cuentaBancaria);
                    RealizarOperacion("Intentar retirar mas del limite", () => cuentaBancaria.Retirar(cuentaCorriente.LimiteDeDescubierto + 1), cuentaBancaria);

                }
                RealizarOperacion("Retirar todo el saldo", () => cuentaBancaria.Retirar(cuentaBancaria.Saldo), cuentaBancaria);
                if (cuentaBancaria.Saldo == 0)
                {

                    RealizarOperacion("Retirar dinero sin tener saldo", () => cuentaBancaria.Retirar(12M), cuentaBancaria);

                }
                if (cuentaBancaria.Estado == Estado.Suspendida)
                {
                    RealizarOperacion("Realizar depósito con cuenta suspendida", () => cuentaBancaria.Depositar(1000M), cuentaBancaria);

                }
            }
        }

        private static void MostrarTituloCuenta(CuentaBancaria cuentaa)
        {
            Console.Clear();
            Console.SetCursorPosition(20, Console.CursorTop);
            Console.WriteLine($"Titular/es de la cuenta: {string.Join(", ", cuentaa.Titulares).ToUpper()} - " +
                                $"Numero de cuenta: {cuentaa.Numero} - "+
                                $"Tipo de cuenta: {cuentaa.GetType().Name} ");
            Console.WriteLine();
        }

        private static void RealizarOperacion(string mensaje, Action accion, CuentaBancaria cuenta1)
        {
            MostrarTituloCuenta(cuenta1);

            Console.WriteLine($"--- {mensaje} ---");
            Console.WriteLine(cuenta1);

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            try
            {
                accion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERROR] {ex.Message}");
            }

            Console.WriteLine(cuenta1);
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        //public static void Diisplay(CuentaBancaria[] cuenta)
        //{
        //    foreach (var cuentaBancaria in cuenta)
        //    {
        //        MostrarTituloCuenta(cuentaBancaria);

        //        RealizarOperacion("Realizar depósito de 1000", () => cuentaBancaria.Depositar(1000M), cuentaBancaria);

        //        RealizarOperacion("Retirar todo el saldo", () => cuentaBancaria.Retirar(cuentaBancaria.Saldo), cuentaBancaria);

        //        RealizarOperacion("Retirar dinero sin tener saldo", () => cuentaBancaria.Retirar(12M), cuentaBancaria);

        //        RealizarOperacion("Realizar depósito con cuenta suspendida", () => cuentaBancaria.Depositar(1000M), cuentaBancaria);
        //    }
        //}

        //private static void MostrarTituloCuenta(CuentaBancaria cuentaa)
        //{
        //    Console.Clear();
        //    Console.SetCursorPosition(20, Console.CursorTop);
        //    Console.WriteLine($"TITULAR DE CUENTA: {string.Join(", ", cuentaa.Titulares)}".ToUpper());
        //    Console.WriteLine($"\n{cuentaa}\n");
        //}

        //private static void RealizarOperacion(string mensaje, Action accion, CuentaBancaria cuenta1)
        //{
        //    Console.WriteLine(mensaje);
        //    Console.ReadKey();

        //    try
        //    {
        //        accion();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"[ERROR] {ex.Message}");
        //    }

        //    Console.WriteLine($"\n{cuenta1}\n");
        //    Console.WriteLine("Presione una tecla para continuar...");
        //    Console.ReadKey();
        //    Console.Clear();
        //}


        //public static void Display(CuentaBancaria[] cuentas)
        //{
        //    foreach (CuentaBancaria cuenta in cuentas)
        //    {
        //        Console.SetCursorPosition(20, Console.CursorTop); // mueve el cursor 20 columnas a la derecha
        //        Console.WriteLine($"TITULAR DE CUENTA: {string.Join(", ", cuenta.Titulares)}".ToUpper());

        //        Console.WriteLine($"\n {cuenta}\n");
        //        Console.WriteLine("Realizar deposito de 1000");
        //        Console.ReadKey();
        //        cuenta.Depositar(1000M);
        //        Console.WriteLine($"\n {cuenta}\n");
        //        Console.ReadKey();

        //        Console.Clear();

        //        Console.SetCursorPosition(20, Console.CursorTop); // mueve el cursor 20 columnas a la derecha
        //        Console.WriteLine($"TITULAR DE CUENTA: {string.Join(", ", cuenta.Titulares)}".ToUpper());
        //        Console.WriteLine($"\n {cuenta}\n");
        //        Console.WriteLine("Retirar todo el saldo");
        //        Console.ReadKey();
        //        try
        //        {
        //            cuenta.Retirar(cuenta.Saldo);

        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //        Console.WriteLine($"\n {cuenta}\n");
        //        Console.ReadKey();

        //        Console.Clear();

        //        Console.SetCursorPosition(20, Console.CursorTop); // mueve el cursor 20 columnas a la derecha
        //        Console.WriteLine($"TITULAR DE CUENTA: {string.Join(", ", cuenta.Titulares)}".ToUpper());
        //        Console.WriteLine($"\n {cuenta}\n");
        //        Console.WriteLine("Retirar dinero sin tener saldo\n");
        //        Console.ReadKey();
        //        try
        //        {
        //            cuenta.Retirar(12M);

        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //        Console.WriteLine($"\n {cuenta}\n");
        //        Console.ReadKey();
        //        Console.Clear();
        //        Console.WriteLine($"\n {cuenta}\n");
        //        Console.WriteLine("Realizar deposito con cuenta suspendida\n");
        //        try
        //        {
        //            cuenta.Depositar(1000);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //        Console.ReadKey();
        //        Console.Clear();
        //    }
        //}
    }
}
