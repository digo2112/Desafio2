using System.Windows.Input;
using Final.Models;
using System.IO;
using System.Text.Json;
using Final.Views;
using Final.Helpers;
using System.Windows;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using Final;

public class ParticipanteViewModel
{
    public List<Eventos> Eventos { get; set; }
    public Participantes Participante { get; set; }
    public ICommand VoltarCommand { get; set; }
    public ICommand ResetarCommand { get; set; }
    public ICommand ConfirmarCommand { get; set; }

    public Window Window { get; set; }


    // public ParticipanteViewModel(Window window)
    public ParticipanteViewModel()
    {
        
        Participante = new Participantes();

        Eventos = GetEventos();

        VoltarCommand = new RelayCommand(Voltar);
        ResetarCommand = new RelayCommand(Resetar);
        ConfirmarCommand = new RelayCommand(Confirmar);
      
    }

    private List<Eventos> GetEventos()
    {
        string directory = @"C:\Users\rodrigo\Desktop\DesafioDeltaFire2\FinalDesafio_3\Desafio3_DB\Eventos";
        var eventos = new List<Eventos>();

        if (Directory.Exists(directory))
        {
            var files = Directory.GetFiles(directory, "*.json");

            foreach (var file in files)
            {
                var json = File.ReadAllText(file);
                var evento = JsonConvert.DeserializeObject<Eventos>(json);
                eventos.Add(evento);
            }
        }

        return eventos;
    }

    private void Voltar()
    {
    
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Window.Close();
    }

    private void Resetar()
    {
     
        Participante.Id = Guid.Empty;
        Participante.Nome = string.Empty;
        Participante.CPF = string.Empty;
        Participante.Email = string.Empty;
        Participante.Endereco = string.Empty;
        Participante.Telefone = string.Empty;
        Participante.Cidade = string.Empty;
        Participante.Estado = string.Empty;
        Participante.Observacoes = string.Empty;
        Participante.IsConfirmado = false;
    }

    public void Confirmar()
    {
        try
        {
            if (string.IsNullOrEmpty(Participante.Nome) )
            {
                MessageBox.Show("Campo Nome deve ser preenchido.");
                return;
            }

            if (Participante.EventoSelecionado == null)
            {
                MessageBox.Show("Selecione um evento!");
                return;
            }

            Participantes participante = new Participantes
            {
                Id = Guid.NewGuid(),
                Nome = Participante.Nome,
                CPF = Participante.CPF,
                Email = Participante.Email,
                Endereco = Participante.Endereco,
                Telefone = Participante.Telefone,
                Cidade = Participante.Cidade,
                Estado = Participante.Estado,
                Observacoes = Participante.Observacoes,
                IsConfirmado = Participante.IsConfirmado,
                EventoSelecionado = Participante.EventoSelecionado
            };

            string json = JsonConvert.SerializeObject(participante, Formatting.Indented);

            string directory = @"C:\Users\rodrigo\Desktop\DesafioDeltaFire2\FinalDesafio_3\Desafio3_DB\Participantes";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText($@"{directory}\{participante.Id}.json", json);
            MessageBox.Show("Participante cadastrado com sucesso!");

            Resetar();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar o participante: {ex.Message}");
        }
    }
}