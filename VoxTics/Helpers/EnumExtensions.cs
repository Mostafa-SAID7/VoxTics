using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace VoxTics.Helpers
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the Display Name attribute value or enum name if not set.
        /// </summary>
        public static string GetDisplayName(this Enum enumValue)
        {
            var member = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
            if (member == null) return enumValue.ToString();

            var displayAttr = member.GetCustomAttribute<DisplayAttribute>();
            return displayAttr?.Name ?? enumValue.ToString();
        }

        /// <summary>
        /// Gets the Description attribute value or enum name if not set.
        /// </summary>
        public static string GetDescription(this Enum enumValue)
        {
            var member = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
            if (member == null) return enumValue.ToString();

            var displayAttr = member.GetCustomAttribute<DisplayAttribute>();
            return displayAttr?.Description ?? enumValue.ToString();
        }

        /// <summary>
        /// Gets any custom attribute of type T from enum member.
        /// </summary>
        public static T? GetAttribute<T>(this Enum enumValue) where T : Attribute
        {
            var member = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
            return member?.GetCustomAttribute<T>();
        }

        /// <summary>
        /// Returns all enum values of type T.
        /// </summary>
        public static IEnumerable<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        /// <summary>
        /// Returns a dictionary of enum int value to display name.
        /// </summary>
        public static Dictionary<int, string> GetEnumDictionary<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .ToDictionary(e => Convert.ToInt32(e), e => e.GetDisplayName());
        }

        /// <summary>
        /// Returns a dictionary of enum int value to description.
        /// </summary>
        public static Dictionary<int, string> GetEnumDescriptionDictionary<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .ToDictionary(e => Convert.ToInt32(e), e => e.GetDescription());
        }
    }
}
