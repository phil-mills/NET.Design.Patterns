namespace NET.Design_Patterns.Command.UseCase
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;

    /// Summary:
    ///     This class is used to define a command runner.
    public class CommandRunner : ICommandRunner
    {      
        /// Summary:
        ///     Service provider used for dependancy injection.
        private readonly IServiceProvider serviceProvider;

        /// Constructors:
        ///     A default constructor used when creating this class.
        /// 
        /// Parameters:
        ///     provider:
        ///         A service provider for dependancy injection.
        public CommandRunner(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// Summary:
        ///     This method is used to execute the command.
        /// 
        /// Parameters:
        ///     command: 
        ///         A command to execute.
        /// 
        ///     content:
        ///         An object to process.
        ///
        /// Returns:
        ///     A task result containing an object.
        public async Task<object> ExecuteAsync(ICommand command, object content)
        {
            var response = new object();

            try 
            {
                response = await command.ExecuteAsync(content);
            }
            catch { }

            return Task.FromResult(response);
        }

        /// Summary:
        ///     This method is used to execute the command.
        ///
        /// Parameters:
        ///     command: 
        ///         A command to execute.
        /// 
        ///     content:
        ///         An object to process.
        ///
        /// Returns:
        ///     A task result containing an object.
        public async Task<object> ExecuteAsync<T>(T command, object content)
        where T : ICommand
        {
            var c = (ICommand) ActivatorUtilities.CreateInstance(this.serviceProvider, typeof(T));

            return await this.ExecuteAsync(c, content);
        }
    }
}