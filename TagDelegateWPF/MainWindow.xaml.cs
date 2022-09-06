using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TagDelegateWPF
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


private void Window_Loaded(object sender, RoutedEventArgs e)
{
    Random r = new Random();

    foreach (Button button in stackPanelButtons.Children.OfType<Button>())
    {
        int ran = r.Next(3);
        if (ran == 0)
        {
            button.Tag = new SupriseMessage
                (new DelegateShowMyMessage(ShowMessage), "Method: ShowMessage");
        }
        else if (ran == 1)
            button.Tag = new SupriseMessage
                (new DelegateShowMyMessage(ShowMessage2), "Method: ShowMessage2");
        else
            button.Tag = new SupriseMessage
                (new DelegateShowMyMessage(ShowMessage3), "Method: ShowMessage3");
    }
}

public void ShowMessage(string value){MessageBox.Show("Moja ulubiona technologia .NET: " + value);}

public void ShowMessage2(string value){ MessageBox.Show("Ciekawa technologia .NET: " + value);}

public void ShowMessage3(string value){ MessageBox.Show("Wiedz, że lubie tą technologię: " + value);}

private void Button_Click(object sender, RoutedEventArgs e)
{
    var button = (Button)e.Source;
    var suprise = ((SupriseMessage)button.Tag);
    suprise.Delegate.Invoke(button.Content.ToString() + "\n\n" + suprise.MetaData);
}
    }

    
    public delegate void DelegateShowMyMessage(string value);

public class SupriseMessage
{
    public DelegateShowMyMessage Delegate { get; private set; }
    public string MetaData {get; private set;}

    public SupriseMessage(DelegateShowMyMessage de,string metadata)
    {
        Delegate = de;
        MetaData = metadata;
    }
}
}
