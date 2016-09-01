using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class Subscription<T> :IDisposable
    {
        public Action<T> Action { get; private set; }
        private bool isDisposed { get; set; }
        public Subscription(Action<T> executionMethod)
        {
            this.Action = executionMethod;
        }
        
        ~Subscription()
        {
            if (!isDisposed)
                Dispose();
        }

        public void Dispose()
        {
            EventAggregator.UnSbscribe(this);
            isDisposed = true;
        }

       
    }
}
