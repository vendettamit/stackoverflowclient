using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StackQuestionsClient.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        private void link_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            var startArgs = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            var startInfo = new ProcessStartInfo(startArgs, e.Uri.AbsoluteUri);
            Process.Start(startInfo);
            e.Handled = true;
        }
    }
}
