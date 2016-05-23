
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
  public class EntityModelBinder : DefaultModelBinder
  {
    private const string ModelId = "ModelId";
    private const string ModelType = "ModelType";
    private const string EntityPropertyName = "Entity";

    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext,
      Type modelType)
    {
      if (modelType == typeof(Ingredient))
      {
        var ingredientId =
          Convert.ToInt32(
            bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".IngredientId").AttemptedValue);

        var entity = Repository.Get<Ingredient>().FirstOrDefault(x => x.Id == ingredientId) ?? new Ingredient();

        return entity;
      }

      if (Shared.Helpers.Helper.IsSubclassOfRawGeneric(typeof (Entity), modelType))
      { 

        var request = controllerContext.HttpContext.Request;

        var modelId = (from key
            in request.Form.AllKeys
                      where key.Equals(ModelId, StringComparison.InvariantCultureIgnoreCase)
                      select Convert.ToInt32(request.Form.Get(key))).FirstOrDefault();

        var modelTypeGuid = (from key
            in request.Form.AllKeys
                       where key.Equals(ModelType, StringComparison.InvariantCultureIgnoreCase)
                       select request.Form.Get(key)).FirstOrDefault();

        var entity = Repository.Get<Entity>().FirstOrDefault(x => x.TypeGuid == modelTypeGuid && x.Id == modelId) 
          ?? base.CreateModel(controllerContext, bindingContext, modelType);

        return entity;
      }
      else
      {
        var model = base.CreateModel(controllerContext, bindingContext, modelType);
        return model;
      }
    }
  }
}