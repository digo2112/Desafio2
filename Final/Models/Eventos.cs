

namespace Final.Models
{
    public class Eventos
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateOnly Data { get; set; }
        public string Local { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Confirmados { get; set; }
        public int Convidados { get; set; }
        public int Capacidade { get; set; }
        public List<Participantes> Participantes { get; set; }
    }
}
