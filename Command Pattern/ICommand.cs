namespace NET.Design_Patterns.Command
{
    using System.Threading.Tasks;

    /// Summary:
    ///     This interface is used to define the contract of a command.
    public interface ICommand
    {
        /// Summary:
        ///     This method is used to execute the command logic.
        /// 
        /// Parameters:
        ///     content:
        ///         An object to process.
        ///
        /// Returns:
        ///     A task result containing an object.
        Task<object> ExecuteAsync(object content);
    }
}