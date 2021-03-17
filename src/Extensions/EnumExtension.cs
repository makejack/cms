using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace www.veinid365.cn.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this System.Enum value)
        {
            return value.GetType()
            .GetMember(value.ToString())
            .FirstOrDefault()?
            .GetCustomAttribute<DescriptionAttribute>()?
            .Description;
        }
    }
}