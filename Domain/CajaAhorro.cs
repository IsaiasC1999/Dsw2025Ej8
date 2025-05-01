namespace Dsw2025Ej8.Domain;

public class CajaAhorro : CuentaBancaria
{

    public CajaAhorro(string numero, decimal saldo, TipoCuenta tipo, string[] titulares): base( numero,  saldo,  tipo,  titulares)
    {
        
    }
        
    public void AplicarInteres()
    {
        
        Saldo += Saldo * TasaDeInteres;
               
    }


    public override void Depositar(decimal monto)
    {
        Saldo += monto;
    }

    public override void Retirar(decimal monto)
    {
        
        Saldo -= monto;
    }
}