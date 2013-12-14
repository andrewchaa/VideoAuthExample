using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using VideoAuthoriser.Models;

namespace VideoAuthoriser.Services
{
    public class AuthorisationService : IAuthorisationService
    {
        private readonly IWebServiceHelper _webServiceHelper;
     

        public AuthorisationService(IWebServiceHelper webServiceHelper)
        {
            _webServiceHelper = webServiceHelper;
            
        }

        public auth RequestAuthorisation(string id)
        {
            var response = _webServiceHelper.Call("http://localhost:49570/authorisationservice", id);
            
            var serialiser = new XmlSerializer(typeof(auth));
            var xmlReader = XmlReader.Create(new StringReader(response));

            return (auth)serialiser.Deserialize(xmlReader);

      
        }
    }
}