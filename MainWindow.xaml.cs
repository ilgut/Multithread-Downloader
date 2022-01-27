using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Downoader
{

    public partial class MainWindow : Window
    {
        List<DownloadInfo> test = new List<DownloadInfo>() { };
        public MainWindow()
        {
            InitializeComponent();
            linkbox.GotMouseCapture += (s,e) => { linkbox.Text = "";
                                                  linkbox.FontStyle = default(FontStyle); 
                                                  linkbox.Foreground = Brushes.Black; 
                                                 };

            downloadList.ItemsSource = test;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            test.Add(new DownloadInfo(test.Count + 1, linkbox.Text));

            downloadList.Items.Refresh();

        }

    }
}
