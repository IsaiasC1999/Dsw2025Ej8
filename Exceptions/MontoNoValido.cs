using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8.Exceptions;

public class MontoNoValido : Exception
{
    public MontoNoValido()
        : base("El monto ingresado no es válido para la operación solicitada.") { }
    

}