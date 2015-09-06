using System.Xml.Linq;
using Domain.Contracts;

namespace Domain.Mapping
{
	public interface IPayloadXmlSerializer
	{
        XElement Serialize(Payload payload);
	}
}