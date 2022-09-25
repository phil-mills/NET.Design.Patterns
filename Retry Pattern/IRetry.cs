namespace NET.Design_Patterns.Retry
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// Summary:
    ///     This interface is used to define the contract of the retry wrapper.
    public interface IRetry
    {
        /// Summary:
        ///     Maximum retrys to attempt.
        int MaxRetries { get; set; }

        /// Summary:
        ///     Duration timeout in ms between each retry attempt.
        int TimeoutDuration { get; set; }

        /// Summary:
        ///     A collection of the error codes to retry on.
        List<HttpStatusCode> TransientErrorCodes { get; set; }

        /// Summary:
        ///     Used to perform retry logic on a collection of transient errors.
        /// 
        /// Parameters:
        ///     block:
        ///         A block to pass a function into.
        ///
        /// Returns:
        ///     A task result containing an http response message.
        Task<HttpResponseMessage> RetryAsync(Func<Task<HttpResponseMessage>> block);
    }
}