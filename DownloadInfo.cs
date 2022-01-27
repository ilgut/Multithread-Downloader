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
    internal class DownloadInfo
    {
        public int number { get; } = default(int);
        public string url { get; } = "url";
        public string size { get; private set; }
        public ProgressBar progressBar { get; private set; } = new ProgressBar();


        public DownloadInfo(int number, string url)
        {

            this.number = number;
            this.url = url;

            size = StartDownload();
        }

        private string StartDownload()
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    string temp = "";
                    webClient.OpenRead(url);
                    temp = (Double.Parse(webClient.ResponseHeaders["Content-Length"]) / 1048576).ToString("#.## MB");
                    string[] urlSplit = url.Split('/');
                    webClient.DownloadFileAsync(new Uri(url), $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{urlSplit[urlSplit.Length - 1]}");
                    webClient.DownloadProgressChanged += (s, e) =>
                    {
                        progressBar.Value = e.ProgressPercentage;
                        temp = e.TotalBytesToReceive.ToString();
                    };
                    return temp;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
                
            }
        }

    }
}

