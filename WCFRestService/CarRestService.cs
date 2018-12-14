using CarRentalServiceBL;
using CarRentalServiceDL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFRestService
{
   public  class CarRestService : ICarRestService
    {


        static private CustomerMethods customerMethods = new CustomerMethods();
        static private CarMethods carMethods = new CarMethods();
        static private ReservationMethods reservationMethods = new ReservationMethods();
 
        public string GetAllCars()
        {
            List<Car> cars = carMethods.GetCars();
            var json = JsonConvert.SerializeObject(cars);
            return json;
        }

        public string GetAllCustomer()
        {
            List<Customer> customers = customerMethods.GetAllCustomers();
            var json = JsonConvert.SerializeObject(customers);
            return json;
        }


        public string GetAllReservation ()
        {
            List<Reservation> reservation = reservationMethods.GetAllReservations();
            var json = JsonConvert.SerializeObject(reservation);
            return json;
        }
        public string GetCustomer(string firstname, string lastname)
        {
            Customer customer1 = customerMethods.GetCustomer("firstname", firstname);
            Customer customer2 = customerMethods.GetCustomer("lastname", lastname);
            string jsonCustomer;
            if (customer1.FirstName != null)
            {
                jsonCustomer = JsonConvert.SerializeObject(customer1);
            }
            else
            {
                jsonCustomer = JsonConvert.SerializeObject(customer2);
            }
            return jsonCustomer;

        }

   

        public string GetCarById(string id)
        {

            Car carResult = carMethods.GetCarById(Convert.ToInt16(id));
            string jsonCar = JsonConvert.SerializeObject(carResult);
            return jsonCar;
        }

    }
}
