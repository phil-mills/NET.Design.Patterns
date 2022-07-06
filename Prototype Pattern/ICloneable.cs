namespace NET.Design_Patterns.Prototype
{
    using System.Text.Json;

    /// Summary:
    ///     This interface is used to define the contract of a cloneable.
    /// 
    /// Type parameter:
    ///     T:
    ///         Generic type to base the cloneable on.
    public interface ICloneable<T>
    {
        /// Summary:
        ///     This method is used to clone the parent object.
        T Clone();
    }
}