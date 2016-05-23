using System;

namespace ClientBase.Commands
{
  public class SimpleCommand : CommandBase
  {
    public SimpleCommand(Action action, Func<bool> canExecuteAction = null) : base(action, canExecuteAction)
    {
    }
  }
}