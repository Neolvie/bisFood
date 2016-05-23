using FluentNHibernate.Mapping;

namespace Shared.NHibernate.Mapping.Base
{
  public class ProductBaseMap : ClassMap<Core.Entities.Base.ProductBase>
  {
    public ProductBaseMap()
    {
      Table("Products");
      Id(x => x.Id);
      Map(x => x.TypeGuid).Column("TypeGuid").Not.Insert().Not.Update();
      Map(x => x.Name);
      Map(x => x.Price);
      Map(x => x.CanBeSold);
      Map(x => x.Unit);

      DiscriminateSubClassesOnColumn("TypeGuid");     
    }
  }
}