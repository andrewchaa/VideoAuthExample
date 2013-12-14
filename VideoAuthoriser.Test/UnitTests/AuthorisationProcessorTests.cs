using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VideoAuthoriser.Models;
using VideoAuthoriser.Services;
using VideoAuthoriser.Test.Helpers;
using VideoAuthoriser.Test.TestDoubles;

namespace VideoAuthoriser.Test.UnitTests
{
    [TestFixture]
    public class AuthorisationProcessorTests
    {
        private string _clientId;
        private string _authId;
        private string _startDate;
        private string _startTime;
        private string _expireafter;
        private string _history;
        private string _responseXml;
        private FakeWebServiceHelper _webServiceHelper;
        private AuthorisationService _service;
        private AuthorisationProcessor _processor;

        [SetUp]
        public void SetUp()
        {
            _clientId = "zzzzz";
            _authId = "xxxxx";
            _startDate = "2011-03-17";
            _startTime = "12:30";
            _expireafter = "3600000";
            _history = "http://domain.com/video/history/" + _authId;
            _responseXml = XmlHelper.Create(_authId, _startDate, _startTime, _expireafter, _history);

            _webServiceHelper = new FakeWebServiceHelper(_responseXml);
            _service = new AuthorisationService(_webServiceHelper);
            _processor = new AuthorisationProcessor(_service);
        }

        [Test]
        public void Id_should_be_from_Client_Id()
        {
            var vidauth = _processor.Authorise(_clientId);
            
            Assert.That(vidauth.id, Is.EqualTo(_clientId));
        }

        [Test]
        public void AuthId_comes_from_authroisation_server()
        {
            var vidauth = _processor.Authorise(_clientId);

            Assert.That(vidauth.authid, Is.EqualTo(_authId));
        }

        [Test]
        public void AvailableStart_should_be_in_UK_custom_datetime_format()
        {
            var vidauth = _processor.Authorise(_clientId);

            Assert.That(vidauth.available[0].start, Is.EqualTo("17-03-2011T12:30:00"));
        }

        [Test]
        public void AvailableEnd_should_be_calculated_expireafter()
        {
            var vidauth = _processor.Authorise(_clientId);

            Assert.That(vidauth.available[0].end, Is.EqualTo("17-03-2011T13:30:00"));
        }
    }
}
