namespace NET.Design_Patterns.Observer
{
    /// Summary:
    ///     This interface is used to define the contract of a listener.
    public interface IListener
    {   
        /// Summary:
        ///     This method is used to receive a message from the subject.
        /// 
        /// Parameters:
        ///     message:
        ///         An object message.
        void ReceiveMessage(object message);
    }
}