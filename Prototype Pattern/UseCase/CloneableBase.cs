namespace NET.Design_Patterns.Prototype_Pattern.UseCase
{
    using System.Text.Json;
    using NET.Design_Patterns.Prototype;

    /// Summary:
    ///     This class is used to define a cloneable base.
    /// 
    /// Type parameter:
    ///     T:
    ///         Generic type to base the cloneable on.
    public class CloneableBase<T> : ICloneable<T>
    {
        /// Summary:
        ///     This method is used to deep clone the parent object.
        public T Clone()
        {
            var json = JsonSerializer.Serialize(this);

            return JsonSerializer.Deserialize<T>(json);
        }
    }
}