namespace Dsw2025Ej8.Exceptions;

public class SaldoInsuficiente : Exception
{
    public SaldoInsuficiente()
        : base("La cuenta no cuenta con saldo para la operación solicitada. Fue suspendida.") { }
}
