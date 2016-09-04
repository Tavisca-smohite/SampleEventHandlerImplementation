using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Configuration;

namespace EventsAndDelegates
{
    public class XmlDataReader
    {
        public List<SubscriptionInformation> ParseSubscriptions()
        {
            //string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            //directoryPath = (directoryPath.EndsWith("\\bin\\Debug"))
            //                    ? directoryPath.Replace("\\bin\\Debug", "")
            //                    : directoryPath;

            //string path = directoryPath + ConfigurationManager.AppSettings["Subscriptions"];
            string path = ConfigurationManager.AppSettings["Subscriptions"];
            var eventsXml = XDocument.Load(path);

            List<XElement> events =
                eventsXml.Descendants().Where(arg => arg.Name.LocalName == "Event").ToList();

            return (from eventNode in events
                    let eventName = eventNode.Attribute("name")
                    let eventType = eventNode.Attribute("type")
                    let subscriptionInformation = eventNode.Element("SubscriptionInformation")
                    let classInformation = subscriptionInformation.Element("ClassInformation")
                    let className = classInformation.Attribute("name")
                    let classType = classInformation.Attribute("type")
                    let methodInformation = subscriptionInformation.Element("MethodInformation").Attribute("name")
                    select new SubscriptionInformation
                    {
                        EventInformation = new Signature
                        {
                            Name = (eventName != null) ? eventName.Value : string.Empty,
                            Type = (eventType != null) ? eventType.Value : string.Empty
                        },
                        MethodInformation = new MethodSignature
                        {
                            Name = (methodInformation != null) ? methodInformation.Value : string.Empty
                        },
                        ClassInformation = new Signature {
                            Name = (className != null) ? className.Value : string.Empty,
                            Type = (classType != null) ? classType.Value : string.Empty
                        }
                    }).ToList();
        }
    }
}
