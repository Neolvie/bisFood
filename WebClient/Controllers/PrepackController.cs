using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientBase.ViewModel;
using Shared.Core.Entities;
using Shared.Core.Enum;
using Shared.NHibernate;
using WebClient.Helpers.Extenders;

namespace WebClient.Controllers
{
  public class PrepackController : Controller
  {
    // GET: Prepack
    [HttpGet]
    public ActionResult Index(int id = 0)
    {
      var prepack = Repository.Get<Prepack>().FirstOrDefault(x => x.Id == id) ?? new Prepack();

      prepack.Update();

      ViewBag.UnitsList = prepack.Unit.ToSelectList();
      ViewBag.Title = Helpers.PageHelpers.GetPageTitle(prepack);

      return View(prepack);
    }

    [HttpPost]
    public ActionResult Index(Prepack model)
    {
      if (ModelState.IsValid)
      {
        model.Save();
      }

      ViewBag.UnitsList = model.Unit.ToSelectList();
      ViewBag.Title = Helpers.PageHelpers.GetPageTitle(model);

      return View(model);
    }

    public ActionResult AddNewIngredientRow()
    {
      ViewData["UnitsList"] = Units.Kg.ToSelectList();
      return PartialView("Ingredient/IngredientRow", new Ingredient());
    }
  }
}