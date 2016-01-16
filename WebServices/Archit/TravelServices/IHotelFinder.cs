using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TravelAdvisor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotelFinder" in both code and config file together.
    [ServiceContract]
    public interface IHotelFinder
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        List<String> findHotels(String location);
    }
}
