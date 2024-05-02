

using Final.ViewModels;
using System.Windows;

namespace Final.Views
{
    /// <summary>
    /// Interaction logic for InscricaoView.xaml
    /// </summary>
    public partial class InscricaoView : Window
    {
        public InscricaoView()
        {
            InitializeComponent();
            this.DataContext = new InscricaoViewModel();
            /* var viewModel = new InscricaoViewModel();
             this.DataContext = viewModel;*/
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
