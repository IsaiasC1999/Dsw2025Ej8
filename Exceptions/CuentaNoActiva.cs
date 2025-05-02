namespace Dsw2025Ej8.Exceptions;

public class CuentaNoActiva : Exception
{
    public CuentaNoActiva(string estado)
        : base($"No se puede operar con la cuenta {estado}.") { }
}