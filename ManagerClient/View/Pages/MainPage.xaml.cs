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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClientBase.ViewModel;
using ManagerClient.View.Entities;
using Shared.Core.Entities;
using Shared.Extenders;
using Shared.NHibernate;
using ManagerClient.View;
using NHibernate.Util;

namespace ManagerClient.View.Pages
{
  /// <summary>
  /// Interaction logic for MainPage.xaml
  /// </summary>
  public partial class MainPage : UserControlBase
  {
    public ObservableCollection<DishViewModel> Dishes { get; set; }
    public ObservableCollection<PrepackViewModel> Prepacks { get; set; }
    public ObservableCollection<ProductViewModel> Products { get; set; }

    public DishViewModel SelectedDish { get; set; }
    public PrepackViewModel SelectedPrepack { get; set; }
    public ProductViewModel SelectedProduct { get; set; }

    public MainPage()
    {
      Dishes = new ObservableCollection<DishViewModel>();
      Prepacks = new ObservableCollection<PrepackViewModel>();
      Products = new ObservableCollection<ProductViewModel>();

      InitializeComponent();
    }

    /// <summary>
    /// Обновление списков сущностей.
    /// </summary>
    private void UpdateLists()
    {
      Dishes.Clear();
      Prepacks.Clear();
      Products.Clear();

      Shared.NHibernate.Environment.Session.Clear();

      var dishes = Repository.Get<Dish>();
      foreach (var dish in dishes)
      {
        dish.Update();
        dish.EntitySaved += OnEntityChanged;
        dish.EntityDeleted += OnEntityChanged;
      }

      var prepacks = Repository.Get<Prepack>();
      foreach (var prepack in prepacks)
      {
        prepack.Update();
        prepack.EntitySaved += OnEntityChanged;
        prepack.EntityDeleted += OnEntityChanged;
      }

      var products = Repository.Get<Product>();
      foreach (var product in products)
      {
        product.Update();
        product.EntitySaved += OnEntityChanged;
        product.EntityDeleted += OnEntityChanged;
      }

      Dishes.AddRange(dishes.Select(x => new DishViewModel(x)));
      Prepacks.AddRange(prepacks.Select(x => new PrepackViewModel(x)));
      Products.AddRange(products.Select(x => new ProductViewModel(x)));
    }

    #region События

    private void LoadAll_OnClick(object sender, RoutedEventArgs e)
    {
      UpdateLists();
    }

    private void ProductList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      if (SelectedProduct == null)
        return;

      var productWindow = Factory.CreateEntityWindow(this, SelectedProduct);
      productWindow.Show();
    }

    private void PrepackList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      if (SelectedPrepack == null)
        return;

      var prepackWindow = Factory.CreateEntityWindow(this, SelectedPrepack);
      prepackWindow.Show();

    }

    #endregion

    private void DishList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      if (SelectedDish == null)
        return;
      
      var dishWindow = Factory.CreateEntityWindow(this, SelectedDish);
      dishWindow.Show();
    }

    public void OnEntityChanged()
    {
      UpdateLists();
    }
  }
}
