using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.App.STLDashboardModel
{
    public class STLDashboard
    {
    }
    public class STLParty
    {
        public String PL_ID;
        public String PL_NM;
        public String PL_ADD;
        public String PL_TEL_NO;
        public String URL_STRMNG_NM;
        public String URL_STRMNG;
        public String APP_SHRING_DESC;
    }
    public class STLRequestValidator
    {
        public string Host;
        public string Username;
        public string Password;
    }

    public class HeadOffice
    {
        //Party List Information
        public string parmplid { get; set; }
        public string parmplnm { get; set; }
        public string parmpladd { get; set; }
        public string parmtelno { get; set; }

        public string parmplemladd { get; set; }

        //Group Information
        public string parmpgrpid { get; set; }
        public string parmpsncd { get; set; }
        public string parmpltclid { get; set; }


    }
    public class AgentHeadOffice : HeadOffice
    {
        
        //User Information
        public string parmusrfnm { get; set; }
        public string parmusrlnm { get; set; }
        public string parmusrmnm { get; set; }
        public string parmusrnm { get; set; }
        public string parmusrpsswrd { get; set; }
        public string parmaddrss { get; set; }
        //6
        public string parmusrmobno { get; set; }
        public string parmemladd { get; set; }
        public string parmuserid { get; set; }
    }
    public class PCSCO : AgentHeadOffice
    {
        public string parmurlstrmngnm { get; set; }
        public string parmurlstrmng { get; set; }
        public string parmapkurl { get; set; }
        public string parmapkupdturl { get; set; }
    }
}
