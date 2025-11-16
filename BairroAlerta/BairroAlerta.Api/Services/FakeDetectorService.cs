using BairroAlerta.Api.Models;

namespace BairroAlerta.Api.Services
{
    public class FakeDetectorService : IDetectorService
    {
        private static readonly string[] Tipos = new[]
        {
            "Roubo",
            "Agressão",
            "Animal Selvagem",
            "Movimentação Estranha"
        };

        public Alerta GerarAlertaFake()
        {
            var random = new Random();
            string tipo = Tipos[random.Next(Tipos.Length)];

            return new Alerta
            {
                Tipo = tipo,
                Descricao = $"Possível ocorrência detectada: {tipo}",
                Data = DateTime.Now
            };
        }
    }
}
