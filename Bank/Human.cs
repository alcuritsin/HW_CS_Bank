using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
    public class Human
    {
        public string _name { get; set; }
        public uint _yearBirth { get; set; }
        public Month _monthBirth { get; set; }

        public uint _dayBirth { get; set; }

        public Human(string name, uint yearBirth, Month monthBirth, uint dayBirth)
        {
            _name = name;
            _yearBirth = yearBirth;
            _monthBirth = monthBirth;
            _dayBirth = dayBirth;
        }
    }
}
