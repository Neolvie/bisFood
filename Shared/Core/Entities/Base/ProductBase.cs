using System.ComponentModel.DataAnnotations;
using Shared.Core.Enum;
using Shared.Core.Interfaces;

namespace Shared.Core.Entities.Base
{
  /// <summary>
  /// Базовый класс продукта.
  /// </summary>
  public abstract class ProductBase : Entity
  {
    /// <summary>
    /// Стоимость продукта.
    /// </summary>
    [Display(Name = "Цена")]
    public virtual double Price { get; set; }

    /// <summary>
    /// Единицы измерения.
    /// </summary>
    [Display(Name = "Единицы измерения")]
    public virtual Units Unit { get; set; }

    /// <summary>
    /// Признак, что продукт может быть продан.
    /// </summary>
    [Display(Name = "Может быть продан")]
    public virtual bool CanBeSold { get; set; }
  }
}