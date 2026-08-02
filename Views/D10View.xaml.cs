// Maki Dice (Windows)
// github.com/andrewmichaelpowell

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MakiDice.Views;

public partial class D10View : UserControl
{
    public event EventHandler? BackRequested;

    private int _diceValue;
    private int _difficultyValue;
    private int _successesValue;
    private int _selected = 1;

    public D10View()
    {
        InitializeComponent();
        UpdateSelectionStyles();

        App.ThemeChanged += UpdateSelectionStyles;
    }

    private void UpdateSelectionStyles()
    {
        var tealBrush = (Brush)Application.Current.Resources["TealBrush"];
        var secondaryBrush = (Brush)Application.Current.Resources["SecondaryBackgroundBrush"];
        var labelBrush = (Brush)Application.Current.Resources["LabelBrush"];

        DiceLabel.Foreground = _selected == 1 ? tealBrush : labelBrush;
        DifficultyLabel.Foreground = _selected == 2 ? tealBrush : labelBrush;

        SelectDiceButton.Background = _selected == 1 ? tealBrush : secondaryBrush;
        SelectDiceButton.Foreground = _selected == 1 ? Brushes.White : labelBrush;

        SelectDifficultyButton.Background = _selected == 2 ? tealBrush : secondaryBrush;
        SelectDifficultyButton.Foreground = _selected == 2 ? Brushes.White : labelBrush;
    }

    private void SelectDice_Click(object sender, RoutedEventArgs e)
    {
        _selected = 1;
        UpdateSelectionStyles();
    }

    private void SelectDifficulty_Click(object sender, RoutedEventArgs e)
    {
        _selected = 2;
        UpdateSelectionStyles();
    }

    private void Pool_Click(object sender, RoutedEventArgs e)
    {
        int value = int.Parse((string)((Button)sender).Tag);
        if (_selected == 1)
        {
            _diceValue = value;
            DiceValueText.Text = _diceValue.ToString();
        }
        else if (_selected == 2)
        {
            _difficultyValue = value;
            DifficultyValueText.Text = _difficultyValue.ToString();
        }
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        _diceValue = 0;
        _difficultyValue = 0;
        _successesValue = 0;
        DiceValueText.Text = "";
        DifficultyValueText.Text = "";
        SuccessesValueText.Text = "";
    }

    private async void Roll_Click(object sender, RoutedEventArgs e)
    {
        if (_diceValue == 0 || _difficultyValue == 0)
        {
            return;
        }

        int successes = 0;
        for (int i = 0; i < _diceValue; i++)
        {
            int r = Random.Shared.Next(1, 11); // 1-10 inclusive
            if (r == 1) successes -= 1;
            else if (r == 10) successes += 2;
            else if (r >= _difficultyValue) successes += 1;
        }
        _successesValue = successes;

        SuccessesValueText.Text = "";
        await Task.Delay(100);
        SuccessesValueText.Text = _successesValue.ToString();
    }

    private void Back_Click(object sender, RoutedEventArgs e)
    {
        BackRequested?.Invoke(this, EventArgs.Empty);
    }
}
