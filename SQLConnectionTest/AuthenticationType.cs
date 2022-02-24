using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
namespace SQLConnectionTest
{
    public enum AuthenticationType
    {
        [Display(Name = "Active Directory Password")]
        ActiveDirectoryPassword,
        [Display(Name = "SQL Credentials")]
        SQLCredentials
    }

    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            if (enumValue == null)
                throw new ArgumentNullException(nameof(enumValue));
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}
