using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

using CarRentalServiceDL;
using System.ServiceModel.Web;

namespace  WCFCarRentalRestService
{
    interface ICarRentalRestService
    {


        [OperationContract]
        [WebInvoke(Method = "POST",
              UriTemplate = "Customer",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetCustomer(string firstname, string lastname);

        [OperationContract]
        [WebInvoke(Method = "POST",
              UriTemplate = "CustomerUpdate",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string UpdateCustomer(string id, string firstname, string lastname, string phone, string email);

        [OperationContract]
        [WebGet(UriTemplate = "GetAllCars",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json)]
        string GetAllCars();

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "GetCarById",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetCarById(string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
           UriTemplate = "DeleteCar",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string DeleteCar(string id);

    }
}
