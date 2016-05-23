using ClientBase.ViewModel.Base;
using Shared.Core.Entities;
using Shared.Core.Entities.Base;

namespace ClientBase.ViewModel
{
  public class PrepackViewModel : PrepackBaseViewModel<PrepackBase>
  {
    public PrepackViewModel(PrepackBase entity) : base(entity)
    {
    }

    public PrepackViewModel()
    {
      Entity = new Prepack();
    }
  }
}