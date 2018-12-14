using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WCFRestService
{

    [ServiceContract]
    public  interface ICarRestService
    {

 

 
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
        [WebInvoke(Method = "POST",
           UriTemplate = "Customer",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetCustomer(string firstname, string lastname);

        [OperationContract]
        [WebGet(UriTemplate = "GetAllCustomer",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json)]
        string GetAllCustomer();


        [OperationContract]
        [WebGet(UriTemplate = "GetAllReservation",
      RequestFormat = WebMessageFormat.Json,
      ResponseFormat = WebMessageFormat.Json)]
        string GetAllReservation();


    }
}
