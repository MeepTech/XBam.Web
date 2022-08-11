using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Meep.Tech.Web {

  /// <summary>
  /// A Dto signifying a failure to retreive data, and containing errors related to the failure.
  /// </summary>
  public record FailureDto : Dto {
    public override bool Success
      => false;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<object> Errors {
      get; init;
    }
  }
}
