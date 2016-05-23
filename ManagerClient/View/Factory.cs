using System.Windows;
using ClientBase.ViewModel.Base;
using ManagerClient.View.Entities;

namespace ManagerClient.View
{
  public static class Factory
  {
    /// <summary>
    /// Создать окно сущности.
    /// </summary>
    /// <param name="owner">Владелец.</param>
    /// <param name="control">Тип сущности.</param>
    /// <returns>Окно сущности.</returns>
    public static EntityBaseView CreateEntityWindow(DependencyObject owner, ViewModelBase control)
    {
      return new EntityBaseView(Window.GetWindow(owner), control);
    }
  }
}