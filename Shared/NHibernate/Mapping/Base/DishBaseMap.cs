using FluentNHibernate.Mapping;

namespace Shared.NHibernate.Mapping.Base
{
  public class DishBaseMap : SubclassMap<Core.Entities.Base.DishBase>
  {
    public DishBaseMap()
    {
      Abstract();
    }
  }
}