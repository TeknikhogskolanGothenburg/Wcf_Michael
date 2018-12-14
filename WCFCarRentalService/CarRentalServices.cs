using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CarRentalServiceDL;
using CarRentalServiceBL;
using System.Data.Entity;
using System.Configuration;
 
using System.ServiceModel.Web;
using System.Net;

namespace WCFCarRentalService
{
    
    public class CarRentalServices : ICarRentalServices
    {
        static private CarMethods carMethods = new CarMethods();
        private static readonly CustomerMethods  castomerMethods = new CustomerMethods();
        private static readonly ReservationMethods reservationMethods= new CarRentalServiceBL.ReservationMethods();
        public static List<Car> Cars = new List<Car>();
        public static List<Customer> Customers = new List<Customer>();
        public static List<Reservation> Reservations  = new List<Reservation>();

        public bool AddCar(Car car)
        {
            return carMethods.AddCar(car);
        }

        public bool AddCustomerTodb (Customer customer)
        {
            return castomerMethods.AddCustomerTodb(customer);
        }

       

        public bool RemoveCar(string regnum)
        {
            return carMethods.RemoveCar(regnum);
        }

     

        public bool UpdateCar(Car car)
        {
            return carMethods.UpdateCar(car);
        }

        public void  ChangeCustomer(Customer customer)
        {
            castomerMethods.ChangeCustomer(customer);
        }

        public bool AddReservation(Reservation reservation)
        {
            return reservationMethods.AddReservation(reservation); 
        }

        public bool RemoveReservation (int id)
        {
            return reservationMethods.RemoveReservation(id);
        }

        public void ReturnCar(Reservation reservation)
        {
            reservationMethods.ReturnCar(reservation);
        }

        

        public Customer GetCustomerById(int id)
        {
           return castomerMethods.GetCustomerById(id); 
        }


        public Reservation GetReservationById(int id)
        {
            return reservationMethods.GetReservationById(id);
        }

        public void GetAvaibleCars(DateTime start, Database end)
        {
            
        }


     


        public CustomerInfo GetCustomer(CustomerRequest request)
        {
            if (request.LicenseKey == "mypassword")
            {

                Customer custr;

                int customerId = request.CustomerId;

                custr = Customers.Where(x => x.Id == customerId).FirstOrDefault();

                return new CustomerInfo(custr);


               
            }
            else
            {
                throw new WebFaultException<string>(
                    "Wrong license key",
                HttpStatusCode.Forbidden);
            }
        }


        public ReservationInfo GetReservation(ReservationRequest request)
        {
            if (request.LicenseKey == "mypassword")
            {
                Reservation reserv;

                int reservationId = request.ReservationId;

                reserv = Reservations.Where(x => x.Id == reservationId).FirstOrDefault();

                return new ReservationInfo(reserv);


                
            }
            else
            {
                throw new WebFaultException<string>(
                    "Wrong license key",
                HttpStatusCode.Forbidden);

            }
        }


        public Car GetCarByReg(string name)
        {
            return carMethods.GetCarByRegnum(name);
        }

        public Car GetCarByString(string option, string term)
        {

            Car car = carMethods.GetCarByString(option, term);
            if (car == null)
            {
                throw new FaultException("Finns ingen sådan bil förstår du...");

            }
            return car;
        }

        
       
   

        public List<Reservation> GetAllReservations()
        {
            return reservationMethods.GetAllReservations();
        }

        public List<Car> GetAllCars()
        {
            return carMethods.GetCars();
        }


        public void DeleteCustomer(string option, string name)
        {
            castomerMethods.RemoveCustomer(option, name);

        }

        public Car GetCarById(int id)
        {
           return carMethods.GetCarById(id);
        }
    }
}
