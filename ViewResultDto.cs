using System;
using Meep.Tech.Data;

namespace Meep.Tech.Web {

  /// <summary>
  /// Shortcut to make a success dto from a view.
  /// </summary>
  public record ViewResultDto<TView, TModel> : SuccessDto<TView> where TView : View<TModel> where TModel : IModel {
    public override TView Result 
      => base.Result;

    /// <summary>
    /// Make a successful reply dto from a model.
    /// </summary>
    public ViewResultDto(TModel from) {
      try {
        Result = (TView)Activator.CreateInstance(typeof(TView), from);
      } catch(Exception ex) {
        throw new MissingMethodException($"Could not find constructor for View type: {typeof(TView).FullName}, with a single parameter of Model type: {typeof(IModel).FullName}", ex);
      }
    }
  }
}
