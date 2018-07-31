using System;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace AsyncDemo
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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(7000);
            ResultLabel.Content = "This is button 1";
        }

        private async void Button2_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(7000);
            ResultLabel.Content = "This is button 2";
        }

        private async void Button3_Click(object sender, RoutedEventArgs e)
        {
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/control-flow-in-async-programs
            ResultLabel.Content = "about to await AccessTheWebAsync()";
            int contentLength = await AccessTheWebAsync();
            DoSomeWork();
            ResultLabel.Content = "Button 3 clicked. string length:" + contentLength;

        }

        private async void Button4_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "Call AccessTheWebAsync() synchronously";
            Task<int> getLengthTask = AccessTheWebAsync();
            DoSomeWork();
            int contentLength = await AccessTheWebAsync();
            ResultLabel.Content = "Button 4 Clicked. string length:" + contentLength;
        }

        private void DoSomeWork()
        {
            ResultLabel.Content = "in DoSomeWork()";
            //Thread.Sleep(5000);
        }

        private async Task<int> AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();
            Task<string> getStringTask = client.GetStringAsync("http://www.fakeresponse.com/api/?sleep=7");
            string urlContents = await getStringTask;
            return urlContents.Length;
        }
    }
}
