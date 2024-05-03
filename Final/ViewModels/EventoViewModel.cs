using Final.Helpers;
using Final.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Final.ViewModels
{
    public class EventoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateOnly? Data { get; set; }
        public string Local { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Convidados { get; set; }
        public int Capacidade { get; set; }
        public List<Participantes> Participantes { get; set; }

        public event Action RequestClose;
        public event Action<string> ShowMessage;

        public ICommand ConfirmarCommand { get; set; }
        public ICommand ResetarCommand { get; set; }
        public ICommand VoltarCommand { get; set; }

        public EventoViewModel()
        {
            ConfirmarCommand = new RelayCommand(Confirmar);
            ResetarCommand = new RelayCommand(Resetar);
            VoltarCommand = new RelayCommand(Voltar);
        }



        private void Voltar()
        {
            RequestClose?.Invoke();
        }


        private void Confirmar()
        {
            try
            {
                if (string.IsNullOrEmpty(Nome) ||
                                // !Data.HasValue ||
                                string.IsNullOrEmpty(Local))
                {
                    ShowMessage?.Invoke("Nome e Local devem ser preenchidos.");
                    return;
                }



                Eventos evento = new Eventos
                {
                    Id = Guid.NewGuid(),
                    Nome = Nome,
                    Descricao = Descricao,
                    Data = Data.HasValue ? Data.Value : default,
                    Local = Local,
                    Cidade = Cidade,
                    Estado = Estado,
                    Convidados = Convidados,
                    Capacidade = Capacidade,
                    Participantes = Participantes
                };

                string json = JsonConvert.SerializeObject(evento);
                string tempPath = Environment.GetEnvironmentVariable("TEMP");
                string directory = Path.Combine(tempPath, "Desafio2_JSON_DB", "Eventos");
                //string directory = @"C:\Users\rodrigo\Desktop\DesafioDeltaFire2\FinalDesafio_3\Desafio3_DB\Eventos";
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText($@"{directory}\{evento.Id}.json", json);
                ShowMessage?.Invoke("Evento cadastrado com sucesso!");
                RequestClose?.Invoke();
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Erro ao salvar o participante: {ex.Message}");
            }
        }

        public void Resetar()
        {
            Nome = string.Empty;
            Descricao = string.Empty;
            Data = null;
            Local = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;
            Convidados = 0;
            Capacidade = 0;
            Participantes = new List<Participantes>();
        }
    }
}