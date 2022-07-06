namespace NET.Design_Patterns.Observer.UseCase
{
    using System.Collections.Generic;

    /// Summary:
    ///     This class is used to define a subject.
    public class MessageSender : IMessageSender
    {
        /// Summary:
        ///     A collection of listeners registered with this subject.
        private List<IListener> listeners; 

        /// Constructors:
        ///      A default parameterless constructor used when creating this class.
        public MessageSender()
        {
            listeners = new List<IListener>();
        }

        /// Constructors:
        ///      A parameterised constructor used when creating this class.
        /// 
        /// Parameters:
        ///     listerners:
        ///         A collection of listeners to register with this message sender.
        public MessageSender(List<IListener> listeners)
        {
            this.listeners = listeners;
        }

        /// Summary:
        ///     This method is used to register an listener.
        /// 
        /// Parameters:
        ///     listener:
        ///         An listener to register.
        /// 
        /// Returns:
        ///     true if listener is registered; othwise false.
        public bool Register(IListener listener) 
        {
            listeners.Add(listener);
            
            return listeners.Contains(listener);
        }

        /// Summary:
        ///     This method is used to unregister an listener.
        /// 
        /// Parameters:
        ///     listener:
        ///         An listener to unregister.
        /// 
        /// Returns:
        ///     True if listener is unregistered; othwise false.
        public bool Unregister(IListener listener) 
        {
            return listeners.Remove(listener);
        }

        /// Summary:
        ///     This method is used to notify listeners of a message.
        ///
        /// Parameters:
        ///     message:
        ///         An object message.
        public void Notifylisteners(object message)
        {
            listeners.ForEach(listener => 
            {
                listener.ReceiveMessage(message);
            });
        }
    }
}