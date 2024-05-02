using Final.Views;
using Final.Helpers;
using System.Windows;

namespace Final

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnCadastroEventos_Click(object sender, RoutedEventArgs e)
        {
            // Abra a janela de cadastro de eventos
            EventoView eventoView = new EventoView();
            eventoView.Show();
            this.Close();
        }

        private void btnCadastroParticipantes_Click(object sender, RoutedEventArgs e)
        {
            // Abra a janela de cadastro de participantes
            ParticipanteView participanteView = new ParticipanteView();
            participanteView.Show();
            this.Close();
        }

        private void btnEventos_Click(object sender, RoutedEventArgs e)
        {
            // Abra a janela de eventos
            InscricaoView inscricaoView = new InscricaoView();
            inscricaoView.Show();
            this.Close();
        }

    }
}

