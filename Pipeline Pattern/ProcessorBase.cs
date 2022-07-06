namespace NET.Design_Patterns.Pipeline
{
    using System;
    using System.Threading.Tasks;
    
    /// Summary:
    ///     This class is used to define the base contract of a processor.
    public abstract class ProcessorBase : IProcessor
    {   
        /// Summary:
        ///     A delegate used to define the next processor.
        private ProcessorDelegate _Next;

        /// Summary:
        ///     A delegate Get and Set used as a wrapper around _Next.
        public ProcessorDelegate Next 
        { 
            protected get 
            {
                return _Next; 
            }

            set 
            {
                if (_Next == null)
                {
                    _Next = value;
                }
            }
        }

        /// Summary:
        ///     A method used to execute the processor logic.
        /// 
        /// Parameters:
        ///     content:
        ///         An object to process.
        /// 
        /// Returns:
        ///     A task result containing an object.
        /// 
        /// Exceptions:
        ///     T:NotImplementedException:
        ///         Thrown if method is not overriden.
        public virtual Task<object> ExecuteAsync(object content)
        {
            throw new NotImplementedException();
        }
        
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
        public virtual T ExtractContent<T>(object content)
        {
            return (T) content;
        }
    }
}