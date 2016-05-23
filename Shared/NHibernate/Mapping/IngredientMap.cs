using FluentNHibernate.Mapping;

namespace Shared.NHibernate.Mapping
{
  public class IngredientMap : SubclassMap<Core.Entities.Ingredient>
  {
    public IngredientMap()
    {
      DiscriminatorValue("421180A3-DD5A-4EB3-85AF-4CD02E810551");
    } 
  }
}