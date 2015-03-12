using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace FogBugzApiWrapper.Utilities
{
    public static class EnumUtils
    {
        public static string GetUriName<T>(T enumValue) 
        {
            var type = typeof(T);
            var memberInfo = type.GetMember(enumValue.ToString());
            return GetDescriptionAttributeValue(memberInfo);
        }

        public static string GetDescriptionAttributeValue(MemberInfo memberInfo)
        {
            var attributes = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length == 0)
            {
                return null;
            }

            return ((DescriptionAttribute)attributes[0]).Description;
        }

        public static string GetDescriptionAttributeValue(MemberInfo[] memberInfo)
        {
            if (memberInfo.Length == 0)
            {
                return null;
            }
            return GetDescriptionAttributeValue(memberInfo[0]);
        }

        public static string GetDisplayName<T>(T enumValue)
        {
            var type = typeof(T);
            var memberInfo = type.GetMember(enumValue.ToString());
            return GetDescriptionAttributeValue(memberInfo);
        }

        public static string GetDisplayNameAttributeValue(MemberInfo memberInfo)
        {
            var attributes = memberInfo.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes.Length == 0)
            {
                return null;
            }

            return ((DisplayAttribute)attributes[0]).Name;
        }

        public static string GetDisplayNameAttributeValue(MemberInfo[] memberInfo)
        {
            if (memberInfo.Length == 0)
            {
                return null;
            }
            return GetDescriptionAttributeValue(memberInfo[0]);
        }

        public static string GetUriValues<T>(T enumValue) 
        {
            var flags = GetIndividualFlags<T>(enumValue as Enum);
            var flagStrings = new List<string>();

            foreach (var flag in flags)
            {
                var flagString = GetUriName(flag);
                if (!string.IsNullOrWhiteSpace(flagString))
                {
                    flagStrings.Add(GetUriName(flag));
                }
            }

            return string.Join(",", flagStrings);
        }

        public static IEnumerable<T> GetIndividualFlags<T>(Enum input)
        {
            var allValues = Enum.GetValues(input.GetType());
            var castedValues = allValues.Cast<Enum>();
            var inUseValues = castedValues.Where(input.HasFlag);
            return inUseValues.Cast<T>();
        }
    }
}
