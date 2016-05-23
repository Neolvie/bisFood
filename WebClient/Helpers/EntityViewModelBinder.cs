
using System;
using System.Linq;
using System.Web.Mvc;
using ClientBase.ViewModel;
using ClientBase.ViewModel.Base;
using Shared.Core.Entities;
using Shared.Core.Entities.Base;
using Shared.NHibernate;

namespace WebClient.Helpers
{
  public class EntityViewModelBinder : DefaultModelBinder
  {
    private const string TempId = "tempId";
    private const string EntityPropertyName = "Entity";

    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext,
      Type modelType)
    {
      if (Shared.Helpers.Helper.IsSubclassOfRawGeneric(typeof (EntityViewModel<>), modelType))
      {
        if (modelType == typeof (IngredientViewModel))
        {
          var ingredientId =
            Convert.ToInt32(
              bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".IngredientId").AttemptedValue);

          var entity = Repository.Get<Ingredient>().FirstOrDefault(x => x.Id == ingredientId);

          if (entity != null)
            return new IngredientViewModel(entity);
        }

        {
          var model = base.CreateModel(controllerContext, bindingContext, modelType);

          var request = controllerContext.HttpContext.Request;

          var tempId = (from key
            in request.Form.AllKeys
            where key.Equals(TempId, StringComparison.InvariantCultureIgnoreCase)
            select Convert.ToInt32(request.Form.Get(key))).FirstOrDefault();

          var property = model.GetType().GetProperty(EntityPropertyName);
          dynamic entityProperty = property.GetValue(model);
          string typeGuid = entityProperty.TypeGuid;

          var entity = Repository
            .Get<Entity>()
            .FirstOrDefault(x => x.TypeGuid == typeGuid && x.Id == tempId);

          if (entity != null)
            property.SetValue(model, entity);

          return model;
        }
      }
      else
      {
        var model = base.CreateModel(controllerContext, bindingContext, modelType);
        return model;
      }
    }
  }
}