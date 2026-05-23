using System.ComponentModel.DataAnnotations;

namespace GestorPagoProveedores.Data;

public class Proveedor
{
    [Key] // <-- Ahora "Cod" es la llave primaria, eliminamos el Id anterior
    public string Cod { get; set; } = string.Empty; 
    
    public string Rut { get; set; } = string.Empty;
    public string NombreEmpresa { get; set; } = string.Empty;
    public string CodigoBanco { get; set; } = string.Empty;
    public string BancoDestino { get; set; } = string.Empty;
    public string CuentaDestino { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
}

public class Banco
{
    [Key]
    public string Codigo { get; set; } = string.Empty;
    public string NombreBanco { get; set; } = string.Empty;
}