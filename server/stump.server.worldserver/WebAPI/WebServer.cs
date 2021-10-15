using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Stump.Core.Attributes;
using Stump.Server.BaseServer.Initialization;

namespace Stump.Server.WorldServer.WebAPI
{
    public class WebServer
    {
        [Variable(true, DefinableRunning = false)]
        public static int WebAPIPort = 9000;

        [Variable(true, DefinableRunning = true)]
        public static string WebAPIKey = string.Empty;

        [Initialization(InitializationPass.Last)]
        public static void Initialize()
        {
            try
            {
                // Start OWIN host
                Console.WriteLine($"Loaded WebAPI on {WorldServer.Host}:{WebAPIPort}");
                WebApp.Start<Startup>($"http://{WorldServer.Host}:{WebAPIPort}");
            }
            catch (Exception ex)
            {
                //  throw new Exception($"Cannot start WebAPI: {ex.ToString()}");
            }
        }

        public class ErrorMessageResult : IHttpActionResult
        {
            private readonly string Message;
            private readonly HttpStatusCode StatusCode;

            public ErrorMessageResult(string message, HttpStatusCode statusCode)
            {
                Message = message;
                StatusCode = statusCode;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var response = new HttpResponseMessage(StatusCode)
                {
                    Content = new StringContent(Message)
                };

                return Task.FromResult(response);
            }
        }
    }
}