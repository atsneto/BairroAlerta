namespace BairroAlerta.Api.Models
{
    public class Alerta
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
