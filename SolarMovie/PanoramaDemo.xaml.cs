using System.Windows;

namespace SolarMovie
{
    public partial class PanoramaDemo
    {
        public PanoramaDemo()
        {
            InitializeComponent();
            Loaded += MainWindowLoaded;
        }

        void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = new MainWindowViewModel();
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape) this.Close();
        }
    }
}
