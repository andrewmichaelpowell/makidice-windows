// Maki Dice (Windows)
// github.com/andrewmichaelpowell

using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

namespace MakiDice;

public partial class App : Application
{
    public static event Action? ThemeChanged;

    protected override void OnStartup(StartupEventArgs e)
    {
        ApplyTheme(IsWindowsInLightTheme());
        SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
        base.OnExit(e);
    }

    private void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
        if (e.Category != UserPreferenceCategory.General)
        {
            return;
        }

        Dispatcher.Invoke(() => ApplyTheme(IsWindowsInLightTheme()));
    }

    private void ApplyTheme(bool isLight)
    {
        Resources["WindowBackgroundBrush"] = new SolidColorBrush(
            isLight ? Colors.White : Colors.Black);

        Resources["SecondaryBackgroundBrush"] = new SolidColorBrush(
            isLight ? Color.FromRgb(0xEF, 0xEF, 0xF4) : Color.FromRgb(0x1C, 0x1C, 0x1E));

        Resources["LabelBrush"] = new SolidColorBrush(
            isLight ? Colors.Black : Colors.White);

        ThemeChanged?.Invoke();
    }

    private static bool IsWindowsInLightTheme()
    {
        try
        {
            using var key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
            return key?.GetValue("AppsUseLightTheme") is int value ? value != 0 : true;
        }
        catch
        {
            return true;
        }
    }
}
