using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Fluent;
using Shared.Extenders;

namespace ManagerClient.View
{
  /// <summary>
  /// Базовый класс окна.
  /// </summary>
  public abstract class WindowBase : RibbonWindow, INotifyPropertyChanged
  {
    public virtual string PageTitle { get; }

    public ICommand SaveCommand { get; protected set; }
    public ICommand SaveAndCloseCommand { get; protected set; }
    public ICommand DeleteCommand { get; protected set; }

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
  }
}