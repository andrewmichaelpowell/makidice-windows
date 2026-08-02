// Maki Dice (Windows)
// github.com/andrewmichaelpowell

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MakiDice.Views;

public partial class MainView : UserControl
{
    public event EventHandler? OpenD10Requested;

    private string _diceNumber = "";
    private string _diceType = "";
    private int _editSide = 1;
    private int _resetInput = 1;
    private int _resultValue;

    public MainView()
    {
        InitializeComponent();
    }

    private async void RevealAfterDelay(string value)
    {
        ResultText.Text = "";
        await Task.Delay(100);
        ResultText.Text = value;
    }

    private void QuickRoll_Click(object sender, RoutedEventArgs e)
    {
        int sides = int.Parse((string)((Button)sender).Tag);
        _resultValue = Random.Shared.Next(1, sides + 1);
        _editSide = 1;
        _resetInput = 1;
        _diceNumber = "1";
        _diceType = sides.ToString();
        RevealAfterDelay(_resultValue.ToString());
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        _editSide = 1;
        _diceNumber = "";
        _diceType = "";
        ResultText.Text = "";
    }

    private void SetRight(int digit)
    {
        if (_diceType.Length < 3)
        {
            _diceType += digit;
            ResultText.Text = $"{_diceNumber}d{_diceType}";
        }
    }

    private void SetLeft(int digit)
    {
        if (_resetInput == 1)
        {
            _diceNumber = "";
            _diceType = "";
            _resetInput = 0;
        }
        if (_diceNumber.Length < 3)
        {
            _diceNumber += digit;
            ResultText.Text = _diceNumber;
        }
    }

    private void AppendDigit(int digit)
    {
        if (_editSide == 1) SetLeft(digit);
        if (_editSide == 2) SetRight(digit);
    }

    private void Digit_Click(object sender, RoutedEventArgs e)
    {
        int digit = int.Parse((string)((Button)sender).Tag);
        AppendDigit(digit);
    }

    private void Zero_Click(object sender, RoutedEventArgs e)
    {
        if (_editSide == 1 && _diceNumber != "" && _resetInput == 0) AppendDigit(0);
        if (_editSide == 2 && _diceType != "" && _resetInput == 0) AppendDigit(0);
    }

    private void PressD_Click(object sender, RoutedEventArgs e)
    {
        if (_editSide == 1 && _resetInput == 0)
        {
            _editSide = 2;
            ResultText.Text = $"{_diceNumber}d";
        }
    }

    private void Roll_Click(object sender, RoutedEventArgs e)
    {
        if (_diceNumber != "" && _diceType != "")
        {
            int n = int.Parse(_diceNumber);
            int sides = int.Parse(_diceType);
            int total = 0;
            for (int i = 0; i < n; i++)
            {
                total += Random.Shared.Next(1, sides + 1);
            }
            _resultValue = total;
            RevealAfterDelay(_resultValue.ToString());
            _editSide = 1;
            _resetInput = 1;
        }
    }

    private void OpenD10_Click(object sender, RoutedEventArgs e)
    {
        OpenD10Requested?.Invoke(this, EventArgs.Empty);
    }
}
