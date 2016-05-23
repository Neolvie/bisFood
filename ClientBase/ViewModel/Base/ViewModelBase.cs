using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ClientBase.Commands;
using Shared.Core.Validation;

namespace ClientBase.ViewModel.Base
{
  /// <summary>
  /// Базовая ViewModel.
  /// </summary>
  public abstract class ViewModelBase : INotifyPropertyChanged
  {
    public bool ValidationOnSaving;
    public bool HasError => ValidationErrors.Any();
    public ObservableCollection<PropertyValidationError> ValidationErrors { get; }
    public abstract string PageTitle { get; }

    public abstract SimpleCommand SaveCommand { get; }

    public abstract SimpleCommand DeleteCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected ViewModelBase()
    {
      ValidationErrors = new ObservableCollection<PropertyValidationError>();
    }
  }
}