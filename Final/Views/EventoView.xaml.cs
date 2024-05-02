using Final.Models;
using Final.ViewModels;
using System.Windows;

namespace Final.Views
{
    public partial class EventoView : Window
    {
        public EventoView()
        {
            InitializeComponent();
            var viewModel = new EventoViewModel();
            this.DataContext = viewModel;

            viewModel.RequestClose += () =>
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            };

            viewModel.ShowMessage += (message) =>
            {
                MessageBox.Show(message);
            };
        }

        private void Resetar_Click(object sender, RoutedEventArgs e)
        {
            NomeTextBox.Text = string.Empty;
            DescricaoTextBox.Text = string.Empty;
            DataDatePicker.SelectedDate = null;
            LocalTextBox.Text = string.Empty;
            CidadeTextBox.Text = string.Empty;
            EstadoTextBox.Text = string.Empty;
            ConvidadosTextBox.Text = string.Empty;
            CapacidadeTextBox.Text = string.Empty;

        }
    }
}