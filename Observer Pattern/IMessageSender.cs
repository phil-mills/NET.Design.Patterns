namespace NET.Design_Patterns.Observer
{   
    /// Summary:
    ///     This interface is used to define the contract of a message sender.
    public interface IMessageSender
    {
        /// Summary:
        ///     This method is used to register an listener.
        /// 
        /// Parameters:
        ///     listener:
        ///         An listener to register.
        /// 
        /// Returns:
        ///     true if listener is registered; othwise false.
        bool Register(IListener listener);

        /// Summary:
        ///     This method is used to unregister an listener.
        /// 
        /// Parameters:
        ///     listener:
        ///         An listener to unregister.
        /// 
        /// Returns:
        ///     True if listener is unregistered; othwise false.
        bool Unregister(IListener listener);

        /// Summary:
        ///     This method is used to notify listeners of a message.
        ///
        /// Parameters:
        ///     message:
        ///         An object message.
        void Notifylisteners(object message);
    }
}