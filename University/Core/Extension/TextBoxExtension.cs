namespace University.Core.Extension;

public static class TextBoxExtension
{
    public static int IntValue(this TextBox textBox)
    {
        if (string.IsNullOrEmpty(textBox.Text))
        {
            return 0;
        }

        if (int.TryParse(textBox.Text, out int value))
        {
            return value;
        }

        throw new FormatException("عدد نامعتبر است !!");
    }

    public static short ShortValue(this TextBox textBox)
    {
        if (string.IsNullOrEmpty(textBox.Text))
        {
            return 0;
        }

        if (short.TryParse(textBox.Text, out short value))
        {
            return value;
        }

        throw new FormatException("عدد نامعتبر است !!");
    }
}