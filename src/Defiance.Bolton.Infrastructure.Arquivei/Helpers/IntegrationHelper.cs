using Defiance.Bolton.Domain.Entities;
using System;

namespace Defiance.Bolton.Infrastructure.Arquivei.Helpers
{
    public class IntegrationHelper
    {
        public string Uri { get; private set; }
        public string Endpoint { get; private set; }

        public static IntegrationHelper Build(string uri, string endPoint)
        {
            if (string.IsNullOrEmpty(uri))
                throw new Exception($"Data {nameof(uri)} is null or empty");

            if (string.IsNullOrEmpty(endPoint))
                throw new Exception($"Data {nameof(endPoint)} is null or empty");

            return new IntegrationHelper()
            {
                Uri = uri,
                Endpoint = endPoint
            };
        }

        public string GetFullUri(ImportHistory history)
        {
            return !string.IsNullOrEmpty(history?.CurrentPage)
                ? history.CurrentPage
                : $"{Uri}{Endpoint}";
        }
    }
}
