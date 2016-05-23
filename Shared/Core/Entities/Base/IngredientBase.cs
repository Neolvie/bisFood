using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Core.Entities.Base
{
  /// <summary>
  /// Базовый класс ингредиента.
  /// </summary>
  public abstract class IngredientBase : Entity
  {
    /// <summary>
    /// Имя ингредиента это имя продукта, на который он ссылается.
    /// </summary>
    public override string Name => Product != null ? Product.Name : string.Empty;

    /// <summary>
    /// Продукт.
    /// </summary>
    [Required(ErrorMessage = "Необходимо указать продукт")]
    public virtual ProductBase Product { get; set; }

    /// <summary>
    /// Количество продукта.
    /// </summary>
    [Range(0.00001, double.MaxValue, ErrorMessage = "Необходимо указать количество продукта")]
    public virtual double Value { get; set; }
  }
}