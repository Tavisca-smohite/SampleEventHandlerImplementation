using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    class Program
    {
        //get an event name from xml 
        static void Main(string[] args)
        {

            var video = new Video { Title = "video 1" };
            var mailService = new MailService();
            var a = typeof(MailService).GetMethod("OnVideoEncoded",new Type[] {typeof(VideoEventArgs)});
            //a.MakeGenericMethod
           var del= Delegate.CreateDelegate(typeof(Action< VideoEventArgs>),mailService,a);

           Action<object> b = (param) => del.DynamicInvoke(param);
          // Action<object,object> caller = (instance,param) => del.DynamicInvoke(instance,param);
         //  b( new VideoEventArgs {Video=video });
            EventAggregator.Subscribe<VideoEventArgs>(b);
          //  var msgService = new MessageService();
            //var temp = new TempService();
            var videoEncoder = new VideoEncoder();
            //videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.Encode(video);
            Console.ReadKey();
        }
    }
}
