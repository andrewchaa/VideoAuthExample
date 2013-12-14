using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VideoAuthoriser.Services;
using VideoAuthoriser.Test.Helpers;
using VideoAuthoriser.Test.TestDoubles;

namespace VideoAuthoriser.Test.UnitTests
{
    [TestFixture]
    public class AuthorisationServiceTests
    {

        [Test]
        public void test_startdate_expireafter_history()
        {
            var authId = "xxxxx";

            string startDate = "2011-03-17";
            string startTime = "12:30";
            string expireafter = "3600000";
            string history = "http://domain.com/video/history/" + authId;
            string xml = XmlHelper.Create(authId, startDate, startTime, expireafter, history);

            var fakeWebServiceHelper = new FakeWebServiceHelper(xml);
            var service = new AuthorisationService(fakeWebServiceHelper);
            var auth = service.RequestAuthorisation(authId);

            Assert.That(auth.id, Is.EqualTo(authId));
            Assert.That(auth.start[0].date, Is.EqualTo(startDate));
            Assert.That(auth.start[0].time, Is.EqualTo(startTime));
            Assert.That(auth.expireafter, Is.EqualTo(expireafter));
            Assert.That(auth.history[0].href, Is.EqualTo(history));
        }
    }
}
