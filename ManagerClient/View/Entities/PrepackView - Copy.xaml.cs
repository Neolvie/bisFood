using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ManagerClient.ViewModel;
using ManagerClient.ViewModel.Base;
using NHibernate.Proxy;
using Shared.Core.Entities;
using Shared.Core.Entities.Base;
using Shared.Extenders;
using Shared.NHibernate;

namespace ManagerClient.View.Entities
{
  /// <summary>
  /// Interaction logic for PrepackView.xaml
  /// </summary>
  public partial class PrepackView
  {
    #region Поля и свойства

    /// <summary>
    /// Список ингредиентов.
    /// </summary>
    public ObservableCollection<ProductBase> Products { get; set; }

    /// <summary>
    /// Полуфабрикат.
    /// </summary>
    public PrepackViewModel Prepack
    {
      get { return _prepack; }
      set
      {
        _prepack = value;

        if (value != null)
          PageTitle = _prepack.Name;

        OnPropertyChanged();
      }
    }
    private PrepackViewModel _prepack;

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

    #endregion

    #region Конструкторы

    /// <summary>
    /// Базовый конструктор окна полуфабриката.
    /// </summary>
    public PrepackView()
    {
      if (Prepack == null)
        Prepack = new PrepackViewModel(new Prepack());


      Products = new ObservableCollection<ProductBase>();

      Products.AddRange(Repository.Get<ProductBase>().Where(x => !(x is DishBase)).OrderBy(x => x.Name));

      InitializeComponent();

      UnitList.ItemsSource = Shared.Extenders.EnumExtenders.Units;
      UnitList.DisplayMemberPath = "Value";
      UnitList.SelectedValuePath = "Key";
    }

    /// <summary>
    /// Конструктор, если есть ViewModel полуфабриката.
    /// </summary>
    /// <param name="prepack">ViewModel полуфабриката.</param>
    public PrepackView(PrepackViewModel prepack) : this()
    {
      Prepack = prepack;

      // Удаляем полуфабрикат из списка ингредиентов, чтобы нельзя было выбрать самого себя.
      Products.Remove(Prepack.Entity);
    }

    /// <summary>
    /// Конструктор, если есть только сущность полуфабриката.
    /// </summary>
    /// <param name="prepack"></param>
    public PrepackView(PrepackBase prepack) : this()
    {
      Prepack = new PrepackViewModel(prepack);
    }

    #endregion

    #region События

    private void DeleteIngredient_OnClick(object sender, RoutedEventArgs e)
    {
      if (SelectedIngredient == null)
        return;

      Prepack.Ingredients.Remove(SelectedIngredient);
    }

    private void AddIngredient_OnClick(object sender, RoutedEventArgs e)
    {
      Prepack.Ingredients.Add(new IngredientViewModel(new Ingredient()));
    }

    #endregion

    private string _pageTitle;

    public override string PageTitle
    {
      get { return _pageTitle; }
      set
      {
        _pageTitle = string.IsNullOrEmpty(value)
          ? $"Новая запись \"{Prepack.Entity.TypeName}\""
          : $"{Prepack.Entity.TypeName} - {value}";

        OnPropertyChanged();
      }
    }

    public override ICommand SaveCommand => Prepack.SaveCommand;
    public override ICommand DeleteCommand => Prepack.DeleteCommand;
  }
}
