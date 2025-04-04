using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace _05_FileCopy_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            srcTextBox.Text = Source = @"C:\Users\konopelko\Downloads\1GB.bin";
            destTextBox.Text = Destination = @"C:\Users\konopelko\Desktop\TestCopy";
        }

        private void OpenFileBtn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                srcTextBox.Text = Source = dialog.FileName;
            }
        }

        private void OpenFolderBtn(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                destTextBox.Text = Destination = dialog.FileName;
            }
        }

        private async void CopyFileBtn(object sender, RoutedEventArgs e)
        {
            string fileName = System.IO.Path.Combine(Destination, System.IO.Path.GetFileName(Source));
            //File.Copy(Source, fileName);

            await CopyFileAsync(Source, fileName);      
            MessageBox.Show("Complate");
        }
        private Task CopyFileAsync(string source, string dest)
        {
            return Task.Run(() =>
            {
                using (FileStream srcFile = new FileStream(source, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream destFile = new FileStream(dest, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[1024 * 8]; // 8Kb
                        int bytes = 0;
                        do
                        {
                            bytes = srcFile.Read(buffer, 0, buffer.Length);
                            destFile.Write(buffer, 0, bytes);
                            float percentage = destFile.Length / (srcFile.Length / 100);
                            Dispatcher.Invoke(() => {
                                progress.Value = percentage;
                                percentage_.Text = $"{percentage}%";
                            });
                            
                        } while (bytes > 0);
                    }
                }
            });
        }

     

        private void srcTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            percentage_.Text = srcTextBox.Text;
        }
    }
}
