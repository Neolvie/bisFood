using System;
using System.Linq;
using System.Web.Mvc;
using Shared.Core.Enum;
using Shared.Extenders;

namespace WebClient.Helpers.Extenders
{
  public static class EnumExtenders
  {
    public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
            where TEnum : struct, IComparable, IFormattable, IConvertible
    {
      var values = from Enum e in Enum.GetValues(typeof(TEnum))
                   select new { Id = e, Name = e.GetDescription() };
      return new SelectList(values, "Id", "Name", enumObj);
    }

    public static SelectList GetUnitsSelectList()
    {
      return Units.Kg.ToSelectList();
    }
  }
}