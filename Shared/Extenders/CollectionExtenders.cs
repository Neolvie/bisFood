using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Shared.Extenders
{
  /// <summary>
  /// Класс расширения методов коллекций.
  /// </summary>
  public static class CollectionExtenders
  {
    /// <summary>
    /// Добавляет список объектов в ObservableCollection.
    /// </summary>
    /// <typeparam name="T">Тип объекта.</typeparam>
    /// <param name="collection">Коллекция.</param>
    /// <param name="objects">Список объектов.</param>
    public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> objects)
    {
      foreach (var o in objects)
        collection.Add(o);
    } 
  }
}