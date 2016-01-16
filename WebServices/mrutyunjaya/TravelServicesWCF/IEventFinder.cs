using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace TravelServicesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEventFinder" in both code and config file together.
    [ServiceContract]
    public interface IEventFinder
    {
        [OperationContract]
        List<String> getCurrentEvents(string cityName);
    }
}
