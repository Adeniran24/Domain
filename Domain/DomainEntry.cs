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
        public DomainEntry(string line)
        {

            var parts = line.Split(';');
            if (parts.Length >= 2)
            {
                DomainName = parts[0].Trim();
                IpAddress = parts[1].Trim();
            }
            else
            {
                throw new ArgumentException("Hibás sorformátum: " + line);
            }
        }
        public override string ToString()
        {
            return $"{DomainName};{IpAddress}";
        }
    }
}
