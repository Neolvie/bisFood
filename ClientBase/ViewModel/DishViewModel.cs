using ClientBase.ViewModel.Base;
using Shared.Core.Entities;
using Shared.Core.Entities.Base;

namespace ClientBase.ViewModel
{
  public class DishViewModel : DishBaseViewModel<DishBase>
  {
    public DishViewModel(DishBase entity) : base(entity)
    {
    }

    public DishViewModel()
    {
      Entity = new Dish();
    }
  }
}