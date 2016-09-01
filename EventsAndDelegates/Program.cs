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
           var del= Delegate.CreateDelegate(typeof(Action<MailService, VideoEventArgs>), a);
           Action<object,object> caller = (instance,param) => del.DynamicInvoke(instance,param);
           caller(mailService, new VideoEventArgs {Video=video });
           // EventAggregator.Subscribe<VideoEventArgs>(caller);
            var msgService = new MessageService();
            var temp = new TempService();
            var videoEncoder = new VideoEncoder();
            //videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.Encode(video);
            Console.ReadKey();
        }
    }
}
