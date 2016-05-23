using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace ManagerClient.View
{
  /// <summary>
  /// Базовый класс UserControl.
  /// </summary>
  public abstract class UserControlBase : UserControl, INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}