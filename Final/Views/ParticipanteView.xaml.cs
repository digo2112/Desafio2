
using System.Windows;

namespace Final.Views
{
    /// <summary>
    /// Interaction logic for ParticipanteView.xaml
    /// </summary>
    public partial class ParticipanteView : Window
    {
        public ParticipanteView()
        {
            InitializeComponent();
            var viewModel = new ParticipanteViewModel();
            this.DataContext = viewModel;
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Resetar_Click(object sender, RoutedEventArgs e)
        {
            NomeTextBox.Text = string.Empty;
            CpfTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            EnderecoTextBox.Text = string.Empty;
            TelefoneTextBox.Text = string.Empty;
            CidadeTextBox.Text = string.Empty;
            EstadoTextBox.Text = string.Empty;
            DescricaoTextBox.Text = string.Empty;
            IsConfirmadoCheckBox.IsChecked = false;
        }

    }
}
