using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DomainEntry
    {
        public string DomainName { get; private set; }
        public string IpAddress { get; private set; }


        public DomainEntry(string domainName, string ipAddress)
        {
            DomainName = domainName;
            IpAddress = ipAddress;
        }
    }
}
