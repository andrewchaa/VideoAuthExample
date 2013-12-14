using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using VideoAuthoriser.Services;

namespace VideoAuthoriser.Controllers
{
    public class VideoController : Controller
    {
        private readonly IAuthorisationProcessor _processor;

        public VideoController(IAuthorisationProcessor processor)
        {
            _processor = processor;
        }
       
        //
        // GET: /Video/
        public ActionResult Index(string id)
        {
            var vidauth = _processor.Authorise(id);

            var writer = new StringWriter();
            var serialiser = new XmlSerializer(typeof(vidauth));
            serialiser.Serialize(writer, vidauth);
            var xmlResponse = writer.ToString();

            Response.StatusCode = (int)HttpStatusCode.OK;

            return Content(xmlResponse, "text/xml");
        }

        
    }

}
