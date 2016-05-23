using Shared.Core.Entities.Base;

namespace ClientBase.ViewModel.Base
{
  /// <summary>
  /// Базовая ViewModel блюда.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class DishBaseViewModel<T> : PrepackBaseViewModel<T> where T : DishBase
  {
    protected DishBaseViewModel(T entity) : base(entity)
    {
    }

    protected DishBaseViewModel()
    {
      
    }
  }
}