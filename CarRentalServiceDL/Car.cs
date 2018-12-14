using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ServiceModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Runtime.Serialization;
using System.Net.Security;

namespace CarRentalServiceDL
{




    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Regnumber { get; set; }
    }
}
