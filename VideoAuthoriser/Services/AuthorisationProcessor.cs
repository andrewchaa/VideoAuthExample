using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace VideoAuthoriser.Services
{
    public class AuthorisationProcessor : IAuthorisationProcessor
    {
        private IAuthorisationService _service;

        public AuthorisationProcessor(IAuthorisationService service)
        {
            _service = service;
        }

        public vidauth Authorise(string id)
        {
            var auth = _service.RequestAuthorisation(id);

            var startDate = DateTime.Parse(auth.start[0].date + "T" + auth.start[0].time,  null, DateTimeStyles.RoundtripKind);
            var start = startDate.ToString("dd-MM-yyyyTHH:mm:ss");

            var endDateTime = startDate.AddMilliseconds(double.Parse(auth.expireafter));
            var end = endDateTime.ToString("dd-MM-yyyyTHH:mm:ss");

            var vidauthAvailble = new vidauthAvailable {start = start, end = end};

            var vidAuth = new vidauth
                {
                    id = id,
                    authid = auth.id,
                    available = new [] { vidauthAvailble }
                };
           
            return vidAuth;
        }
    }

}