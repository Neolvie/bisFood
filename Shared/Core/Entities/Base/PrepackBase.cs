using System.Collections.Generic;
using Shared.Core.Interfaces;

namespace Shared.Core.Entities.Base
{
  /// <summary>
  /// Базовый класс полуфабриката.
  /// </summary>
  public abstract class PrepackBase : ProductBase
  {
    /// <summary>
    /// Список ингредиентов.
    /// </summary>
    public virtual IList<Ingredient> Ingredients { get; set; }

    protected PrepackBase()
    {
      Ingredients = new List<Ingredient>();
    }
  }
}