using System;
using Shared.Core.Entities.Base;

namespace Shared.Core.Entities
{
  /// <summary>
  /// Полуфабрикат.
  /// </summary>
  public class Prepack : PrepackBase
  {
    public override string TypeGuid => "EB8EDEDB-3851-42E0-B39C-A5643960F0DC";
    public override string TypeName => "Полуфабрикат";
  }
}