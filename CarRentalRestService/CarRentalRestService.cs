using CarRentalServiceBL;
using CarRentalServiceDL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Threading.Tasks;

namespace  WCFCarRentalRestService
{
    class CarRentalRestService
    {



        static private CustomerMethods customerMethods = new CustomerMethods();
        static private CarMethods carMethods = new CarMethods();

        public string GetAllCars()
        {
            List<Car> cars = carMethods.GetCars();
            var json = JsonConvert.SerializeObject(cars);
            return json;
        }


        public string GetCarById(string id)
        {

            Car carResult = carMethods.GetCarById(Convert.ToInt16(id));
            string jsonCar = JsonConvert.SerializeObject(carResult);
            return jsonCar;
        }

        public string UpdateCustomer(string id, string firstname, string lastname, string phone, string email)
        {
            Customer customer = new Customer();
            customer.Id = Convert.ToInt32(id);
            customer.FirstName = firstname;
            customer.LastName = lastname;
            customer.Phone = phone;
            customer.Email = email;
            try
            {
                customerMethods.ChangeCustomer(customer);
                return "Everything's gonna be alright!";
            }
            catch
            {
                return "Nothing's gonna be alright!:(";
            }

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

        public string DeleteCar(string id)
        {
            try
            {
                Car carResult = carMethods.GetCarById(Convert.ToInt16(id));
                carMethods.RemoveCar(carResult.Regnumber);
                return "Car is successfully deleted:)";
            }
            catch
            {
                return "Could not delete the car:(";
            }
        }

      
    }
}
