using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CarRentalServiceDL;
using CarRentalServiceBL;
using System.Data.Entity;
using System.Net.Security;

namespace WCFCarRentalService
{
    
    [ServiceContract]
    public interface ICarRentalServices
    {
        #region Car Methods
        [OperationContract(ProtectionLevel = ProtectionLevel.None)]
        Car GetCarById(int id);

        [OperationContract(ProtectionLevel = ProtectionLevel.None)]
        Car GetCarByReg(string name);

        [OperationContract]
        Car GetCarByString(string option, string term);

        [OperationContract]
        List<Car> GetAllCars();

        [OperationContract]
        bool AddCar(Car car);


        

        [OperationContract]
        bool RemoveCar(string regnum);
 
        [OperationContract]
        bool UpdateCar(Car car);

         

        #endregion






        #region Customer Methods

        [OperationContract]
        bool AddCustomerTodb(Customer customer);

        [OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
        CustomerInfo GetCustomer(CustomerRequest request);

        //[OperationContract]
        //bool RemoveCustomer(string fname);


        [OperationContract]
        void DeleteCustomer(string option, string name);

        [OperationContract]
        Customer GetCustomerById(int id);

         

        

        #endregion





        #region Reservation Methods

         

         

        [OperationContract]
        List<Reservation> GetAllReservations();
        [OperationContract]
        bool AddReservation(Reservation reservation);

        [OperationContract]
        bool RemoveReservation(int id);

        [OperationContract]
        void  ReturnCar(Reservation reservation);

        [OperationContract]
        Reservation GetReservationById(int id);

        [OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
        ReservationInfo GetReservation(ReservationRequest request);

        #endregion

    }
}
