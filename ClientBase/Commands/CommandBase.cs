using System;
using System.Windows.Input;

namespace ClientBase.Commands
{
  public class CommandBase : ICommand
  {
    private readonly Action _action;
    private readonly Func<bool> _canExecuteAction; 

    public CommandBase(Action action, Func<bool> canExecuteAction = null)
    {
      _action = action;

      if (canExecuteAction == null)
        _canExecuteAction = () => true;
      else
      _canExecuteAction = canExecuteAction;
    }

    public bool CanExecute(object parameter)
    {
      return _canExecuteAction();
    }

    public void Execute(object parameter)
    {
      _action();
    }

    public event EventHandler CanExecuteChanged;

    public void RaiseCanExecuteChanged()
    {
      CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
  }
}