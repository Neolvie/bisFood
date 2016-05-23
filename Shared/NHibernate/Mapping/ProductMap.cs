using FluentNHibernate.Mapping;

namespace Shared.NHibernate.Mapping
{
  public class ProductMap : SubclassMap<Core.Entities.Product>
  {
    public ProductMap()
    {
      DiscriminatorValue("38DEFC8D-F682-485E-BF3B-06C799B613BA");
    }
  }
}