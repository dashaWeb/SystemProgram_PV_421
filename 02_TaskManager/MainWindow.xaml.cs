using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _02_TaskManager;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    DispatcherTimer _timer = null;
    public MainWindow()
    {
        InitializeComponent();
        _timer = new DispatcherTimer();
        _timer.Interval = new TimeSpan(0, 0, 20);
        _timer.Tick += _timer_Tick;
        _timer.Start();
    }

    private void _timer_Tick(object? sender, EventArgs e)
    {
        Refresh(sender, null);
    }

    private void Refresh(object sender, RoutedEventArgs e)
    {
        grid.ItemsSource = Process.GetProcesses();
    }

    private void RadioButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show((sender as RadioButton).Content.ToString());
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show((grid.SelectedItem as Process).ProcessName);
        (grid.SelectedItem as Process).Kill();
    }
}