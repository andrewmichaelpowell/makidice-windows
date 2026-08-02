// Maki Dice (Windows)
// github.com/andrewmichaelpowell

using System.Windows;
using MakiDice.Views;

namespace MakiDice;

public partial class MainWindow : Window
{
    private readonly MainView _mainView;
    private readonly D10View _d10View;

    public MainWindow()
    {
        InitializeComponent();

        _mainView = new MainView();
        _mainView.OpenD10Requested += (_, _) => RootContent.Content = _d10View;

        _d10View = new D10View();
        _d10View.BackRequested += (_, _) => RootContent.Content = _mainView;

        RootContent.Content = _mainView;
    }
}
