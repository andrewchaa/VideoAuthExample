using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAuthoriser.Test.Helpers
{
    public static class XmlHelper
    {
        public static string Create(string authid, string startdate, string starttime, string expireafter, string history)
        {
            return "<auth id=\"" + authid + "\">" +
             "<start date=\"" + startdate + "\" time=\"" + starttime + "\"/>" +
             "<expireafter>" + expireafter + "</expireafter>" +
             "<history href=\"" + history + "\" />" +
             "</auth>";
        }

        //public static string Create(string sig, string id, string authid, string start, string end)
        //{
        //    return "<vidauth sig=\"" + sig + "\">" +
        //     "<id>" + id + "</id>" +
        //     "<authid>" + authid + "</authid>" +
        //     "<available start=\"" + start + "\" end=" + end + " />" +
        //     "</vidauth>";

        //}
    }
}
