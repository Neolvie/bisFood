namespace Shared.Core.Interfaces
{
  /// <summary>
  /// Интерфейс сущности.
  /// </summary>
  public interface IEntity
  {
    int Id { get; set; }
    string TypeGuid { get; }
    string TypeName { get; }
    string Name { get; set; }
    void Save();
    void Update();
    void Delete();

    event EntityEventHandler EntitySaved;
    event EntityEventHandler EntityDeleted;
    event EntityEventHandler EntityUpdated;
  }

  public delegate void EntityEventHandler();
}