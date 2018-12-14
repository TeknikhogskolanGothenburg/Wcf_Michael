using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIHost
{
    class Program
    {
        static void Main()
        {
            WebServiceHost host = new WebServiceHost(typeof(WCFRestService.CarRestService),
               new Uri("http://localhost:8082"));

            ServiceEndpoint ep = host.AddServiceEndpoint(
                typeof(WCFRestService.ICarRestService), new WebHttpBinding(), "");

            host.Description.Endpoints[0].Behaviors.Add(new WebHttpBehavior { HelpEnabled = true });
            //Visar vilka metoder som använder vilken metod, vilket språk den kommunicerar på, om body är wrapped eller inte

            ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            sdb.IncludeExceptionDetailInFaults = true;
            //sdb.HttpHelpPageEnabled = true; 

            host.Open();
            Console.WriteLine("Rest API Server is running on  " );
            Console.ReadKey();
            host.Close();
        }
    }
}
