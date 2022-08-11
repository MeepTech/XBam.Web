using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Meep.Tech.Web {

  /// <summary>
  /// A data transfer object
  /// </summary>
  public abstract record Dto {

    /// <summary>
    /// If the request that asked for the data was successful
    /// </summary>
    public virtual bool Success { get; init; }

    /// <summary>
    /// An optional status message about the result of the request
    /// </summary>
    public string Message { get; init; }

    /// <summary>
    /// Metadata about the result of the request.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyDictionary<string, object> MetaData {
      get; 
      init; 
    }
  }
}
