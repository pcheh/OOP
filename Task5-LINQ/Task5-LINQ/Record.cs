using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_LINQ
{
    public struct Record
    {
        public int ClientID;
        public int Year;
        public int Month;
        public int Duration;

        public Record(int clientID, int year, int month, int duration)
        {
            ClientID = clientID;
            Year = year;
            Month = month;
            Duration = duration;
        }
    }
}
