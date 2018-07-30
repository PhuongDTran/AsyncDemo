using System;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;

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

        private void Button1_Click(Object sender, EventArgs e)
        {
            Thread.Sleep(10000);
            MessageBox.Show("hello");
        }

        private async void Button2_Clicked( Object sender, EventArgs e)
        {
            await Task.Delay(10000);
            MessageBox.Show("hello async");
        }

    }
}
