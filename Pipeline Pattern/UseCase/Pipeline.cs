namespace NET.Design_Patterns.Pipeline.UseCase
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;

    /// Summary:
    ///     This class is used to define a pipeline.
    ///     ** This class contains a dependacy to Microsoft.Extensions.DependencyInjection.
    public class Pipeline : IPipeline
    {           
        /// Summary:
        ///     Service provider used for dependancy injection when creating instances for
        ///     processor registration.
        private readonly IServiceProvider serviceProvider;

        /// Summary:
        ///     head: 
        ///         The first processor in the chain.
        ///     tail: 
        ///         The last registered processor in the chain.
        private ProcessorBase head, tail;

        /// Constructors:
        ///     A default constructor used when creating this class.
        /// 
        /// Parameters:
        ///     provider:
        ///         A service provider for dependancy injection.
        public Pipeline(IServiceProvider provider)
        {
            this.serviceProvider = provider;
        }

        /// Summary:
        ///     This method allows for processor registration using generic type. All processes 
        ///     registered must implement the base type of ProcessorBase and will be created in
        ///     order of method calls. Ensuring processor order is important as processes will 
        ///     be chained in order of creation, eg;
        /// 
        /// Example:
        ///     this.RegisterProcess<A>()
        ///     this.RegisterProcess<C>()
        ///     this.RegisterProcess<B>()
        /// 
        ///     Will result in A pointing to C and C pointing to B. 
        /// 
        /// Type parameters:
        ///     T:
        ///         Generic type of the processor.
        public void RegisterProcess<T>()
        where T : ProcessorBase
        {   
            var stream = (ProcessorBase) ActivatorUtilities.CreateInstance(this.serviceProvider, typeof(T));

            if (tail != null)
            {
                tail.Next = stream.ExecuteAsync;
            }
        
            if (head == null)
            {
                head = stream;
            }

            tail = stream;
        }

        /// Summary:
        ///     This method is used to execute the pipeline and run the first registered processor.
        /// 
        /// Parameters:
        ///     content:
        ///         An object to process.
        ///
        /// Returns:
        ///     A task that represents the asynchronous operation.
        /// 
        /// Exceptions:
        ///     T:InvalidOperationException:
        ///         Thrown if head is null.
        public async Task ExecuteAsync(object content)
        {
            if (head != null)
            {
                await head.ExecuteAsync(content);
            }

            throw new InvalidOperationException(); 
        }
    }
}
