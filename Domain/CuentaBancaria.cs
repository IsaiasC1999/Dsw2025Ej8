namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public string Numero { get; }
    public decimal Saldo { get; protected set; }

    public Estado Estado;
    public decimal TasaDeInteres { get;  set; }
    public decimal LimiteDeDescubierto { get; set; }
    public decimal Comision { get; set; }
    public string[] Titulares { get; }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }
    #region Getters/Setters
  
    #endregion

    public virtual void Depositar(decimal monto)
    {
      
       
    }

    public virtual void Retirar(decimal monto)
    {
      
    }

   
}
