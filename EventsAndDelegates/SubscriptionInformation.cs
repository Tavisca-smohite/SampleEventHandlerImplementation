using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class SubscriptionInformation
    {
        public MethodSignature MethodInformation { get; set; }

        public Signature ClassInformation { get; set; }

        public Signature EventInformation { get; set; }
    }

    public class Signature
    {
        public string Name { get; set; }

        public string Type { get; set; }
    }

   public class MethodSignature
    {
       public string Name { get; set; }

       public List<string> Parameters { get; set; }
    }
}
