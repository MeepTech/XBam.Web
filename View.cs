using Meep.Tech.Data;

namespace Meep.Tech.Web {

  /// <summary>
  /// Make a view for a type of model.
  /// Views hold a subset of read-only data and data manipulation logic from a model specific to a given display case.
  /// </summary>
  public abstract record View {

    /// <summary>
    /// The model type this view is for.
    /// </summary>
    public abstract System.Type ModelType { get; }

    protected View(IModel model) {}
  }
  
  /// <summary>
  /// Make a view for a type of model.
  /// Views hold a subset of read-only data and data manipulation logic from a model specific to a given display case.
  /// </summary>
  public abstract record View<TModel> : View where TModel : IModel {

    /// <summary>
    /// The model type this view is for.
    /// </summary>
    public override System.Type ModelType
      => typeof(TModel);
    
    /// <summary>
    /// Make a view from the given model.
    /// All views must have a public version of this constructor
    /// </summary>
    protected View(TModel model) 
      : base(model) {}
  }
}
