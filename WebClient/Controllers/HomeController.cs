using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientBase.ViewModel;
using Shared.Core.Entities;
using Shared.NHibernate;

namespace WebClient.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      var dishesList = new List<DishViewModel>();
      var prepacksList = new List<PrepackViewModel>();
      var productsList = new List<ProductViewModel>();

      var dishes = Repository.Get<Dish>();
      var prepacks = Repository.Get<Prepack>();
      var products = Repository.Get<Product>();

      dishesList.AddRange(dishes.Select(x => new DishViewModel(x)));
      prepacksList.AddRange(prepacks.Select(x => new PrepackViewModel(x)));
      productsList.AddRange(products.Select(x => new ProductViewModel(x)));

      ViewBag.DishList = dishesList;
      ViewBag.PrepackList = prepacksList;
      ViewBag.ProductList = productsList;

      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}