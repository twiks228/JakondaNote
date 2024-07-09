using System;
using System.Windows.Forms;

public static class SettingsKeyboard
{
    public static void Initialize(TextBox lineNumberTextBox)
    {
        lineNumberTextBox.KeyDown += LineNumberTextBox_KeyDown;
    }
    private static string _previousText = null;
    private static void LineNumberTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        TextBox lineNumberTextBox = (TextBox)sender;

        // Обработка комбинации Ctrl+C
        if (e.Control && e.KeyCode == Keys.C)
        {
            Clipboard.SetText(lineNumberTextBox.SelectedText);
            e.Handled = true;
        }


    }

}