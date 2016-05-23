using FluentNHibernate.Mapping;

namespace Shared.NHibernate.Mapping
{
  public class DishMap : SubclassMap<Core.Entities.Dish>
  {
    public DishMap()
    {
      DiscriminatorValue("D2847EE7-8D1D-4EA7-B343-4387654A7666");
    }
  }
}