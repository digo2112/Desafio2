
namespace Final.Models
{
    public class Participantes
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Observacoes { get; set; }
        public bool IsConfirmado { get; set; }
        public Eventos EventoSelecionado { get; set; }

        public List<Eventos> Eventos { get; set; }
    }
}
