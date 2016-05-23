using FluentNHibernate.Mapping;

namespace Shared.NHibernate.Mapping
{
  public class PrepackMap : SubclassMap<Core.Entities.Prepack>
  {
    public PrepackMap()
    {
      DiscriminatorValue("EB8EDEDB-3851-42E0-B39C-A5643960F0DC");
    }  
  }
}