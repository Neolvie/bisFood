using System.ComponentModel;

namespace Shared.Core.Enum
{
  /// <summary>
  /// Единицы измерения.
  /// </summary>
  public enum Units
  {
    [Description("кг.")]
    Kg,

    [Description("шт.")]
    Pieces,

    [Description("л.")]
    Liters
  }
}