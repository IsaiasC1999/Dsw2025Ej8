namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    
    public string Numero { get; }
    
    public decimal Saldo { get; protected set; }   
    
    public Estado Estado { get; protected set; }
    
    public decimal Comision { get; set; }
    
    public string[] Titulares { get; private set; }
    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        Titulares = titulares;
        
    }
   
    public virtual void Depositar(decimal monto)
    {
       /*  if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += monto;
        }
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            monto -= monto * _comision;
            _saldo += monto;
        }
        */

    }

    public virtual void Retirar(decimal monto)
    {

       /*  if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo -= monto;
        }
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            if (_saldo - monto >= -_limiteDeDescubierto)
            {
                _saldo -= monto;
            }
            if (_saldo < 0)
            {
                _estado = Estado.Suspendida;
            }
        }
        
        */
    }


    

}
