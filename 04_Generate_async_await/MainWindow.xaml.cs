using System;
using System.Collections.Generic;
using System.IO;
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

namespace _04_Generate_async_await
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
       

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ViewNumber(object sender, RoutedEventArgs e)
        {

            //Task<int> task = Task.Run(GenerateValue);
            ///await task;
            //int value = task.Result; // Wait
            //list.Items.Add(await task);     
            //list.Items.Add(await Task.Run(GenerateValue));
            list.Items.Add(await GenerateValueAsync());
            //FileStream file = new FileStream();
            //file.CopyToAsync();
        }

        int GenerateValue()
        {
            Thread.Sleep(rnd.Next(5000));
            return rnd.Next(1000);
        }
        Task<int> GenerateValueAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(rnd.Next(5000));
                return rnd.Next(1000);
            });
        }

    }
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
