using System;
using Shared.Core.Entities.Base;

namespace Shared.Core.Entities
{
  /// <summary>
  /// Продукт.
  /// </summary>
  public class Product : ProductBase
  {
    public override string TypeGuid => "38DEFC8D-F682-485E-BF3B-06C799B613BA";
    public override string TypeName => "Продукт";
  }
}