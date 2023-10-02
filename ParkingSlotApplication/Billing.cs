using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement
{
    public class Billing
    {
      
        public int SlotNumber { get; set; }
        public Vehicle Vehicle{ get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public double ParkingFee { get; set; }
        

    }
}
