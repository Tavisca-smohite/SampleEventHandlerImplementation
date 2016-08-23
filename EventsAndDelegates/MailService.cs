using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    //subscriber class
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("sending mail.....");
            Console.WriteLine("For video of title :" + args.Video.Title);
        }
    }
}
