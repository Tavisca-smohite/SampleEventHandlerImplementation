using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video { Title = "video 1" };
            var mailService = new MailService();
            var videoEncoder = new VideoEncoder();
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.Encode(video);
            Console.ReadKey();
        }
    }
}
