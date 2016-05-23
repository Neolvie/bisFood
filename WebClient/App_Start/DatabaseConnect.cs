using System.Configuration;

namespace WebClient
{
  public class DatabaseConnect
  {
    public static void Initialize()
    {
      var conStr = ConfigurationManager.ConnectionStrings["DatabaseConnect"].ConnectionString;

      Shared.NHibernate.Environment.Initialize(conStr);
    }
  }
}