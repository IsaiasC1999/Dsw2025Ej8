using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Domain;

public class CajaAhorro : CuentaBancaria
{
    public decimal TasaDeInteres { get; init; } 

    public CajaAhorro(string numero, decimal saldo, string[] titulares): base( numero,  saldo,  titulares)
    {
        
    }
        
    public void AplicarInteres()
    {
        
        Saldo += Saldo * TasaDeInteres;
               
    }


    public override void Depositar(decimal monto)
    {
        if (monto <= 0)
            throw new MontoNoValido();
        if (Estado != Estado.Activa)
            throw new CuentaNoActiva(Estado.ToString());
        Saldo += monto;
        //try
        //{

        //}
        //catch (MontoNoValido e)
        //{
        //    Console.WriteLine(e.Message);

        //}
        //catch (CuentaNoActiva e) 
        //{
        //    Console.WriteLine(e.Message);
        //}

    }

    public override void Retirar(decimal monto)
    {
        if (Estado != Estado.Activa)
            throw new CuentaNoActiva(Estado.ToString());
        if (Saldo <= 1)
        {
            Estado = Estado.Suspendida;
            throw new SaldoInsuficiente();
        }
        Saldo -= monto;
    }
    public override string ToString()
    {
        //return $"Tipo de cuenta: {this.GetType().Name} \n" +
        //    $"Numero: {Numero}\n" +
        //    $"Titular/es: {string.Join(", ", Titulares)}\n" +
            return $"Estado de cuenta: {Estado}\n" +
            $"Saldo: {Saldo}\n" +
            $"Comision: {Comision}\n" +
            $"Tasa de interes: {TasaDeInteres}";
    }


}