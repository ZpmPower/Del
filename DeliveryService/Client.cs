using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    public class Client
    {
        string FirstName { set; get; }
        string SecondName { set; get; }
        string LastName { set; get; }
        string PhoneNumber { set; get; }
        List<string> pNumbers;
        List<Parcel> receivedParcels;
        public Client(string firstName, string secondName, string lastName, string phonenumber)
        {
            if (firstName!="" && secondName != "" && lastName!= "" &&  phonenumber != "")
            {
                FirstName = firstName;
                SecondName = secondName;
                LastName = lastName;
                PhoneNumber = phonenumber;
                pNumbers = new List<string>();
                receivedParcels = new List<Parcel>();
            }
        }
        public void addNumber(string number)
        {
            pNumbers.Add(number);
        }
        public void getParcel(Parcel parcel)
        {
            receivedParcels.Add(parcel);
        }
        public void showNumbers()
        {
            foreach (string s in pNumbers)
            {
                Console.Write(s + " ");
            }
        }
        public string getNumberAt(int i)
        {
            return pNumbers[i];
        }
        public string info()
        {
            return FirstName + " " + SecondName + " " + LastName + " " + PhoneNumber;
        }
    }
}
