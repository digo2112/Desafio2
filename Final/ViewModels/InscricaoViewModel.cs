using Final.Helpers;
using Final.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Final.ViewModels
{
    public class InscricaoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand MostrarParticipantesCommand { get; set; }
        public ICommand VoltarCommand { get; set; }
        public event Action RequestClose;

       

       // private List<Participantes> _participantes;
        private ObservableCollection<Participantes> _participantes;
        public ObservableCollection<Participantes> Participantes
        {
            get { return _participantes; }
            set
            {
                _participantes = value;
                OnPropertyChanged(nameof(Participantes));
            }
        }



        private List<Eventos> _eventos;
        public List<Eventos> Eventos
        {
            get { return _eventos; }
            set
            {
                _eventos = value;
                OnPropertyChanged(nameof(Eventos));
            }
        }

        private Eventos _eventoSelecionado;
        public Eventos EventoSelecionado
        {
            get { return _eventoSelecionado; }
            set
            {
                _eventoSelecionado = value;
                OnPropertyChanged(nameof(EventoSelecionado));
                Participantes = new ObservableCollection<Participantes>(_eventoSelecionado?.Participantes);
            }
        }

        public InscricaoViewModel()
        {
            Eventos = CarregarEventos();
            MostrarParticipantesCommand = new RelayCommand(MostrarParticipantes);
            VoltarCommand = new RelayCommand(Voltar);
        }

       
        private void Voltar()
        {
            RequestClose?.Invoke();
        }


        private void MostrarParticipantes()
        {
           
            string directory = @"C:\Users\rodrigo\Desktop\DesafioDeltaFire2\FinalDesafio_3\Desafio3_DB\Participantes";

            // Participantes = new List<Participantes>();
            Participantes = new ObservableCollection<Participantes>();
            Debug.WriteLine($"entrei 1 ");

            foreach (var participanteFile in Directory.EnumerateFiles(directory, "*.json"))
            {
                Debug.WriteLine($"entrei 2 ");
                var participanteJson = File.ReadAllText(participanteFile);
                var participante = JsonConvert.DeserializeObject<Participantes>(participanteJson);
                if (participante != null && participante.EventoSelecionado?.Id == EventoSelecionado.Id)
                {
                    Participantes.Add(participante);
                    Debug.WriteLine($"Participante lido: {JsonConvert.SerializeObject(participante, Formatting.Indented)}");
                }

            }
        }
        private List<Eventos> CarregarEventos()
        {
            string directory = @"C:\Users\rodrigo\Desktop\DesafioDeltaFire2\FinalDesafio_3\Desafio3_DB\Eventos";
            var eventos = new List<Eventos>();

            foreach (var file in Directory.EnumerateFiles(directory, "*.json"))
            {
                var json = File.ReadAllText(file);
                var evento = JsonConvert.DeserializeObject<Eventos>(json);

                // Carregar os participantes do evento
                string participantesDirectory = Path.Combine(directory, $"{evento.Id}");
                if (Directory.Exists(participantesDirectory))
                {
                    foreach (var participanteFile in Directory.EnumerateFiles(participantesDirectory, "*.json"))
                    {
                        var participanteJson = File.ReadAllText(participanteFile);
                        var participante = JsonConvert.DeserializeObject<Participantes>(participanteJson);
                        evento.Participantes.Add(participante);
                    }
                }

                eventos.Add(evento);
            }

            return eventos;
        }
    }
}