using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EventsAndDelegates
{
    public class Video
    {
        public string Title { get; set; }
    }

    //1 define a delegate
    //2. declare an event based on that delegate
    //raise an event

    //publisher class
    public class VideoEncoder
    {
       // public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        //public event VideoEncodedEventHandler VideoEncoded;

        //event handler is equivalent to delegate with which one doesnt has to create a custom delegate and event of that type 
        // 
        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("video of title " + video.Title + "is encoding..");
            Thread.Sleep(3000);
           // OnVideoEncoded(video); for sub-pub model without event aggregator
            EventAggregator.Publish(new VideoEventArgs { Video = video });
            EventAggregator.Publish<string>("simple message raised as event without event args");
            EventAggregator.Publish<MessageEventArgs>(new MessageEventArgs { Message = "message event" ,Countdown=10});
        }
         
        public void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs { Video=video});
        }



    }
}
