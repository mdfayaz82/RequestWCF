using System.Threading;
using System.Windows;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        private Timer _timer;
        private IRequestServiceClient _client;

        public MainWindow()
        {
            InitializeComponent();
            _client = new IRequestServiceClient();
            _timer = new Timer(CheckForRequests, null, 0, 10000);
        }

        private void CheckForRequests(object state)
        {
            Dispatcher.Invoke(() =>
            {
                var result = _client.CheckForRequests();
                MessageBox.Show(result);
            });
        }
    }
}
