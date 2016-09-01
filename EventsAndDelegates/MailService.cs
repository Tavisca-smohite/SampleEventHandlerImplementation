using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    //subscriber class
    public class MailService
    {
        public MailService()
        {
            //EventAggregator.Subscribe<VideoEventArgs>(OnVideoEncoded);
        }
        public void OnVideoEncoded(VideoEventArgs args)
        {
            Console.WriteLine("sending mail.....");
            Console.WriteLine("For video of title :" + args.Video.Title);
        }
    }

    //subscriber class
    public class MessageService
    {
         public MessageService()
        {
            EventAggregator.Subscribe<MessageEventArgs>(OnVideoEncoded);
        }
        public void OnVideoEncoded(MessageEventArgs args)
        {
            Console.WriteLine("sending message.....");
            Console.WriteLine("message received :" + args.Message);
            Thread.Sleep(args.Countdown * 1000);
        }
    }


    //subscriber class
    public class TempService
    {
        public TempService()
        {
            EventAggregator.Subscribe<string>(OnVideoEncoded);
            EventAggregator.Subscribe<MessageEventArgs>(OnVideoEncoded);
        }
        public void OnVideoEncoded(string message)
        {
            Console.WriteLine("sending message.....");
            Console.WriteLine("message received :" + message);
           // Thread.Sleep(args.Countdown * 1000);
        }

        public void OnVideoEncoded(MessageEventArgs message)
        {
            Console.WriteLine("sending message.....");
            Console.WriteLine("message received :" + message.Message + "TempService");
             Thread.Sleep(message.Countdown * 1000);
             Console.WriteLine("--------------");
        }
    }
}
