namespace NET.Design_Patterns.Command
{
    using System.Threading.Tasks;

    /// Summary:
    ///     This interface is used to define the contract of a command runner.
    public interface ICommandRunner
    {
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
        Task<object> ExecuteAsync(ICommand command, object content);

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
        Task<object> ExecuteAsync<T>(T command, object content)
        where T : ICommand;
    }
}