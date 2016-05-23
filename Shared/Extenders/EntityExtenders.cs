using System;
using Shared.Core.Interfaces;

namespace Shared.Extenders
{
  /// <summary>
  /// Класс расширений методов сущности.
  /// </summary>
  public static class EntityExtenders
  {
    public static T Copy<T>(this T entity) where T : IEntity
    {
      // TODO. Заглушка, разобраться с копированием.
      return entity;
    }
  }
}