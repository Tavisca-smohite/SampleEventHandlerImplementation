using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
     public interface IEventAggregator
    {
         
          void Publish<T>(T args);
          Subscription<T> Subscribe<T>(Subscription<T> subscription);
    }
}
