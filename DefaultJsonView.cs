using Meep.Tech.Data;
using Meep.Tech.Data.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Meep.Tech.Web {

  /// <summary>
  /// Base interface for DefaultJsonView.
  /// Can be used to make a simple default json view with all the public data
  /// </summary>
  public interface IDefaultJsonView {
    protected internal IModel _model { get; }
  }

  /// <summary>
  /// Can be used to make a simple default json view with all the public data
  /// </summary>
  [JsonConverter(typeof(View))]
  public record DefaultJsonView<TModel> : View<TModel>, IDefaultJsonView where TModel : IModel {  
    TModel _model;
    IModel IDefaultJsonView._model 
      => _model;

    /// <summary>
    /// Make a view from the given model.
    /// All views must have a public version of this constructor
    /// </summary>
    public DefaultJsonView(TModel model)
      : base(model) {
        _model = model;
      }
  }

  /// <summary>
  /// Json converter for DefaultJsonView.
  /// </summary>
  public class DefaultJsonViewConverter : JsonConverter {

    public override bool CanConvert(Type objectType)
      => objectType.IsAssignableToGeneric(typeof(DefaultJsonView<>));

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      var model = IModel.FromJson(JObject.Load(reader), existingValue?.GetType());
      Type viewType = typeof(DefaultJsonView<>).MakeGenericType(model.GetType());
      var view = Activator.CreateInstance(viewType, model);

      return view;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      => (value as IDefaultJsonView)._model.ToJson().WriteTo(writer);
  }
}
