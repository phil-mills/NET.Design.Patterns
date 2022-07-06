namespace NET.Design_Patterns.Pipeline
{
    using System.Threading.Tasks;

    /// Summary:
    ///     This interface is used to define the contract of a processor.
    public interface IProcessor
    {   
        /// Summary:
        ///     A method used to execute the processor logic.
        /// 
        /// Parameters:
        ///     content:
        ///         An object to process.
        /// 
        /// Returns:
        ///     A task result containing an object.
        Task<object> ExecuteAsync(object content);

        /// Summary:
        ///     This method is used to extract content from an object.
        /// 
        /// Type parameters:
        ///     T:
        ///         Type of content to try parse into.
        /// 
        /// Parameters:
        ///     content:
        ///         An object to extract content from.
        /// 
        /// Returns: 
        ///     A newly extracted content object.
        T ExtractContent<T>(object content);
    }

    /// Summary:
    ///     This delegate is used within a processor to allow for linking to another processors ExecuteAsync method.
    /// 
    /// Parameters:
    ///     content:
    ///         An object to process.
    /// 
    /// Returns:
    ///     A task result containing an object.
    public delegate Task<object> ProcessorDelegate(object content);
}