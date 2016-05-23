using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;
using ClientBase.Commands;
using Shared.Core.Entities;
using Shared.Core.Entities.Base;
using Shared.Extenders;
using Shared.NHibernate;

namespace ClientBase.ViewModel.Base
{
  /// <summary>
  /// Базовая ViewModel полуфабриката.
  /// </summary>
  /// <typeparam name="T">Тип полуфабриката.</typeparam>
  public abstract class PrepackBaseViewModel<T> : ProductBaseViewModel<T> where T : PrepackBase
  {
    /// <summary>
    /// Список ингредиентов.
    /// </summary>
    public ObservableCollection<ProductBase> Products { get; set; }

    /// <summary>
    /// Ингредиенты.
    /// </summary>
    [Display(Name = "Ингредиенты")]
    public ObservableCollection<IngredientViewModel> Ingredients { get; set; }

    protected PrepackBaseViewModel(T entity) : base(entity)
    {
      InitializeCollections();

      // Заполнение ингредиентов из сущности.
      foreach (var ingredient in entity.Ingredients)
        Ingredients.Add(new IngredientViewModel(ingredient));

      // Подписка на события коллекции.
      Ingredients.CollectionChanged += IngredientsOnCollectionDeleted;
      Ingredients.CollectionChanged += IngredientsOnCollectionAdded;

      Products.AddRange(Repository.Get<ProductBase>().ToList()
        .Where(x => !(x is DishBase))
        .Where(x => x.Id != entity.Id)
        .OrderBy(x => x.Name));

      AddIngredient = new SimpleCommand(() => { Ingredients.Add(new IngredientViewModel(new Ingredient())); });

      RemoveIngredient = new SimpleCommand(() =>
      {
        if (SelectedIngredient == null)
          return;

        Ingredients.Remove(SelectedIngredient);
      });
    }

    protected PrepackBaseViewModel()
    {
      InitializeCollections();
    }

    private void InitializeCollections()
    {
      Ingredients = new ObservableCollection<IngredientViewModel>();

      Products = new ObservableCollection<ProductBase>();
    }

    public ICommand AddIngredient { get; private set; }
    public ICommand RemoveIngredient { get; private set; }

    /// <summary>
    /// Выбранный ингредиент.
    /// </summary>
    public IngredientViewModel SelectedIngredient
    {
      get { return _selectedIngredient; }
      set
      {
        _selectedIngredient = value;
        OnPropertyChanged();
      }
    }
    private IngredientViewModel _selectedIngredient;

    /// <summary>
    /// Трансляция добавления ингредиента во ViewModel коллекцию в коллекцию ингредиентов сущности.
    /// </summary>
    private void IngredientsOnCollectionAdded(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
    {
      if (notifyCollectionChangedEventArgs.Action != NotifyCollectionChangedAction.Add)
        return;

      foreach (IngredientViewModel newItem in notifyCollectionChangedEventArgs.NewItems)
        Entity.Ingredients.Add(newItem.Entity);
    }

    /// <summary>
    /// Трансляция удаления ингредиента из ViewModel коллекции в коллекцию ингредиентов сущности.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="notifyCollectionChangedEventArgs"></param>
    private void IngredientsOnCollectionDeleted(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
    {
      if (notifyCollectionChangedEventArgs.Action != NotifyCollectionChangedAction.Remove)
        return;

      foreach (IngredientViewModel oldItem in notifyCollectionChangedEventArgs.OldItems)
        Entity.Ingredients.Remove(oldItem.Entity);
    }

    protected override string Validate(string columnName)
    {
      var result = base.Validate(columnName);

      foreach (var ingredient in Ingredients)
      {
        ingredient.ValidationErrors.Clear();

        ingredient.ValidationOnSaving = true;
        ingredient.OnPropertyChanged(string.Empty);
        ingredient.ValidationOnSaving = false;

        var newErrors =
          ingredient.ValidationErrors.Where(x => ValidationErrors.All(t => t.PropertyName != x.PropertyName));

        ValidationErrors.AddRange(newErrors);
      }

      return result;
    }
  }
}