using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class EventAggregator //: IEventAggregator
    {
        public static Dictionary<Type, IList> SubscriberLookups= new Dictionary<Type,IList>();

        public EventAggregator()
        {
           // SubscriberLookups = new Dictionary<Type, IList>();
        }

        public static void Publish<TMessageType>(TMessageType message)
        {
            Type t = typeof(TMessageType);
            IList actionlst;
            if (SubscriberLookups.ContainsKey(t))
            {
                actionlst = new List<Subscription<TMessageType>>(SubscriberLookups[t].Cast<Subscription<TMessageType>>());

                foreach (Subscription<TMessageType> a in actionlst)
                {
                    a.Action(message);
                }
            }
        }

        public static Subscription<TMessageType> Subscribe<TMessageType>(Action<TMessageType> action)
        {
            Type t = typeof(TMessageType);
            IList actionlst;
            var actiondetail = new Subscription<TMessageType>(action);

            if (!SubscriberLookups.TryGetValue(t, out actionlst))
            {
                actionlst = new List<Subscription<TMessageType>>();
                actionlst.Add(actiondetail);
                SubscriberLookups.Add(t, actionlst);
            }
            else
            {
                actionlst.Add(actiondetail);
            }

            return actiondetail;
        }

        public static void UnSbscribe<TMessageType>(Subscription<TMessageType> subscription)
        {
            Type t = typeof(TMessageType);
            if (SubscriberLookups.ContainsKey(t))
            {
                SubscriberLookups[t].Remove(subscription);
            }
        }

        //public void Publish<T>(T args)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Subscribe<T>(T eventType, Action<T> method)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
