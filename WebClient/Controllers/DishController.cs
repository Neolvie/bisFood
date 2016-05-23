using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientBase.ViewModel;
using Shared.Core.Entities;
using Shared.NHibernate;
using WebClient.Helpers.Extenders;

namespace WebClient.Controllers
{
  public class DishController : Controller
  {
    // GET: Dish
    [HttpGet]
    public ActionResult Index(int id = 0)
    {
      var dish = Repository.Get<Dish>().FirstOrDefault(x => x.Id == id) ?? new Dish();

      dish.Update();

      ViewBag.UnitsList = dish.Unit.ToSelectList();
      ViewBag.Title = Helpers.PageHelpers.GetPageTitle(dish);

      return View(dish);
    }

    [HttpPost]
    public ActionResult Index(Dish model)
    {
      if (ModelState.IsValid)
      {
        model.Save();
      }

      ViewBag.UnitsList = model.Unit.ToSelectList();
      ViewBag.Title = Helpers.PageHelpers.GetPageTitle(model);

      return View(model);
    }
  }
}