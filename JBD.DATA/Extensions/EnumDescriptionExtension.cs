using System.ComponentModel;
using System.Reflection;

namespace JBD.DATA.Extensions;

public static class EnumDescriptionExtension
{
    public static string GetDescription(this Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        var attribute = (DescriptionAttribute)fi.GetCustomAttribute(typeof(DescriptionAttribute))!;
        return attribute.Description;
    }
}