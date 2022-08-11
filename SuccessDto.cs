namespace Meep.Tech.Web {

  /// <summary>
  /// A Dto signifying a simple success state.
  /// </summary>
  public record SuccessDto : Dto {
    public override bool Success
      => true;
  }
  
  /// <summary>
  /// A Dto signifying a simple success state, containing the requested data.
  /// </summary>
  public record SuccessDto<TResult> : SuccessDto {
    public virtual TResult Result { get; init; }
  }
}
