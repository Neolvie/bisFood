using FluentNHibernate.Mapping;

namespace Shared.NHibernate.Mapping.Base
{
  public class PrepackBaseMap : SubclassMap<Core.Entities.Base.PrepackBase>
  {
    public PrepackBaseMap()
    {
      Abstract();
      HasMany(x => x.Ingredients).KeyColumn("Prepack").Cascade.AllDeleteOrphan();
    }
  }
}