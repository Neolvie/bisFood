using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClientBase.Commands;
using ClientBase.ViewModel.Base;

namespace ManagerClient.View.Entities
{
  /// <summary>
  /// Interaction logic for EntityBaseView.xaml
  /// </summary>
  public partial class EntityBaseView
  {

    public EntityBaseView(Window owner, ViewModelBase content)
    {
      InitializeComponent();

      Owner = owner;
      EntityContent.Content = content;
      Title = content.PageTitle;

      DeleteCommand = new SimpleCommand(() =>
      {
        content.DeleteCommand.Execute(null);
        Close();
      }, () => content.DeleteCommand.CanExecute(null));

      SaveCommand = new SimpleCommand(() =>
      {
        content.SaveCommand.Execute(null);
        ((SimpleCommand)DeleteCommand).RaiseCanExecuteChanged();
      }, () => content.SaveCommand.CanExecute(null));

      SaveAndCloseCommand = new SimpleCommand(() =>
      {
        SaveCommand.Execute(null);
        if (!content.HasError)
          Close();
      }, () => SaveCommand.CanExecute(null));
     
    }
  }
}
