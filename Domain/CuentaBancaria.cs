namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    
    public TipoCuenta Tipo { get; private set; }
    
    public string Numero { get; private set; }
    
    public decimal Saldo { get;  set; }  
    
    public Estado Estado { get;  set; }
    
    public decimal TasaDeInteres { get; set; }
    
   
    
    public decimal Comision { get; set; }
    
    public string[] Titulares { get; private set; }
    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Tipo= tipo;
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
