using Organiser.UI.ViewModel;
using System.Windows;

namespace Organiser.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;

            DataContext = _mainViewModel;
            Loaded += MainWindow_Loaded;

            
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _mainViewModel.LoadAsync();
        }
    }
}
