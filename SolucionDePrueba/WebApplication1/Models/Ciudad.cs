namespace WebApplication1.Models
{
    public class Ciudad
    {
      public int Id { get; set; }
      public string Nombre { get; set; } = string.Empty;
      public string CodigoPais { get; set; } = string.Empty;
      public string Distrito { get; set; } = string.Empty;
      public long? Poblacion {  get; set; }
    }
}
