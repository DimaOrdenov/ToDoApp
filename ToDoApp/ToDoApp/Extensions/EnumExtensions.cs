using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ToDoApp.Extensions
{
    public static class EnumExtensions
    {
        public static string GetEnumString(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
