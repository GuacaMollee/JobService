namespace JobService.Infra.Services
{
    using Flurl;
    using Flurl.Http;
    using JobService.Core.Factories;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class RestService<Tin, Tout>
    {
        private readonly string EndpointUrl;

        public RestService(string endpointUrl)
        {
            EndpointUrl = endpointUrl;

            FlurlHttp.ConfigureClient(EndpointUrl, cli => cli.Settings.HttpClientFactory = new UntrustedCertClientFactory());
        }

        public Task<Tout> Post(Tin body, IDictionary<string, string> headers, object queryParams, CancellationToken cancellationToken)
        {
            try
            {
                return EndpointUrl
                    .WithHeader("Content-Type", "application/json")
                    .WithHeaders(headers)
                    .SetQueryParams(queryParams, NullValueHandling.Remove)
                    .PostJsonAsync(body, cancellationToken, System.Net.Http.HttpCompletionOption.ResponseContentRead).ReceiveJson<Tout>();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Task<Tout> Get(object queryParams, CancellationToken cancellationToken)
        {
            try
            {
                return EndpointUrl
                    .SetQueryParams(queryParams, NullValueHandling.Remove)
                    .GetAsync(cancellationToken, System.Net.Http.HttpCompletionOption.ResponseContentRead).ReceiveJson<Tout>();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Task<Tout> Update(Tin body, object queryParams, CancellationToken cancellationToken)
        {
            try
            {
                return EndpointUrl
                    .WithHeader("Content-Type", "application/json")
                    .SetQueryParams(queryParams, NullValueHandling.Remove)
                    .PutJsonAsync(body, cancellationToken, System.Net.Http.HttpCompletionOption.ResponseContentRead).ReceiveJson<Tout>();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Task<Tout> Delete(object queryParams, CancellationToken cancellationToken)
        {
            try
            {
                return EndpointUrl
                    .SetQueryParams(queryParams, NullValueHandling.Remove)
                    .DeleteAsync(cancellationToken, System.Net.Http.HttpCompletionOption.ResponseContentRead).ReceiveJson<Tout>();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
