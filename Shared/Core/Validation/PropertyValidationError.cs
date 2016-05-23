using Shared.Core.Enum;

namespace Shared.Core.Validation
{
  public class PropertyValidationError
  {
    public string PropertyName { get; set; }

    public string Text { get; set; }

    public ErrorType Type { get; set; }

    public PropertyValidationError(string propertyName, string textError, ErrorType errorType)
    {
      PropertyName = propertyName;
      Text = textError;
      Type = errorType;
    }
  }
}