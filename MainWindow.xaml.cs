// Maki Dice (Windows)
// github.com/andrewmichaelpowell

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using MakiDice.Views;
using Microsoft.Win32;

namespace MakiDice;

public partial class MainWindow : Window
{
    private const string SettingsKey = @"Software\Maki Dice";
    private const string SelectedTabValue = "SelectedTab";

    public MainWindow()
    {
        InitializeComponent();

        MainContent.Content = new MainView();
        D10Content.Content = new D10View();

        ShowPage(LoadSelectedTab());
    }

    private void MainPage_Click(object sender, RoutedEventArgs e) => SelectPage(0);

    private void D10Page_Click(object sender, RoutedEventArgs e) => SelectPage(1);

    private void SelectPage(int index)
    {
        ShowPage(index);
        SaveSelectedTab(index);
    }

    private void ShowPage(int index)
    {
        MainContent.Visibility = index == 0 ? Visibility.Visible : Visibility.Collapsed;
        D10Content.Visibility = index == 1 ? Visibility.Visible : Visibility.Collapsed;
        Grid.SetColumn(PageIndicator, index);

        if (index == 0)
        {
            DiceIcon.Fill = Brushes.White;
            D10Label.SetResourceReference(TextBlock.ForegroundProperty, "LabelBrush");
        }
        else
        {
            DiceIcon.SetResourceReference(Shape.FillProperty, "LabelBrush");
            D10Label.Foreground = Brushes.White;
        }
    }

    private static int LoadSelectedTab()
    {
        try
        {
            using var key = Registry.CurrentUser.OpenSubKey(SettingsKey);
            return key?.GetValue(SelectedTabValue) is int value && value == 1 ? 1 : 0;
        }
        catch
        {
            return 0;
        }
    }

    private static void SaveSelectedTab(int index)
    {
        try
        {
            using var key = Registry.CurrentUser.CreateSubKey(SettingsKey);
            key.SetValue(SelectedTabValue, index, RegistryValueKind.DWord);
        }
        catch
        {
        }
    }
}
