using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace VideoAuthoriser.Services
{
    public class WebServiceHelper : IWebServiceHelper
    {
        public string Call(string uri, string id)
        {
            using (var client = new WebClient())
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["id"] = id;

                var url = new UriBuilder(uri) { Query = query.ToString() };
                return client.DownloadString(url.ToString());
            }
        }
    }
}