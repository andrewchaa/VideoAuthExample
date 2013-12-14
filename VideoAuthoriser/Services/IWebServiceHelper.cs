using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAuthoriser.Services
{
    public interface IWebServiceHelper
    {
        string Call(string uri, string id);
    }
}
