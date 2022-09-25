namespace NET.Design_Patterns.Retry.Usecase
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// Summary:
    ///     This class is used to define a retry wrapper.
    public class Retry : IRetry
    {
        /// Summary:
        ///     Maximum retrys to attempt.
        public int MaxRetries { get; set; } = 5; 

        /// Summary:
        ///     Duration timeout in ms between each retry attempt.            
        public int TimeoutDuration { get; set; } = 500;

        /// Summary:
        ///     A collection of error codes to retry on.  
        public List<HttpStatusCode> TransientErrorCodes { get; set; } = new List<HttpStatusCode> { HttpStatusCode.RequestTimeout };

        /// Summary:
        ///     Used to perform retry logic on a collection of transient errors.
        ///     
        ///     Use RetryAsync by passing in a function expected to be a client http call
        /// 
        ///     var response = await this.RetryAsync(async () => 
        ///     { 
        ///         return await client.GetAsync(uri);
        ///     });
        /// 
        /// Parameters:
        ///     block:
        ///         A block to pass a function into.
        ///
        /// Returns:
        ///     A task result containing an http response message.
        public async Task<HttpResponseMessage> RetryAsync(Func<Task<HttpResponseMessage>> block)
        {
            var retries = 0;

            HttpResponseMessage result = null;

            while(retries++ < MaxRetries)
            {
                result = await block();

                if (!this.TransientErrorCodes.Contains(result.StatusCode)) 
                {
                    return result;
                }

                await Task.Delay(TimeoutDuration);
            }

            return result;
        }
    }
}