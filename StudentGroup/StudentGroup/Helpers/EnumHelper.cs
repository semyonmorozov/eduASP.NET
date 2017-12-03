using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentGroup.Helpers
{
    public static class EnumHelper
    {
        public static string GetDisplayName(this Enum val)
        {
            return val.GetType()
                       .GetMember(val.ToString())
                       .FirstOrDefault()
                       ?.GetCustomAttribute<DisplayAttribute>(false)
                       ?.Name
                   ?? val.ToString();
        }

        public static List<SelectListItem> GetSelectList<TEnum>() where TEnum : IConvertible
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<Enum>()
                .Select(i => new SelectListItem
                {
                    Text = i.GetDisplayName(),
                    Value = i.ToString()
                })
                .ToList();
        }
    }
}