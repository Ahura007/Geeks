namespace University.Ui.Extension;

public static class ComboBoxExtension
{
    public static void BindData<T>(this ComboBox comboBox, List<T> data, string displayMember, string valueMember)
    {
        comboBox.DisplayMember = displayMember;
        comboBox.ValueMember = valueMember;
        comboBox.DataSource = data;
    }


    public static T GetSelectedValue<T>(this ComboBox comboBox)
    {
        if (comboBox is null)
            return default;

        if (comboBox.SelectedValue is null)
            return default;


        var value = comboBox.SelectedValue;

        if (typeof(T) == typeof(Guid))
        {
            if (value is Guid guid)
                return (T)(object)guid;

            if (Guid.TryParse(value.ToString(), out var parsedGuid))
                return (T)(object)parsedGuid;

            return default;
        }

        if (typeof(T).IsEnum) return (T)Enum.Parse(typeof(T), value.ToString());

        return (T)Convert.ChangeType(value, typeof(T));
    }
}