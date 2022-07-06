namespace NET.Design_Patterns.Builder
{
    /// Summary:
    ///     This interface is used to define the contract of a model builder.
    public interface IModelBuilder
    {
        /// Summary:
        ///     This method is used to build an object model.
        /// 
        /// Type parameter:
        ///     T:
        ///         Generic type to base the model builder on.
        /// 
        /// Returns:
        ///     A build model of the generic type.
        T BuildModel<T>();
    }

    /// Summary:
    ///     This interface is used to define the contract of a model builder.
    /// 
    /// Type parameter:
    ///     T:
    ///         Generic type to base the model builder on.
    public interface IModelBuilder<T>
    {
        /// Summary:
        ///     This method is used to build an object model.
        /// 
        /// Returns:
        ///     A build model of the generic type.
        T BuildModel();
    }
}