using System;
using System.Globalization;
using System.Windows.Data;
using Shared.Core.Enum;
using Shared.Core.Validation;

namespace ManagerClient.Converters
{
  public class ErrorTypeToIcon : ConverterBase<ErrorTypeToIcon>
  {
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var type = (ErrorType)value;

      if (type == ErrorType.Info)
        return @"/ManagerClient;component/Images/info_16.png";

      if (type == ErrorType.Warning)
        return @"/ManagerClient;component/Images/warn_16.png";

      if (type == ErrorType.Error)
        return @"/ManagerClient;component/Images/error_16.png";

      return Binding.DoNothing;
    }
  }
}