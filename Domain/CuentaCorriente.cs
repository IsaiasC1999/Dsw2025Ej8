using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Domain;

public class CuentaCorriente : CuentaBancaria
{
    public decimal LimiteDeDescubierto { get; init; }
    
    public CuentaCorriente(string numero, decimal saldo,string[] titulares) : base(numero, saldo, titulares)
    {
        
    }
    
    public override void Depositar(decimal monto)
    {
        if (Estado != Estado.Activa)
            throw new CuentaNoActiva(Estado.ToString());
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
        if(Estado != Estado.Activa)
            throw new CuentaNoActiva(Estado.ToString());
        if (monto > LimiteDeDescubierto)
            throw new MontoNoValido();
        if (Saldo <= 1)
        {
            this.Estado = Estado.Suspendida;

            throw new SaldoInsuficiente();

        }
         
            Saldo -= monto;

    }

    public override string ToString()
    {
        //return $"Tipo de cuenta: {this.GetType().Name} \n" +
        //    $"Numero de cuenta: {Numero}\n" +
        //    $"Titular/es: {string.Join(", ", Titulares)}\n" +
            return $"Estado de cuenta: {Estado}\n" +
            $"Saldo: {Saldo}\n" +
            $"Comision: {Comision}\n" +
            $"Limite descubierto: {LimiteDeDescubierto}";
    }
}