using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAuthoriser.Services
{
    public interface IAuthorisationProcessor
    {
        vidauth Authorise(string id);
    }
}
