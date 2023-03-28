using System;

namespace AddressBook_ADODotNet
{
    // What is Ado.Net -> it is a frame Work
    public class Program
    {
        public static void Main(string[] args)
        {

            AddressBookModel addressBookModel = new AddressBookModel()
            {
                FirstName = "Ram",
                LastName = "Km",
                Address = "3/5 room no",
                City = "Mumbai",
                State = "MH",
                Zip = 400078,
                PhoneNUmber = 987654321,
                Email = "rushi.koshti2@gmail.com"
            };

            AddressBookModel addressUpdate = new AddressBookModel
            {
                FirstName = "Shubham",
                LastName = "Km"
            };

            AddressBook addressBook = new AddressBook();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\n1. Create Contact" +
                    "\n2. Get All Data From Data Base" +
                     "\n3. Update the Data From Data Base" +
                     "\n4. Delete the Data From Data Base");
                Console.WriteLine("5. Exit the program");

                Console.Write("\nEnter option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                switch (option)
                {
                    case 1: addressBook.AddNewContactInDataBase(addressBookModel); break;
                    case 2: addressBook.GetAllDataFromDataBase(); break;
                    case 3: addressBook.UpdateSpecificData(addressUpdate); break;
                    case 4: addressBook.DeleteTheSpacificData("Ram", "Km"); break;
                    case 5: flag = false; break;
                }
                Console.ReadLine();
            }
        }
    }
}
