using Shared.Core.Entities.Base;

namespace WebClient.Helpers
{
  public static class PageHelper
  {
    public static string GetPageTitle(Entity entity)
    {
      return  entity.Id == 0
      ? $"Новая запись \"{entity.TypeName}\""
      : $"{entity.TypeName} - {entity.Name}";
    }
  }
}