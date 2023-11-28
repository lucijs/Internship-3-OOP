using Internship_3_OOP.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Classes
{
    public static class CallHistory
    {
        public static List<PhoneCall> AllPhoneCalls { get; } = new();

        public static void Add(PhoneCall phoneCall)
        { 
            AllPhoneCalls.Add(phoneCall);
        }

    }
}
