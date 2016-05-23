using System;
using System.ComponentModel.DataAnnotations;
using ClientBase.ViewModel.Base;
using Shared.Core.Entities;
using Shared.Core.Entities.Base;

namespace ClientBase.ViewModel
{
  /// <summary>
  /// ViewModel ингредиента.
  /// </summary>
  public class IngredientViewModel : EntityViewModel<Ingredient>
  {
    public IngredientViewModel(Ingredient entity) : base(entity)
    {
    }

    public IngredientViewModel()
    {
      Entity = new Ingredient();
    }

    [Required(ErrorMessage = "Необходимо указать продукт")]
    [Display(Name = "Продукт")]
    public ProductBase Product
    {
      get { return Entity.Product; }
      set
      {
        Entity.Product = value;
        OnPropertyChanged();
      }
    }

    [Range(0.00001, double.MaxValue, ErrorMessage = "Необходимо указать количество продукта")]
    [Display(Name = "Количество")]
    public double Value
    {
      get { return Entity.Value; }
      set
      {
        Entity.Value = value;
        OnPropertyChanged();
      }
    }

    protected override string Validate(string columnName)
    {
      var result = base.Validate(columnName);

      if (columnName == "Product")
      {
        if (Product == null)
          result = "Необходимо указать продукт";
      }

      if (columnName == "Value")
      {
        if (Value == 0)
          result = "Необходимо указать количество продукта";
      }
      return result;
    }
  }
}