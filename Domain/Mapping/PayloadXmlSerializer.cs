using System;
using System.Collections.Concurrent;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Domain.Contracts;

namespace Domain.Mapping
{
	public class PayloadXmlSerializer : IPayloadXmlSerializer
	{
		private static readonly ConcurrentDictionary<Type, XmlSerializer> Serializers = new ConcurrentDictionary<Type, XmlSerializer>();
        private static readonly object Foo = new object();

		public XElement Serialize(Payload payload)
		{
            lock (Foo)
		    {
			    var serializer = Serializers.GetOrAdd(payload.GetType(), type => new XmlSerializer(type));

			    using (var ms = new MemoryStream())
			    {
				    serializer.Serialize(ms, payload);
				    ms.Position = 0;

				    return XElement.Load(ms);
			    }
		    }
		}
	}
}