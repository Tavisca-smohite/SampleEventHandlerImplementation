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
            Initialise();

         //   var mailService = new MailService();
         //   var a = typeof(MailService).GetMethod("OnVideoEncoded",new Type[] {typeof(VideoEventArgs)});
         //   //a.MakeGenericMethod
         //  var del= Delegate.CreateDelegate(typeof(Action< VideoEventArgs>),mailService,a);

         //  Action<object> b = (param) => del.DynamicInvoke(param);
         // // Action<object,object> caller = (instance,param) => del.DynamicInvoke(instance,param);
         ////  b( new VideoEventArgs {Video=video });
         //   EventAggregator.Subscribe<VideoEventArgs>(b);

          //  var msgService = new MessageService();
            //var temp = new TempService();
            var videoEncoder = new VideoEncoder();
            //videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.Encode(video);
            Console.ReadKey();
        }


        private static void Initialise()
        {
            var subscriptions = new XmlDataReader().ParseSubscriptions();
            foreach(var sub in subscriptions)
            {
                var eventType = Type.GetType(sub.EventInformation.Type);
                var classType = Type.GetType(sub.ClassInformation.Type);
                var classObject= Activator.CreateInstance(classType);
                var actionDeletegateWithEventParam = typeof(Action<>).MakeGenericType(eventType);
                var methodInfo = classType.GetMethod(sub.MethodInformation.Name, new Type[] { eventType });
                var delegate1 = Delegate.CreateDelegate(actionDeletegateWithEventParam, classObject, methodInfo);
               // Action<object> tobeCalled = (param) => delegate1.DynamicInvoke(param);
               // var eve = eventType.MakeGenericType();
             //   EventAggregator.Subscribe<VideoEventArgs>(tobeCalled);

                
                var subscribe = typeof(EventAggregator).GetMethod("Subscribe").MakeGenericMethod(eventType);
                subscribe.Invoke(null,new [] {delegate1});
            }
            var mailService = new MailService();
            var a = typeof(MailService).GetMethod("OnVideoEncoded", new Type[] { typeof(VideoEventArgs) });
            //a.MakeGenericMethod
            var del = Delegate.CreateDelegate(typeof(Action<VideoEventArgs>), mailService, a);

           // Action<object> b = (param) => del.DynamicInvoke(param);
            // Action<object,object> caller = (instance,param) => del.DynamicInvoke(instance,param);
            //  b( new VideoEventArgs {Video=video });
          //  EventAggregator.Subscribe<VideoEventArgs>(b);
        }


        private void Instantiate<Tclass, Tevent>(Tclass classType, Tevent eventType, System.Reflection.MemberInfo methodinfo)
        { 
        }
    }
}
