using Internship_3_OOP.Classes;
using Internship_3_OOP.Enum;


namespace Internship_3_OOP.Phone
{
    public class PhoneCall : Contact
    {
        private DateTime TimeOfCall { get; set; }
        private Status PhoneStatus { get; set; }

        public PhoneCall(string firstName, string lastName, string phoneNumber, string preference, DateTime date, Status status) :base(firstName,lastName,phoneNumber,preference)
        {
            TimeOfCall = date;
            PhoneStatus = status;

        }
        public PhoneCall(Contact contact, DateTime date, Status status) : base(contact.FirstName,contact.LastName,contact.PhoneNumber, contact.ContactPreferences)
        {
            TimeOfCall = date;
            PhoneStatus = status;
        }
        public void PrintThePhoneCall()
        {
            Console.WriteLine($"{FirstName} {LastName}\n\t{PhoneNumber}\n\t{ContactPreferences}\n\t{TimeOfCall}\n\t{PhoneStatus}");
        }

        public DateTime WhatWasTheTimeOfTheCall()
        { 
            return TimeOfCall;
        }
        public Status ReturnTheStatus()
        {
            return PhoneStatus;
        }
        public void FinishThePhonCall()
        {
            PhoneStatus = Status.Finished;
        }
    }
}
