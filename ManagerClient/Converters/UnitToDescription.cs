using System;
using System.Globalization;
using System.Windows.Data;
using Shared.Extenders;

namespace ManagerClient.Converters
{
  /// <summary>
  /// Конвертер перечислений в описание (атрибут Description)
  /// </summary>
  public class EnumToDescription : ConverterBase<EnumToDescription>
  {
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var unit = (Enum)value;

      return unit.GetDescription();
    }
  }
}