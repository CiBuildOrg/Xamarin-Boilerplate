using System;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Portable;
using Validation;

namespace XamarinBoilerplate.Core.Utilities.Auth
{
    /// <summary>
    /// Extensions to the <see cref="IRestClient"/> interface.
    /// </summary>
    public static class RestClientExtensions
    {
        /// <summary>
        /// Executes a request asynchronously.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="request">The request.</param>
        /// <param name="token">The token.</param>
        /// <returns>The asynchronous request task.</returns>
        public static async Task<IRestResponse> ExecuteAsync(this IRestClient client, IRestRequest request, CancellationToken token)
        {
            Requires.NotNull(client, "client");
            Requires.NotNull(request, "request");

            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();

            try
            {
                await client.Execute(request, token)
                    .ContinueWith(response =>
                    {
                        if (token.IsCancellationRequested)
                        {
                            taskCompletionSource.TrySetCanceled();
                        }
                        else if (response.Exception != null)
                        {
                            taskCompletionSource.TrySetException(response.Exception);
                        }
                        else if ((int)response.Result.StatusCode > 400)
                        {
                            taskCompletionSource.TrySetException(response.Result.StatusCode.ToHttpException());
                        }
                        else
                        {
                            taskCompletionSource.TrySetResult(response.Result);
                        }
                    }, token);

                token.Register(() =>
                    {
                        taskCompletionSource.TrySetCanceled();
                    });
            }
            catch (Exception ex)
            {
                taskCompletionSource.TrySetException(ex);
            }

            return taskCompletionSource.Task.Result;
        }
    }
}