using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TravelAdvisor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICarRental" in both code and config file together.
    [ServiceContract]
    public interface ICarRental
    {
        [OperationContract]
        void DoWork();
        
        [OperationContract]
        String[] carFinder(String destination, String startDate, String endDate, String pickTime, String dropOffTime);
			
    }
}
