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
            // Mostrar resumen con clase anónima
            Console.WriteLine("==== RESUMEN DE CUENTAS ====\n");
            foreach (var resumen in cuenta.Select(c => new
            {
                Numero = c.Numero,
                Tipo = c.GetType().Name,
                Saldo = c.Saldo
            }))
            {
                Console.WriteLine($"Cuenta Nº {resumen.Numero} | Tipo: {resumen.Tipo} | Saldo: ${resumen.Saldo}");
            }

            Console.WriteLine("\nPresione una tecla para continuar con las operaciones...");
            Console.ReadKey();
            Console.Clear();

            foreach (var cuentaBancaria in cuenta)
            {
                MostrarTituloCuenta(cuentaBancaria);

                RealizarOperacion("Realizar depósito de 1000", () => cuentaBancaria.Depositar(1000M), cuentaBancaria);

                if (cuentaBancaria.GetType() == typeof(CuentaCorriente))
                {
                    CuentaCorriente cuentaCorriente = (CuentaCorriente)cuentaBancaria;
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
                                $"Numero de cuenta: {cuentaa.Numero} - " +
                                $"Tipo de cuenta: {cuentaa.GetType().Name} ");
            Console.WriteLine();
        }

        private static void RealizarOperacion(string mensaje, Action accion, CuentaBancaria cuenta1)
        {
            MostrarTituloCuenta(cuenta1);

            Console.WriteLine($"--- {mensaje} ---\n\n");
            Console.WriteLine(cuenta1);

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            try
            {
                accion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERROR] {ex.Message}\n");
            }

            Console.WriteLine(cuenta1);
            Console.WriteLine("\nPresione una tecla... \n");
            Console.ReadKey();
            Console.Clear();
        }

       
    }
}
