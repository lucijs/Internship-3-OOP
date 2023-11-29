using Internship_3_OOP.Enum;
using System.Collections;
using System.Drawing;

namespace Internship_3_OOP.Phone
{
    public class PhoneCall : Contact
    {
        private DateTime TimeOfCall { get; set; }
        private Status PhoneStatus { get; set; }

        public PhoneCall(string firstName, string lastName, string phoneNumber, string preference, DateTime date, string status) :base(firstName,lastName,phoneNumber,preference)
        {
            TimeOfCall = date;
            PhoneStatus = status == "propušten" ? Status.Missed : (preference == "završen" ? Status.Finished : Status.Ongoing);

        }
    }
}
