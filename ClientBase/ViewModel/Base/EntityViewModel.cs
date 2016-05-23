using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ClientBase.Commands;
using Shared.Core.Enum;
using Shared.Core.Interfaces;
using Shared.Core.Validation;

namespace ClientBase.ViewModel.Base
{
  /// <summary>
  /// Базовая ViewModel сущности.
  /// </summary>
  /// <typeparam name="T">Тип сущности.</typeparam>
  public abstract class EntityViewModel<T> : ViewModelBase, IDataErrorInfo where T : IEntity
  {
    protected T _entity;

    public virtual T Entity
    {
      get { return _entity; }
      set
      {
        _entity = value;
        OnPropertyChanged();
      }
    }

    public void Save()
    {
      ValidationErrors.Clear();
      ValidationOnSaving = true;
      OnPropertyChanged(string.Empty);

      if (!HasError)
      {
        Entity.Save();
        DeleteCommand.RaiseCanExecuteChanged();
        OnPropertyChanged("PageTitle");
      }

      OnPropertyChanged(string.Empty);
      ValidationOnSaving = false;
    }

    public void Delete()
    {
      Entity.Delete();
    }

    protected EntityViewModel(T entity)
    {
      Entity = entity;
    }

    protected EntityViewModel()
    {
      
    }

    public int Id => Entity.Id;

    [Required(ErrorMessage = "Необходимо указать название")]
    [Display(Name = "Название")]
    public string Name
    {
      get { return Entity.Name; }
      set
      {
        Entity.Name = value;
        OnPropertyChanged();
      }
    }

    public string TypeName => Entity.TypeName;

    #region Команды

    public override SimpleCommand SaveCommand => new SimpleCommand(Save);

    public override SimpleCommand DeleteCommand => new SimpleCommand(Delete, () => Id != 0);

    #endregion

    protected virtual string Validate(string columnName)
    {
      string result = null;

      if (columnName == "Name")
      {
        if (string.IsNullOrEmpty(Name))
          result = "Не заполнено обязательное поле: \"Имя\"";
      }

      return result;
    }

    public string this[string columnName]
    {
      get
      {
        string result = null;

        if (!ValidationOnSaving)
          return result;

        result = Validate(columnName);

        if (string.IsNullOrEmpty(result))
          return result;

        if (ValidationErrors.All(x => x.PropertyName != columnName))
          ValidationErrors.Add(new PropertyValidationError(columnName, result, ErrorType.Error));

        return result;
      }
    }

    public string Error => null;

    public override string PageTitle => Entity.Id == 0
      ? $"Новая запись \"{Entity.TypeName}\""
      : $"{Entity.TypeName} - {Entity.Name}";
  }
}