using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace ManagerClient.Converters
{
  /// <summary>
  /// Базовый конвертер в виде расширения разметки (чтобы не объявлять каждый раз StaticResource)
  /// </summary>
  /// <typeparam name="T">Тип конвертера</typeparam>
  public abstract class ConverterBase<T> : MarkupExtension, IValueConverter where T : class, new()
  {
    public abstract object Convert(object value, Type targetType, object parameter,
      CultureInfo culture);

    public virtual object ConvertBack(object value, Type targetType, object parameter,
      CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      return _converter ?? (_converter = new T());
    }

    private static T _converter = null;
  }
}