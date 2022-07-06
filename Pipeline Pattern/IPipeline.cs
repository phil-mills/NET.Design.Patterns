namespace NET.Design_Patterns.Pipeline
{
    using System.Threading.Tasks;
    
    /// Summary:
    ///     This interface is used to define the contract of a pipeline.
    public interface IPipeline
    {   
        /// Summary:
        ///     This method allows for processor registration using generic type. 
        /// 
        /// Type parameters:
        ///     T:
        ///         Generic type of the processor.
        void RegisterProcess<T>()
        where T : ProcessorBase;

        /// Summary:
        ///     This method is used to execute the pipeline and run the first registered processor.
        /// 
        /// Parameters:
        ///     content:
        ///         An object to process.
        ///
        /// Returns:
        ///     A task that represents the asynchronous operation.
        Task ExecuteAsync(object content);
    }
}