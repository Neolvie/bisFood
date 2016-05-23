using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientBase.ViewModel;
using Shared.Core.Entities;
using Shared.NHibernate;
using WebClient.Helpers.Extenders;
using EnumExtenders = WebClient.Helpers.Extenders.EnumExtenders;

namespace WebClient.Controllers
{
  public class ProductController : Controller
  {
    // GET: Product
    [HttpGet]
    public ActionResult Index(int id = 0)
    {
      var product = Repository.Get<Product>().FirstOrDefault(x => x.Id == id) ?? new Product();

      product.Update();

      ViewBag.UnitsList = product.Unit.ToSelectList();

      ViewBag.Title = Helpers.PageHelpers.GetPageTitle(product);

      return View(product);
    }

    [HttpPost]
    public ActionResult Index(Product model)
    {
      if (ModelState.IsValid)
      {
        model.Save();
      }

      ViewBag.UnitsList = EnumExtenders.ToSelectList(model.Unit);
      ViewBag.Title = Helpers.PageHelpers.GetPageTitle(model);

      return View(model);
    }
  }
}