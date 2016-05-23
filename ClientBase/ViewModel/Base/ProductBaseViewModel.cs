using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shared.Core.Entities.Base;
using Shared.Core.Enum;

namespace ClientBase.ViewModel.Base
{
  /// <summary>
  /// Базовая ViewModel продукта.
  /// </summary>
  /// <typeparam name="T">Тип продукта.</typeparam>
  public abstract class ProductBaseViewModel<T> : EntityViewModel<T> where T : ProductBase
  {
    protected ProductBaseViewModel(T product) : base(product)
    {

    }

    protected ProductBaseViewModel()
    {
      
    }

    [Range(0.001, double.MaxValue, ErrorMessage = "Цена должна быть больше 0")]
    [Display(Name = "Цена")]
    public double Price
    {
      get { return Entity.Price; }
      set
      {
        Entity.Price = value;
        OnPropertyChanged();
      }
    }

    [Display(Name = "Единицы измрения")]
    public Units Unit
    {
      get { return Entity.Unit; }
      set
      {
        Entity.Unit = value;
        OnPropertyChanged();
      }
    }

    [Display(Name = "Может быть продан")]
    public bool CanBeSold
    {
      get { return Entity.CanBeSold; }
      set
      {
        Entity.CanBeSold = value;
        OnPropertyChanged();
      }
    }

    protected override string Validate(string columnName)
    {
      var result = base.Validate(columnName);

      if (columnName == "Price")
      {
        if (Price == 0)
          result = "Стоимость товара не может быть 0";
      }

      return result;
    }
  }
}