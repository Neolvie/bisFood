using FluentNHibernate.Mapping;

namespace Shared.NHibernate.Mapping.Base
{
  public class IngredientBaseMap : ClassMap<Core.Entities.Base.IngredientBase>
  {
    public IngredientBaseMap()
    {
      Table("Ingredients");
      Id(x => x.Id);
      Map(x => x.TypeGuid).Column("TypeGuid").Not.Insert().Not.Update();
      References(x => x.Product).Column("Product").Not.Nullable();
      Map(x => x.Value);

      DiscriminateSubClassesOnColumn("TypeGuid");
    }
  }
}