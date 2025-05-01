using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Domain;

public class CuentaCorriente : CuentaBancaria
{
    public decimal LimiteDeDescubierto { get; private set; }
    
    public CuentaCorriente(string numero, decimal saldo, TipoCuenta tipo, string[] titulares) : base(numero,  saldo,  tipo, titulares)
    {
        
    }
    
    public override void Depositar(decimal monto)
    {
        try
        {
            if (monto <= 0)
                throw new MontoNoValido();
            monto -= monto * Comision;
            Saldo += monto;
        }
        catch (MontoNoValido e)
        {
            Console.WriteLine(e.Message);
            
        }
        
        
    }
    
    public override void Retirar(decimal monto)
    {
        if (Saldo - monto >= -LimiteDeDescubierto)
        {
            Saldo -= monto;
        }
        if (Saldo < 0)
        {
            Estado = Estado.Suspendida;
        }

    }
}