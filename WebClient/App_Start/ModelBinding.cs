using System.Web.Mvc;
using ClientBase.ViewModel;
using ClientBase.ViewModel.Base;
using WebClient.Helpers;

namespace WebClient
{
  public static class ModelBinding
  {
    public static void ViewModelBinding()
    {
      ModelBinders.Binders.DefaultBinder = new EntityModelBinder();
    }
  }
}