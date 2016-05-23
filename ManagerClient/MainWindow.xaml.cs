using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ClientBase.ViewModel;
using Fluent;
using ManagerClient.View;
using ManagerClient.View.Entities;
using Shared.Core.Entities;
using Shared.Core.Entities.Base;
using Shared.Core.Enum;
using Shared.Extenders;
using Shared.NHibernate;

namespace ManagerClient
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    private int _totalRecordCount;

    public int TotalRecordCount
    {
      get { return _totalRecordCount; }
      set
      {
        _totalRecordCount = value;
        OnPropertyChanged();
      }
    }

    public MainWindow()
    {
      TotalRecordCount = 0;
      Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
    {
      var task = new Task(() =>
      {
        var init = Shared.NHibernate.Environment.Initialized;
      });

      task.Start();
    }

    private void CreateProduct_OnClick(object sender, RoutedEventArgs e)
    {
      var productViewModel = new ProductViewModel(new Product());

      productViewModel.Entity.EntitySaved += MainPage.OnEntityChanged;
      productViewModel.Entity.EntityDeleted += MainPage.OnEntityChanged;

      var productWindow = Factory.CreateEntityWindow(this, productViewModel);
      productWindow.Show();
    }

    private void CreatePrepack_OnClick(object sender, RoutedEventArgs e)
    {
      var prepackViewModel = new PrepackViewModel(new Prepack());

      prepackViewModel.Entity.EntitySaved += MainPage.OnEntityChanged;
      prepackViewModel.Entity.EntityDeleted += MainPage.OnEntityChanged;

      var prepackWindow = Factory.CreateEntityWindow(this, prepackViewModel);
      prepackWindow.Show();
    }

    private void CreateDishMenu_OnClick(object sender, RoutedEventArgs e)
    {
      var dishViewModel = new DishViewModel(new Dish());

      dishViewModel.Entity.EntitySaved += MainPage.OnEntityChanged;
      dishViewModel.Entity.EntityDeleted += MainPage.OnEntityChanged;

      var dishWindow = Factory.CreateEntityWindow(this, dishViewModel);
      dishWindow.Show();
    }

    private void LoadRecordsManu_OnClick(object sender, RoutedEventArgs e)
    {
      TotalRecordCount = Repository.Get<ProductBase>().Count();
    }
  }
}
