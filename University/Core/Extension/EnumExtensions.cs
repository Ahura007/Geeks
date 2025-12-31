using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace University.Core.Extension;

public static class EnumExtensions
{
    public static List<EnumModel<TId>> ToEnumModelList<TEnum, TId>(this System.Enum enumType)
        where TEnum : System.Enum
        where TId : struct
    {
        return System.Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Select(v => new EnumModel<TId>
            {
                Id = (TId)Convert.ChangeType(v, typeof(TId)),
                Title = v.GetDisplayName()
            })
            .ToList();
    }


    public static string? GetDisplayName(this System.Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attribute = fieldInfo!.GetCustomAttribute<DisplayAttribute>();
        return attribute != null ? attribute.Name : value.ToString();
    }


    public static List<EnumModel<int>> GetEnumData(this Type? enumType)
    {
        if (enumType == null || !enumType.IsEnum)
            return new List<EnumModel<int>>();

        var list = new List<EnumModel<int>>();

        foreach (var value in System.Enum.GetValues(enumType))
        {
            var id = Convert.ToInt32(value);
            var displayName = ((System.Enum)value).GetDisplayName();

            list.Add(new EnumModel<int> { Id = id, Title = displayName });
        }

        return list;
    }
}