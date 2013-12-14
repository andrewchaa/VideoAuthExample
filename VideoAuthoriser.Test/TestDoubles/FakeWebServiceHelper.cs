using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoAuthoriser.Services;

namespace VideoAuthoriser.Test.TestDoubles
{
    public class FakeWebServiceHelper : IWebServiceHelper
    {
        public string Uri { get; private set; }
        public string Id { get; private set; }
        public string Xml { get; private set; }


        public FakeWebServiceHelper(string xml)
        {
            Xml = xml;
        }

        public string Call(string uri, string id)
        {
            Uri = uri;
            Id = id;

            return Xml;
        }
    }
}
